using CodingTracker.Controllers;
using Spectre.Console;
using static CodingTracker.Enums;

namespace CodingTracker.Interfaces
{
    public class UserInterface
    {
        CodingController controller = new CodingController();
        DatabaseController db = new DatabaseController();
        internal void MainMenu()
        {
            while (true)
            {

                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[bold green]What would you like to do?[/]");
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<Options>()
                        .AddChoices(Enum.GetValues<Options>())
                        .Title("Select an option")
                );
                switch (choice)
                {
                    case Options.AddLog:
                        controller.AddCodingSession(db);
                        break;
                    case Options.DeleteLog:
                        controller.DeleteCodingSession(db);
                        break;
                    case Options.ReviewChoices:
                        controller.ReviewCodingSessions(db);
                        break;
                    case Options.Quit:
                        return;
                }

            }
        }
    }
}
