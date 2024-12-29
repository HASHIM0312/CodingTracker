using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodingTracker
{
    public class CodingSession
    {
        int id {  get; set; }
        public string name { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public double duration { get; set; }

        public CodingSession(string name_, string startTime_, string endTime_, double duration_)
        {
            name = name_;
            startTime = startTime_;
            endTime = endTime_;
            duration = duration_;
        }
    }
}
