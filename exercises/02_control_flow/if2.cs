// if2.cs
//
// Combine conditions with logical operators:
//
//     &&   and     (age >= 18 && hasTicket)
//     ||   or      (isWeekend || isHoliday)
//     !    not     (!isClosed)
//
// This code compiles, but it has THREE bugs. A cinema's ticket rules are:
//
//   * under 12           → "child"
//   * 65 or older        → "senior"
//   * students (12–64)   → "student"
//   * everyone else      → "adult"
//
// Read the failing check's message, find the bug, fix it, repeat.
// This is what a lot of real programming looks like!



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
    else if (isStudent && age >= 12 && age <= 64)
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
