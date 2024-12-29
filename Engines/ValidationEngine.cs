using Spectre.Console;
using System.Text.RegularExpressions;

namespace CodingTracker.Engines
{
    internal static class ValidationEngine
    {
        public static string ValidStartDate()
        {
            string? s = AnsiConsole.Ask<string>("Enter the start time (mm/dd/yyyy HH:MM:SS): ");
            var r = new Regex("^([0][1-9]|[1][0-2])[-.\\/]([0][1-9]|[1-2][0-9]|[3][0-1])[-.\\/]([0-9]{4}) ([0-1][0-9]|[2][0-4]):([0-5][0-9]):([0-5][0-9])$");

            while (!r.IsMatch(s))
            {
                s = AnsiConsole.Ask<string>("Enter a valid input for the start time (mm/dd/yyyy HH:MM:SS): ");
            }

            return s;
        }

        public static string ValidEndDate(DateTime startDate)
        {
            string? s = AnsiConsole.Ask<string>("Enter the end time (mm/dd/yyyy HH:MM:SS) (press ENTER for current time): ");
            var r = new Regex("^([0][1-9]|[1][0-2])[-.\\/]([0][1-9]|[1-2][0-9]|[3][0-1])[-.\\/]([0-9]{4}) ([0-1][0-9]|[2][0-4]):([0-5][0-9]):([0-5][0-9])$");

            while (!r.IsMatch(s) || DateTime.Parse(s) < startDate)
            {
                s = AnsiConsole.Ask<string>("Enter a valid input for the end time (mm/dd/yyyy HH:MM:SS): ");
            }

            return s;
        }
    }
}
