// inheritance2.cs
//
// A base class can mark a method `virtual`, which lets subclasses `override` it.
// When you call that method, C# runs the version for the object's REAL type —
// even through a base-class variable. This is *polymorphism*.
//
//     class Shape { public virtual string Name() => "shape"; }
//     class Circle : Shape { public override string Name() => "circle"; }
//
//     Shape s = new Circle();
//     s.Name()          // "circle"
//
// Inside an override, `base.Name()` calls the parent's version.
//
// Without `virtual`/`override`, a subclass method with the same name just *hides*
// the parent's (the compiler warns you, CS0108), and calls through a base-class
// variable still run the parent's version. Read the warnings!

// I AM NOT DONE

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

    public string Send() => $"Notification: {Message}";
}

class EmailNotification : Notification
{
    public string Address { get; }
    public EmailNotification(string message, string address) : base(message) => Address = address;

    public string Send() => $"Email to {Address}: {Message}";
}

class SmsNotification : Notification
{
    public string Phone { get; }
    public SmsNotification(string message, string phone) : base(message) => Phone = phone;

    // TODO: override Send() — reuse the base version, and add " (via SMS to <phone>)"
}
