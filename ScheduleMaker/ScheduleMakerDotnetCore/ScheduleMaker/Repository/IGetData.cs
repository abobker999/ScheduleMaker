using ScheduleMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaker.Repository
{
  public  interface IGetData
    {
        IQueryable<Schedule> GetSchedule(Guid DoctorId);
        Guid GetDoctorId(string doctorName);
        List<Doctor> GetDoctorList();
        Period GetPeriod();
    }
}
