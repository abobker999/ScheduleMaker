using ScheduleMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaker.SchedulingOprations
{
    public interface IScheduling
    {
        bool ScheduleData(FormData formData);
        
    }
}
