// if2.cs — solution

string TicketType(int age, bool isStudent)
{
    if (age < 12)
    {
        return "child";
    }
    else if (age >= 65)
    {
        return "senior";
    }
    else if (isStudent)
    {
        return "student";
    }
    else
    {
        return "adult";
    }
}

Check.Equal("child", TicketType(11, isStudent: true));
Check.Equal("adult", TicketType(12, isStudent: false));
Check.Equal("student", TicketType(20, isStudent: true));
Check.Equal("adult", TicketType(30, isStudent: false));
Check.Equal("senior", TicketType(65, isStudent: false));
Check.Equal("senior", TicketType(70, isStudent: true));
