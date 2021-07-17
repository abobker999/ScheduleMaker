using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaker.Models
{
    /// <summary>
    /// this modeel to resive the data to create the schedule
    /// </summary>
    public class FormData
    {
        
        public DateTime startDate{get;set;}
        public DateTime endDate {get;set;}
        public string doctorName {get;set;}     
        public int restBetweenPeriod { get; set; }
        public int sessionTime { get; set; }
        public int WatingTime { get; set; }

    }
}
