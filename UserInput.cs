using Spectre.Console;
using static CodingTracker.Enums;

namespace CodingTracker
{
    public class UserInput
    {
        CodingController controller = new CodingController();
        CodingLogsDatabase db = new CodingLogsDatabase();
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
                    case (Options.AddLog):
                        controller.AddCodingSession(db);
                        break;
                    case (Options.DeleteLog):
                        controller.DeleteCodingSession(db);
                        break;
                    case (Options.ReviewChoices):
                        controller.ReviewCodingSessions(db);
                        break;
                    case (Options.Quit):
                        db.Quit();
                        break;
                }

            }
        }
    }
}
