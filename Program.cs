// See https://aka.ms/new-console-template for more information/
using CodingTracker.Interfaces;
using Spectre.Console;

AnsiConsole.MarkupLine("[bold red]Welcome to Coding Tracker![/]");

UserInterface ui = new UserInterface();
ui.MainMenu();