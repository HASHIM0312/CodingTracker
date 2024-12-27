// See https://aka.ms/new-console-template for more information/
using System.Configuration;
using Spectre.Console;
using System.Text.RegularExpressions;
using System.Data.SQLite;
using Dapper;
using CodingTracker;


AnsiConsole.MarkupLine("[bold red]Welcome to Coding Tracker![/]");
CodingLogsDatabase db = new CodingLogsDatabase();

while (true)
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold green]What would you like to do?[/]");
    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .AddChoices(new[] { "Add a coding session", "Delete a coding session", "Review coding sessions", "Quit" })
            .Title("Select an option")
    );

    if (choice == "Add a coding session")
    {
        string? name = AnsiConsole.Ask<string>("Enter name of log: ");
        string? date = AnsiConsole.Ask<string>("Enter the start time: ");
        string? startTime = AnsiConsole.Ask<string>("Enter the end time: ");
        float? duration = 
        db.AddLog(name, date, startTime, duration);
    }
    else if (choice == "Delete a coding session")
    {
        int id = AnsiConsole.Ask<int>("Enter the id of the session you want to delete: ");
        db.DeleteLog(id);
    }
    else if (choice == "Review coding sessions")
    {
        db.ReviewLogs();
        AnsiConsole.MarkupLine("[bold green]Press any key to continue...[/]");
        Console.ReadKey();
    }
    else if (choice == "Quit")
    {
        db.Quit();
        break;
    }

}



