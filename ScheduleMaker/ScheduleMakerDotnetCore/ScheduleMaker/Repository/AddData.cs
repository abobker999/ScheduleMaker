using ScheduleMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaker.Repository
{
    public class AddData : IAddData
    {
        public ScheduleDBContext _context;
        public AddData(ScheduleDBContext context)
        {
            _context = context;
        }
        public bool AddsSchedules(List<Schedule> schedules)
        {
            try
            {
                _context.AddRangeAsync(schedules);
                _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public bool AddDoctor(Doctor doctor)
        {
            try
            {
                //chech if it exsist;
                bool result = chech(doctor.DoctorNme);
                if (result)
                {
                    _context.doctors.Add(doctor);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }
        private bool chech(string doctorNme)
        {              
            return _context.doctors.Any(name => name.DoctorNme == doctorNme);
        }
        public bool AddPeriod(Period period)
        {
            try
            {
                    _context.periods.Add(period);
                    _context.SaveChanges();

                    return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
