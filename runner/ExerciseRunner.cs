using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Text;

namespace Csharplings;

public enum Outcome { CompileError, Failed, TimedOut, Passed }

public sealed record RunResult(Outcome Outcome, string Output, IReadOnlyList<Diagnostic> Diagnostics, string Source)
{
    public bool Passed => Outcome == Outcome.Passed;
}

/// <summary>
/// Compiles a single exercise in memory with Roslyn (fast!), then runs it in a separate
/// process so infinite loops can be killed and crashes can't take down the watcher.
/// </summary>
public sealed class ExerciseRunner
{
    static readonly TimeSpan Timeout = TimeSpan.FromSeconds(10);

    const string GlobalUsings = """
        global using System;
        global using System.Collections.Generic;
        global using System.IO;
        global using System.Linq;
        global using System.Net.Http;
        global using System.Text;
        global using System.Threading;
        global using System.Threading.Tasks;
        """;

    readonly string _root;
    readonly string _buildDir;
    readonly CSharpParseOptions _parseOptions = new(LanguageVersion.Latest);
    readonly List<MetadataReference> _references;
    readonly SyntaxTree[] _supportTrees;

    public ExerciseRunner(string root)
    {
        _root = root;
        _buildDir = Path.Combine(root, ".csharplings", "build");
        Directory.CreateDirectory(_buildDir);

        // Reference the same framework assemblies the runner itself is running on.
        var tpa = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")!).Split(Path.PathSeparator);
        var runtimeDir = Path.GetDirectoryName(typeof(object).Assembly.Location)!;
        _references = tpa
            .Where(p => Path.GetDirectoryName(p) == runtimeDir && p.EndsWith(".dll"))
            .Select(p => (MetadataReference)MetadataReference.CreateFromFile(p))
            .ToList();

        var preludePath = Path.Combine(root, "support", "Prelude.cs");
        _supportTrees =
        [
            CSharpSyntaxTree.ParseText(SourceText.From(File.ReadAllText(preludePath), Encoding.UTF8), _parseOptions, preludePath),
            CSharpSyntaxTree.ParseText(SourceText.From(GlobalUsings, Encoding.UTF8), _parseOptions, "GlobalUsings.g.cs"),
        ];
    }

    public RunResult Run(Exercise ex) => Run(ex, ex.ReadSource(_root), ex.FullPath(_root));

    public RunResult Run(Exercise ex, string source, string displayPath)
    {
        var tree = CSharpSyntaxTree.ParseText(SourceText.From(source, Encoding.UTF8), _parseOptions, displayPath);

        var options = new CSharpCompilationOptions(
            OutputKind.ConsoleApplication,
            nullableContextOptions: NullableContextOptions.Enable,
            optimizationLevel: OptimizationLevel.Debug);
        if (ex.Strict)
            options = options.WithGeneralDiagnosticOption(ReportDiagnostic.Error);

        var compilation = CSharpCompilation.Create(ex.Name, [tree, .. _supportTrees], _references, options);

        var dll = Path.Combine(_buildDir, ex.Name + ".dll");
        var pdb = Path.Combine(_buildDir, ex.Name + ".pdb");
        EmitResult emit;
        using (var dllStream = File.Create(dll))
        using (var pdbStream = File.Create(pdb))
        {
            emit = compilation.Emit(dllStream, pdbStream,
                options: new EmitOptions(debugInformationFormat: DebugInformationFormat.PortablePdb));
        }

        // Only show diagnostics that point at the learner's file.
        var diagnostics = emit.Diagnostics
            .Where(d => d.Severity >= DiagnosticSeverity.Warning)
            .Where(d => !d.Location.IsInSource || d.Location.SourceTree == tree || Environment.GetEnvironmentVariable("CSHARPLINGS_DEBUG") != null)
            .OrderByDescending(d => d.Severity)
            .ThenBy(d => d.Location.SourceSpan.Start)
            .ToList();

        if (!emit.Success)
            return new RunResult(Outcome.CompileError, "", diagnostics, source);

        var runtimeConfig = Path.Combine(_buildDir, ex.Name + ".runtimeconfig.json");
        File.WriteAllText(runtimeConfig, JsonSerializer.Serialize(new
        {
            runtimeOptions = new
            {
                tfm = $"net{Environment.Version.Major}.0",
                framework = new { name = "Microsoft.NETCore.App", version = Environment.Version.ToString() },
            },
        }));

        var (outcome, output) = Execute(dll, runtimeConfig);
        return new RunResult(outcome, output, diagnostics, source);
    }

    (Outcome, string) Execute(string dll, string runtimeConfig)
    {
        var psi = new ProcessStartInfo(Environment.GetEnvironmentVariable("DOTNET_HOST_PATH") ?? "dotnet")
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            RedirectStandardInput = true,
            StandardOutputEncoding = Encoding.UTF8,
            StandardErrorEncoding = Encoding.UTF8,
            WorkingDirectory = _root,
        };
        psi.ArgumentList.Add("exec");
        psi.ArgumentList.Add("--runtimeconfig");
        psi.ArgumentList.Add(runtimeConfig);
        psi.ArgumentList.Add(dll);

        var output = new StringBuilder();
        using var process = new Process { StartInfo = psi };
        process.OutputDataReceived += (_, e) => { if (e.Data != null) lock (output) output.AppendLine(e.Data); };
        process.ErrorDataReceived += (_, e) => { if (e.Data != null) lock (output) output.AppendLine(e.Data); };
        process.Start();
        process.StandardInput.Close();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        if (!process.WaitForExit(Timeout))
        {
            process.Kill(entireProcessTree: true);
            process.WaitForExit();
            lock (output)
                output.AppendLine($"⏱  Your program was still running after {Timeout.TotalSeconds:0} seconds, so it was stopped. Is there an infinite loop?");
            return (Outcome.TimedOut, output.ToString());
        }
        process.WaitForExit(); // flush async output handlers

        lock (output)
            return (process.ExitCode == 0 ? Outcome.Passed : Outcome.Failed, output.ToString());
    }
}
