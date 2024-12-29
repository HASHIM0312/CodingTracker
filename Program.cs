// See https://aka.ms/new-console-template for more information/
using CodingTracker;
using Spectre.Console;



AnsiConsole.MarkupLine("[bold red]Welcome to Coding Tracker![/]");

UserInput ui = new UserInput();
ui.MainMenu();