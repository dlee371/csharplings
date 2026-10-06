# Csharplings 🟣

Small exercises to get you reading and writing C#, in the style of
[Rustlings](https://github.com/rust-lang/rustlings) and [Ziglings](https://codeberg.org/ziglings/exercises).

Each exercise is a small, broken C# program. Your job is to fix it. The runner
watches your files, and every time you save, it compiles and runs the current
exercise and tells you exactly what's still wrong. Each file opens with a short
lesson in its comments, so you learn the concept and use it straight away.

## Setup

1. Install the **.NET 10 SDK** from <https://dotnet.microsoft.com/download> and check it worked:
   ```bash
   dotnet --version
   ```
2. Open this folder in your editor. **VS Code** with the **C# Dev Kit** extension works well.
   (JetBrains Rider and Visual Studio are great too.)
3. Open a terminal in this folder and start the runner:
   ```bash
   dotnet run
   ```
   The first start downloads the C# compiler package and builds the runner, so it takes a minute.
   After that it starts in a few seconds.

## How it works

1. The runner shows the current exercise and its compiler errors or failed checks.
2. Open that file in your editor, read the lesson at the top, and fix the code.
3. Save. The runner re-checks automatically.
4. Once it passes, read your solution again and make sure you understand *why* it works.
   Then delete the `// I AM NOT DONE` line and save to move on to the next exercise.

While the runner is open, press:

| Key | Action |
|-----|--------|
| `h` | Show or hide a hint for the current exercise |
| `l` | List all exercises and your progress |
| `r` | Re-run the current exercise |
| `q` | Quit (your progress is kept) |

### Other commands

```bash
dotnet run -- list                 # all exercises and progress
dotnet run -- hint variables3      # hint for one exercise
dotnet run -- run variables3       # run one exercise
dotnet run -- solution variables3  # a reference solution (try hard first!)
dotnet run -- reset variables3     # restore an exercise to how it started
dotnet run -- verify               # re-check every exercise, in order
```

### About `Check`

Each exercise ends with lines like `Check.Equal(expected, actual)`. These are its
tests. **Don't change the checks — change the code above them.** The runner adds
`Check` to every exercise for you (see [support/Prelude.cs](support/Prelude.cs)), so your
editor may underline it as unknown. That's expected: the runner's output is what counts.

`???` marks a blank for you to fill in.

## What you'll learn

| # | Topic | Exercises |
|---|-------|-----------|
| 00 | Intro | Using the runner, reading compiler errors |
| 01 | Variables | Types, `var`, `const`, numeric types, conversions & parsing |
| 02 | Control flow | `if`/`else`, logical operators, `switch`, `for`/`while`/`foreach`, FizzBuzz |
| 03 | Strings | Interpolation, string methods, ranges, `StringBuilder`, `Split`, raw strings |
| 04 | Methods | Parameters & return types, expression bodies, optional/named params, overloads, `ref`/`out`, tuples |
| 05 | Collections | Arrays, `List<T>`, `Dictionary<K,V>`, `HashSet`, `Queue`, `Stack` |
| 🧩 | **Quiz 1** | A gradebook |
| 06 | Classes | Fields, constructors, properties, `static`, `init`/`required`, `ToString` |
| 07 | Structs & records | Value vs. reference semantics, records, `with` |
| 08 | Enums | Enums and switching on them |
| 09 | Nullability | `int?`, `?.`, `??`, `??=`, nullable reference types |
| 10 | Inheritance | Base classes, `virtual`/`override`, `abstract` |
| 11 | Interfaces | Interfaces, **dependency injection**, `IComparable<T>` |
| 12 | Exceptions | `try`/`catch`/`finally`, throwing, custom exceptions, `using`/`IDisposable` |
| 🧩 | **Quiz 2** | A banking model |
| 13 | Generics | Generic methods & classes, constraints, a generic repository |
| 14 | Pattern matching | `is`, switch expressions, property / tuple / relational patterns |
| 15 | Lambdas & events | `Func`/`Action`, higher-order functions, closures, events |
| 16 | LINQ | `Where`/`Select`, sorting, `First`/`Any`/`All`, `GroupBy`, `ToDictionary`, query syntax, joins |
| 17 | Iterators | `yield return`, lazy and infinite sequences |
| 18 | Extension methods | Adding methods to existing types |
| 19 | Async | `async`/`await`, `Task.WhenAll`, cancellation |
| 🧩 | **Quiz 3** | A log analyzer |

66 exercises in total. Several are modelled on real interview questions (FizzBuzz,
word counting, balanced brackets) and on everyday professional code (dependency
injection, repositories, LINQ reports, cancellation).

## Tips

- **Read the compiler errors.** The line and column point right at the problem, and
  the message usually tells you what's wrong. Fix the *first* error first.
- **Try before looking at the hint**, and look at the hint before the solution.
- After an exercise passes, **change things and break it on purpose.** Watching what
  happens is one of the fastest ways to learn.
- Keep the official docs open: <https://learn.microsoft.com/dotnet/csharp/>

## After Csharplings: getting job-ready

Real C# jobs are mostly about building on .NET. Good next steps, roughly in order:

1. **Real projects and the CLI.** `dotnet new console -o MyApp`, then `dotnet build`,
   `dotnet run`, `dotnet add package`. Learn what a `.csproj` file and a solution (`.sln`/`.slnx`) are.
2. **Unit testing with xUnit.** `dotnet new xunit`. The `Check` calls you've been reading
   are basically a tiny test framework. Most teams expect you to write tests.
3. **ASP.NET Core Web APIs.** `dotnet new webapi`. Covers routing, controllers or minimal
   APIs, dependency injection (you've already seen the idea), configuration, and logging.
4. **Entity Framework Core.** Talking to SQL databases with LINQ.
5. **Git, and reading other people's code.** Contribute to a small open-source C# project.
6. **Build one portfolio project end to end**, for example a small web API with a database and tests.
