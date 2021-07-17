using Microsoft.AspNetCore.Mvc;
using ScheduleMaker.Models;
using ScheduleMaker.SchedulingOprations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaker.Controllers
{
    public class DoScheduleController : Controller
    {
        public IScheduling _scheduling;
        public DoScheduleController(IScheduling scheduling )
        {
            _scheduling = scheduling;
        }
        [Route("api/[Controller]")]
        [HttpPost]
        public ActionResult Doschedule([FromBody]FormData formData)
        {          
            var result = _scheduling.ScheduleData(formData);
            return Ok(result);
        }

    }
}
