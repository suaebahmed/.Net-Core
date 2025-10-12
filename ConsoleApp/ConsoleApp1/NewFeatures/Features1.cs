using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp1.NewFeatures;
public enum DaysOfWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

[Flags]
public enum Permissions
{
    None = 0,
    Read = 1,
    Write = 2,
    Execute = 4,
    All = Read | Write | Execute
}

public class Features1
{
    public Features1()
    {
         var today = DaysOfWeek.Friday;

        Console.WriteLine($"Today is {today}");

        Console.WriteLine($"Today is {(int)today}");

        DayOfWeek day = (DayOfWeek)6; // Friday
        Console.WriteLine(GetDayType(day));
        Console.WriteLine(GetDayType(DayOfWeek.Wednesday));


        // Example of using the Permissions enum
        Permissions userPermissions = Permissions.Read | Permissions.Write;
        Permissions userAll = Permissions.All;
        Console.WriteLine($"User Permissions: {userPermissions} and see all: {userAll}");

    }

    public static string GetDayType(DayOfWeek day)
    {
        string res = day switch
        {
            DayOfWeek.Saturday or DayOfWeek.Sunday => "Weekend",
            DayOfWeek.Monday or DayOfWeek.Tuesday or DayOfWeek.Wednesday or DayOfWeek.Thursday or DayOfWeek.Friday => "Weekday",
            _ => throw new ArgumentOutOfRangeException(nameof(day), $"Not expected day value: {day}")
        };
        return res;
    }
}
