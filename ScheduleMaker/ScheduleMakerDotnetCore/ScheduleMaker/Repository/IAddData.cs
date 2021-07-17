using ScheduleMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaker.Repository
{
   public interface IAddData
    {
        bool AddsSchedules(List<Schedule> schedules);
        bool AddDoctor(Doctor doctor);
        //
        bool AddPeriod(Period period);
    }
}
