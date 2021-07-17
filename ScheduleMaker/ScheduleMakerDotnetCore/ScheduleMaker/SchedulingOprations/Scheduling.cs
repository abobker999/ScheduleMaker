using ScheduleMaker.Models;
using ScheduleMaker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaker.SchedulingOprations
{
    public class Scheduling : IScheduling
    {
        public IAddData _addData;
        public IGetData _getData;
        public Scheduling(IAddData addData, IGetData getData)
        {
            _addData = addData;
            _getData = getData;
        }
        public List<Schedule> Schedules;
        public    bool ScheduleData(FormData formData)
        {
            var days = formData.endDate -formData.startDate ;
            var Period = _getData.GetPeriod();
            var DoctorId = _getData.GetDoctorId(formData.doctorName);

            // this commig tow togther create the schedule

            //mornig schedule 
            List<Schedule>Scadule= MorningShift(formData, days.Days,Period,DoctorId);
            //night schedule
            // note that i add the result from NightShift to  above list ;
            Scadule.AddRange(NightShift(formData, days.Days, Period, DoctorId));
            // add the result to dataBase
            return _addData.AddsSchedules(Scadule);
           
        }
        /// <summary>
        ///  this method used to calculat the mornig schadule;
        /// </summary>
        /// <param name="formData"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public List<Schedule> MorningShift(FormData formData, int days,Period period,Guid doctorId)
        {  

            //ok let us see what is going on here (:;
            // get when the first session in period will statrt;
            TimeSpan firestSessionStart = period.FirstPeriodBegin;
            // get when the last session in peeriod will end;
            TimeSpan lastSessionEnd = period.FirstPeriodEnd;
            // this to value  work during creating the schedule; 
            DateTime timetostart = new DateTime() + firestSessionStart;
            DateTime timetoend = new DateTime() + lastSessionEnd;

            //this method do the logical opration it tack the pramietr and creat the schadule acording to it
            this.Schedules = whilelob(formData, timetostart, timetoend, days,"Morning",doctorId);
           
            return Schedules;
        }
        /// <summary>
        /// this method used to calculat the night schadule;
        /// </summary>
        /// <param name="formData"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public List<Schedule> NightShift(FormData formData, int days, Period period, Guid doctorId)
        {
            //ok let us see what is going on here (:;
            // get when the first session in period will statrt;
            TimeSpan firestSessionStart = period.FirstPeriodBegin;
            // get when the last session in peeriod will end;
            TimeSpan lastSessionEnd = period.FirstPeriodEnd;

            //not that here will calculat the first session for this period acordind to restBetweenPeriod;

            // this to value  work during creating the schedule; 
            DateTime timetostart = new DateTime() + firestSessionStart;
            timetostart = timetostart.AddHours(formData.restBetweenPeriod);
            DateTime timetoend = new DateTime() + lastSessionEnd;
            // i do this  to mack the compare esey  couse 00:00 is unique case;
            timetoend = timetoend.AddDays(1);

          
            //ok let us see what is going on here;
            //this method do the logical opration it tack the pramietr and creat the schadule acording to it
            
            this.Schedules = whilelob(formData, timetostart, timetoend, days,"Night",doctorId);
            //return the  list all night schedule
            return Schedules;
        }       
        private List<Schedule> whilelob(FormData formData, DateTime timetostart, DateTime timetoend, int days ,string period,Guid doctorId)
        {
            List<Schedule> Schedules = new List<Schedule>();
            // this value to reset the time for everey day 
               var reset = timetostart;
            int incresDay = 0;
            while (days >= 1)
            {

                // if timetostart > timetoend the period must end. reset the timetostart and go to next day;
                //in increce the dotor day till the doctor day in scadul finsh;             
                if (timetostart.AddMinutes(formData.sessionTime + formData.WatingTime) > timetoend)
                {
                    timetostart = reset;
                    incresDay += 1;
                    days -= 1;
                }
                if (days != 0)
                {
                    // add scasul data to the list
                    Schedules.Add(new Schedule
                    {
                        Id = Guid.NewGuid(),
                        SessionDate = formData.startDate.AddDays(incresDay).AddHours(-formData.startDate.Hour+timetostart.Hour).AddMinutes(timetostart.Minute),
                        SessionInperiod = timetostart.Hour.ToString() + ":" + (timetostart.Minute).ToString(),
                        Period = period,
                        DoctorId=doctorId
                        
                        
                    }) ;
                    //the next session will start in this time           
                    timetostart = timetostart.AddMinutes(formData.sessionTime + formData.WatingTime);
                }


            }
            //return the  list all morning schedule
            return Schedules;
            
        }
    }
}
