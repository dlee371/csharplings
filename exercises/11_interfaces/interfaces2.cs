// interfaces2.cs
//
// Interfaces are the backbone of professional C#. Instead of a class creating
// the things it depends on, it asks for INTERFACES in its constructor. This is
// called *dependency injection* (DI), and ASP.NET Core is built entirely around it.
//
// Why bother? Because now you can swap implementations: a real email sender in
// production, a fake one in your tests. Code that does `new SmtpClient()` or
// reads `DateTime.Now` deep inside is very hard to test.
//
// A neat C# 12 feature: *primary constructors*. The parameters go right after
// the class name and can be used anywhere inside the class:
//
//     class OrderService(IEmailSender email, ILogger logger)
//     {
//         public void PlaceOrder() { ... email.Send(...); ... }
//     }

// I AM NOT DONE

var fakeEmail = new FakeEmailSender();
var fakeClock = new FixedClock(new DateTime(2026, 1, 15));
var service = new SignupService(fakeEmail, fakeClock);

service.Register("ada@example.com");

Check.Equal(1, fakeEmail.Sent.Count);
Check.Equal("ada@example.com: Welcome! You joined on 2026-01-15.", fakeEmail.Sent[0]);

interface IEmailSender
{
    void Send(string to, string body);
}

interface IClock
{
    DateTime Now { get; }
}

// A "test double": records emails instead of actually sending them.
class FakeEmailSender : IEmailSender
{
    public List<string> Sent { get; } = [];
    public void Send(string to, string body) => Sent.Add($"{to}: {body}");
}

// TODO: a FixedClock that implements IClock, and always returns the date given to its constructor.

// 🐛 This class is impossible to test: it creates its own email sender and uses the real time!
//    Change it to receive an IEmailSender and an IClock through its constructor.
class SignupService
{
    public void Register(string email)
    {
        var sender = new SmtpEmailSender();
        sender.Send(email, $"Welcome! You joined on {DateTime.Now:yyyy-MM-dd}.");
    }
}

class SmtpEmailSender : IEmailSender
{
    public void Send(string to, string body) =>
        throw new NotImplementedException("Imagine this talks to a real mail server...");
}
