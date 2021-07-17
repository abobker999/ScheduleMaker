using ScheduleMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaker.Repository
{
    public class GetData : IGetData
    {
        public ScheduleDBContext _contest;
        public GetData(ScheduleDBContext contest)
        {
            _contest = contest;
        }
        public IQueryable<Schedule> GetSchedule(Guid DoctorId)
        {
            return (IQueryable<Schedule>)_contest.schedules
                 .Where(w => w.DoctorId == DoctorId)
                 .Select(s => new Schedule() { SessionDate = s.SessionDate, SessionInperiod = s.SessionInperiod, Period = s.Period })
                 .GroupBy(g => g.SessionDate)
                 .OrderBy(key => key.Key).ToList();
        }
        public Guid GetDoctorId(string doctorName)
        {
            return _contest.doctors
                .Where(where => where.DoctorNme == doctorName)
                .Select(select =>select.DoctorId ).FirstOrDefault();
        }
        public List<Doctor> GetDoctorList()
        {
            return _contest.doctors
                .Select(select => new Doctor() { DoctorNme = select.DoctorNme, DoctorId = select.DoctorId }).ToList();
        }
        public Period GetPeriod ()
        {
            return _contest.periods
                .Select(s => new Period()
                {
                    FirstPeriodBegin = s.FirstPeriodBegin,
                    FirstPeriodEnd = s.FirstPeriodEnd,
                    SecondPeriodEnd = s.SecondPeriodEnd,
                }).FirstOrDefault();
        }
    }
}
