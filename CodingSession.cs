namespace CodingTracker
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
    }
}
