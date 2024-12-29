using Spectre.Console;

namespace CodingTracker
{
    public class CodingController
    {
        public void AddCodingSession(CodingLogsDatabase db)
        {
            //Get vars for new coding session
            string? name = AnsiConsole.Ask<string>("Enter name of log (ESC to go back): ");
            (string startTime, string endTime) = GetDates();
            double duration = Math.Round(CalculateDuration(startTime, endTime), 2, MidpointRounding.AwayFromZero);

            //Insert coding session into db
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

        private static (string startTime, string endTime) GetDates()
        {
            string? officialStartTime = Validation.ValidStartDate();
            DateTime startTime = DateTime.Parse(officialStartTime);
            string? officialEndTime = Validation.ValidEndDate(startTime);

            return (officialStartTime, officialEndTime);
        }
    }
}
