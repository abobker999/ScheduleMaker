using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaker.Models
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public DateTime SessionDate { get; set; }
        public string SessionInperiod { get; set; }
        public string Period { get; set; }
        public Guid DoctorId { get; set;}
        public Doctor Doctor { get; set;}
        
    }
}
