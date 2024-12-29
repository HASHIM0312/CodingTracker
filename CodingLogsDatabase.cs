using Dapper;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    public class CodingLogsDatabase
    {
        SQLiteConnection connection;
        public CodingLogsDatabase()
        {
            string? connnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            // Create a new SQLite database
            connection = new SQLiteConnection(connnectionString);
            connection.Execute("CREATE TABLE IF NOT EXISTS Logs (Id INTEGER PRIMARY KEY, name TEXT, startTime TEXT, endTime TEXT, duration DECIMAL)");
        }



        //Add a coding session
        public void AddLog(CodingSession log)
        {

            string? name_ = log.name;
            string? startTime_ = log.startTime;
            string? endTime_ = log.endTime;
            double? duration_ = log.duration;

            var sql = "INSERT INTO Logs (name, startTime, endTime, duration) VALUES (@name, @startTime, @endTime, @duration)";
            object[] param = { new { name = name_, startTime = startTime_, endTime = endTime_, duration = duration_ }};
            connection.Execute(sql, param);
        }

        //Delete a coding session
        public void DeleteLog(int id)
        {
            var sql = "DELETE FROM Logs WHERE Id = @id";
            object[] param = { new { id = id } };
            connection.Execute(sql, param);
        }
        //Review coding sessions
        public void ReviewLogs()
        {
            AnsiConsole.Clear();

            var sql = "SELECT * FROM Logs";
            var logs = connection.Query(sql);
            foreach (var log in logs)
            {
                if (log.duration == 1)
                {
                    AnsiConsole.MarkupLine($"Id: {log.Id}, Name: {log.name}, Start Time: {log.startTime}, End Time: {log.endTime}, Duration: {log.duration} hours");
                }
                else
                {
                    AnsiConsole.MarkupLine($"Id: {log.Id}, Name: {log.name}, Start Time: {log.startTime}, End Time: {log.endTime}, Duration: {log.duration} hour");
                }
            }
        }

        //Quit the application
        public void Quit()
        {
            AnsiConsole
                .MarkupLine("[bold red]Goodbye![/]");
        }

    }
}
