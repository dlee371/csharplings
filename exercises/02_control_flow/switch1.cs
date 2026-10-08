// switch1.cs
//
// A switch statement picks one branch based on a value. It's often clearer than
// a long chain of if / else if:
//
//     switch (command)
//     {
//         case "start":
//             Start();
//             break;           // every case must end with break (or return)
//         case "stop":
//         case "halt":         // several labels can share one body
//             Stop();
//             break;
//         default:             // runs when nothing else matched
//             Console.WriteLine("Unknown command");
//             break;
//     }
//
// Unlike C or JavaScript, C# does NOT let one case "fall through" into the next.



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
        // TODO: Tuesday to Friday should give "weekday", anything else "not a day!"
    }
    return result;
}

Check.Equal("weekend", DayType("Saturday"));
Check.Equal("weekend", DayType("Sunday"));
Check.Equal("ugh", DayType("Monday"));
Check.Equal("weekday", DayType("Wednesday"));
Check.Equal("weekday", DayType("Friday"));
Check.Equal("not a day!", DayType("Caturday"));
