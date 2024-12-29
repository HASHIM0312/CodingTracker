using Microsoft.Data.Sqlite;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodingTracker
{
    public class CodingController
    {
        public void AddCodingSession(CodingLogsDatabase db)
        {
            string? name = AnsiConsole.Ask<string>("Enter name of log: ");
            var r = new Regex("^([0][1-9]|[1][0-2])[-.\\/]([0][1-9]|[1-2][0-9]|[3][0-1])[-.\\/]([0-9]{4}) ([0-1][0-9]|[2][0-4]):([0-5][0-9]):([0-5][0-9])$");

            string? startTime = AnsiConsole.Ask<string>("Enter the start time (mm/dd/yyyy HH:MM:SS): ");
            while (!r.IsMatch(startTime))
            {
                startTime = AnsiConsole.Ask<string>("Enter a valid input for the start time (mm/dd/yyyy HH:MM:SS): ");
            }
            string? endTime = AnsiConsole.Ask<string>("Enter the end time (mm/dd/yyyy HH:MM:SS): ");
            while (!r.IsMatch(endTime))
            {
                endTime = AnsiConsole.Ask<string>("Enter a valid input for the end time (mm/dd/yyyy HH:MM:SS): ");
            }
            double duration = Math.Round(CalculateDuration(startTime, endTime), 2, MidpointRounding.AwayFromZero);

            CodingSession newSession = new CodingSession(name, startTime, endTime, duration);

            db.AddLog(newSession);
        }

        public void DeleteCodingSession(CodingLogsDatabase db)
        {
            int id = AnsiConsole.Ask<int>("Enter the id of the session you want to delete: ");
            db.DeleteLog(id);
        }

        public void ReviewCodingSessions(CodingLogsDatabase db)
        {
            db.ReviewLogs();
            AnsiConsole.MarkupLine("[bold green]Press any key to continue...[/]");
            Console.ReadKey();
        }

        private static double CalculateDuration(string startTime, string endTime)
        {
            DateTime start_ = DateTime.Parse(startTime);
            DateTime end_ = DateTime.Parse(endTime);

            TimeSpan timeSpan = end_ - start_;
            double duration = (double)timeSpan.TotalHours;

            return duration;
        }
    }
}
