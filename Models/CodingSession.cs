using Spectre.Console;

namespace CodingTracker.Models
{
    public class CodingSession
    {
        public long id { get; set; }
        public string name { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public double duration { get; set; }

        public CodingSession() { }

        public CodingSession(string name_, string startTime_, string endTime_, double duration_)
        {
            name = name_;
            startTime = startTime_;
            endTime = endTime_;
            duration = duration_;
        }


        public void InsertLogIntoTable(Table table)
        {
            //ID Panel
            Panel idPanel = new Panel(id.ToString());



            //Name Panel
            Panel namePanel = new Panel(name);

            //Start Time Panel
            Panel startTimePanel = new Panel(startTime);

            //End Time Panel
            Panel endTimePanel = new Panel(endTime);

            //Duration Panel
            Panel durationPanel = new Panel(duration.ToString() + "hour(s)");

            table.AddRow(idPanel, namePanel, startTimePanel, endTimePanel, durationPanel);

        }


    }
}
