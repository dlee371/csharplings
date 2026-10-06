// inheritance2.cs — solution

List<Notification> notifications =
[
    new Notification("Server restarted"),
    new EmailNotification("Invoice ready", "ada@example.com"),
    new SmsNotification("Your code is 1234", "+15550100"),
];

var sent = new List<string>();
foreach (Notification n in notifications)
{
    sent.Add(n.Send());
}

Check.Equal("Notification: Server restarted", sent[0]);
Check.Equal("Email to ada@example.com: Invoice ready", sent[1]);
Check.Equal("Notification: Your code is 1234 (via SMS to +15550100)", sent[2]);

class Notification
{
    public string Message { get; }
    public Notification(string message) => Message = message;

    public virtual string Send() => $"Notification: {Message}";
}

class EmailNotification : Notification
{
    public string Address { get; }
    public EmailNotification(string message, string address) : base(message) => Address = address;

    public override string Send() => $"Email to {Address}: {Message}";
}

class SmsNotification : Notification
{
    public string Phone { get; }
    public SmsNotification(string message, string phone) : base(message) => Phone = phone;

    public override string Send() => $"{base.Send()} (via SMS to {Phone})";
}
