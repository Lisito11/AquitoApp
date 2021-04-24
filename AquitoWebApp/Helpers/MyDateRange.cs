using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoWebApp.Helpers {
    public class MyDateRange {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public MyDateRange(DateTime start, DateTime end) {
            Start = start;
            End = end;
        }

        public bool WithInRange(DateTime value) {
            return (Start <= value) && (value <= End);
        }

        public bool WithInRange(IRange<DateTime> range) {
            return (Start <= range.Start) && (range.End <= End);
        }
    }
}
