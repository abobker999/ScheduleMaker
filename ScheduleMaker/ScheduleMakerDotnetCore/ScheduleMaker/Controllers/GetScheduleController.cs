using Microsoft.AspNetCore.Mvc;
using ScheduleMaker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaker.Controllers
{
    public class GetScheduleController : Controller
    {
        public IGetData _getDate;
        public GetScheduleController(IGetData getData)
        {
            _getDate = getData;
        }
        [Route("api/[Controller]")]
        [HttpPost]
        public ActionResult GetSchedule([FromBody]string doctorName)
        {
            var doctorId = _getDate.GetDoctorId(doctorName);          
            var Schedule=_getDate.GetSchedule(doctorId);
            if (Schedule.Count()>0)
            {
                return Ok(Schedule);
            }
            else
            {
                return Ok("this doctor have no Schedule");
            }          
            
        }
    }
}
