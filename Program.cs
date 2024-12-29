// See https://aka.ms/new-console-template for more information/
using System.Configuration;
using Spectre.Console;
using System.Text.RegularExpressions;
using System.Data.SQLite;
using Dapper;
using CodingTracker;



AnsiConsole.MarkupLine("[bold red]Welcome to Coding Tracker![/]");

UserInput ui = new UserInput();
ui.MainMenu();