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
        public void AddLog(string? name_, string? date_, string? startTime_, float? duration_)
        {
            var sql = "INSERT INTO Logs (name, date, startTime, duration) VALUES (@name, @date, @startTime, @duration)";
            object[] param = { new { name = name_, date = date_, startTime = startTime_, duration = duration_ }};
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
                AnsiConsole.MarkupLine($"Id: {log.Id}, Name: {log.name}, Date: {log.date}, Start Time: {log.startTime}, Duration: {log.duration}");
            }
        }

        //Update a coding session


        //Quit the application
        public void Quit()
        {
            AnsiConsole
                .MarkupLine("[bold red]Goodbye![/]");
                
        }

        }
}
