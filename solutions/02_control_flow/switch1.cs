// switch1.cs — solution

string DayType(string day)
{
    string result;
    switch (day)
    {
        case "Saturday":
        case "Sunday":
            result = "weekend";
            break;
        case "Monday":
            result = "ugh";
            break;
        case "Tuesday":
        case "Wednesday":
        case "Thursday":
        case "Friday":
            result = "weekday";
            break;
        default:
            result = "not a day!";
            break;
    }
    return result;
}

Check.Equal("weekend", DayType("Saturday"));
Check.Equal("weekend", DayType("Sunday"));
Check.Equal("ugh", DayType("Monday"));
Check.Equal("weekday", DayType("Wednesday"));
Check.Equal("weekday", DayType("Friday"));
Check.Equal("not a day!", DayType("Caturday"));
