using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                    new SelectionPrompt<string>()
                        .AddChoices(new[] { "Add a coding session", "Delete a coding session", "Review coding sessions", "Quit" })
                        .Title("Select an option")
                );

                if (choice == "Add a coding session")
                {
                    controller.AddCodingSession(db);
                }
                else if (choice == "Delete a coding session")
                {
                    controller.DeleteCodingSession(db);
                }
                else if (choice == "Review coding sessions")
                {
                   controller.ReviewCodingSessions(db);
                }
                else if (choice == "Quit")
                {
                    db.Quit();
                    break;
                }

            }

        }
        
        

        
    }
}
