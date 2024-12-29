using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingTracker.Models;
using Spectre.Console;
using Spectre.Console.Rendering;
using static CodingTracker.Enums;

namespace CodingTracker.Engines
{
    internal static class TableVisualizationEngine
    {
        private static Table table = new Table();

        public static void ShowLogs(List<CodingSession> logs)
        {
            MakeTable();
            AnsiConsole.Clear();

            foreach (CodingSession log in logs)
            {
                log.InsertLogIntoTable(table);
            }

            table.Border = new MinimalTableBorder();
            AnsiConsole.Write(table);
        }

        private static void MakeTable()
        {
            table = new Table();
            TableColumn idColumn = new TableColumn("ID");
            TableColumn nameColumn = new TableColumn("Name");
            TableColumn startDateColumn = new TableColumn("Start Date");
            TableColumn endDateColumn = new TableColumn("End Date");
            TableColumn durationColumn = new TableColumn("Duration");

            table.AddColumns(idColumn, nameColumn, startDateColumn, endDateColumn, durationColumn);
        }





    }
}
