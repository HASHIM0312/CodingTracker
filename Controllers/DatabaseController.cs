using CodingTracker.Engines;
using CodingTracker.Models;
using Dapper;
using Spectre.Console;
using System.Configuration;
using System.Data.SQLite;

namespace CodingTracker.Controllers
{
    public class DatabaseController
    {

        SQLiteConnection connection;
        public DatabaseController()
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
            object[] param = { new { name = name_, startTime = startTime_, endTime = endTime_, duration = duration_ } };
            connection.Execute(sql, param);
        }

        //Delete a coding session
        public bool DeleteLog(int id)
        {
            bool result = false;
            var sql = "SELECT COUNT(*) FROM Logs";
            int count = connection.ExecuteScalar<int>(sql);
            if (count > 0)
            {
                result = true;
                sql = "DELETE FROM Logs WHERE Id = @id";
                object[] param = { new { id } };
                connection.Execute(sql, param);

                sql = @"UPDATE Logs SET id = id - 1 WHERE id > @id";
                connection.Execute(sql, param);
            }

            return result;
        }
        //Review coding sessions
        public List<CodingSession> GetLogs()
        {
            AnsiConsole.Clear();
            var sql = "SELECT * FROM Logs";
            List<CodingSession> logs = (List<CodingSession>)connection.Query<CodingSession>(sql);
            return logs;
        }

        public int GetLogCount()
        {
            var sql = "SELECT COUNT(*) FROM Logs";
            int count = connection.ExecuteScalar<int>(sql);
            return count;
        }

        //Quit the application
        public void Quit()
        {
            AnsiConsole
                .MarkupLine("[bold red]Goodbye![/]");
        }

    }
}
