// interfaces2.cs — solution

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

class FakeEmailSender : IEmailSender
{
    public List<string> Sent { get; } = [];
    public void Send(string to, string body) => Sent.Add($"{to}: {body}");
}

class FixedClock(DateTime now) : IClock
{
    public DateTime Now => now;
}

class SignupService(IEmailSender emailSender, IClock clock)
{
    public void Register(string email)
    {
        emailSender.Send(email, $"Welcome! You joined on {clock.Now:yyyy-MM-dd}.");
    }
}

class SmtpEmailSender : IEmailSender
{
    public void Send(string to, string body) =>
        throw new NotImplementedException("Imagine this talks to a real mail server...");
}
