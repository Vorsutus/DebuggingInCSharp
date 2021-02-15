using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownfieldLibrary
{
    public class TimeSheetEntry
    {
        //these should NOT be variables, they should be public auto properties
        //these we can't BIND to variables
        //public string WorkDone;
        //public double WorkedHours;

        //we CAN bind to public properties
        public string WorkDone { get; set; }
        public double WorkedHours { get; set; }
    }
}
