using CodingTracker.Engines;
using CodingTracker.Models;
using Spectre.Console;

namespace CodingTracker.Controllers
{
    public class CodingController
    {
        public void AddCodingSession(DatabaseController db)
        {
            //Get vars for new coding session
            string? name = AnsiConsole.Ask<string>("Enter name of log (ESC to go back): ");
            (string startTime, string endTime) = GetDates();
            double duration = Math.Round(CalculateDuration(startTime, endTime), 2, MidpointRounding.AwayFromZero);

            //Insert coding session into db
            CodingSession newSession = new CodingSession(name, startTime, endTime, duration);
            db.AddLog(newSession);
        }

        public void DeleteCodingSession(DatabaseController db)
        {
            if (db.GetLogCount() > 0)
            {
                //To show the user the logs
                List<CodingSession> logs = db.GetLogs();
                TableVisualizationEngine.ShowLogs(logs);

                //Delete session from DB
                int id = AnsiConsole.Ask<int>("Enter the id of the session you want to delete: ");
                db.DeleteLog(id);
            }
            else
            {
                AnsiConsole.MarkupLine("No logs present. Press ENTER to continue");
                Console.ReadKey();
            }
        }

        public void ReviewCodingSessions(DatabaseController db)
        {
            if (db.GetLogCount() > 0)
            {
                List<CodingSession> logs = db.GetLogs();
                TableVisualizationEngine.ShowLogs(logs);

                AnsiConsole.MarkupLine("[bold green]Press any key to continue...[/]");
                Console.ReadKey();
            }
            else
            {
                AnsiConsole.MarkupLine("No logs present. Press ENTER to continue");
                Console.ReadKey();
            }

        }

        private static double CalculateDuration(string startTime, string endTime)
        {
            DateTime start_ = DateTime.Parse(startTime);
            DateTime end_ = DateTime.Parse(endTime);

            TimeSpan timeSpan = end_ - start_;
            double duration = (double)timeSpan.TotalHours;

            return duration;
        }

        private static (string startTime, string endTime) GetDates()
        {
            string? officialStartTime = ValidationEngine.ValidStartDate();
            DateTime startTime = DateTime.Parse(officialStartTime);
            string? officialEndTime = ValidationEngine.ValidEndDate(startTime);

            return (officialStartTime, officialEndTime);
        }
    }
}
