using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaker
{
    public class Period
    {
        public Guid Id { get; set; }

        public TimeSpan FirstPeriodBegin { get; set; }
        public TimeSpan FirstPeriodEnd { get; set; }
        public TimeSpan SecondPeriodEnd { get; set; }
    }
}
