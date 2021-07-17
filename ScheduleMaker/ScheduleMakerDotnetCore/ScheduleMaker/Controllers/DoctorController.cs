using Microsoft.AspNetCore.Mvc;
using ScheduleMaker.Models;
using ScheduleMaker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaker.Controllers
{
    public class DoctorController : Controller
    {
        public IAddData _addData;
        public IGetData _getData;
        public Doctor doctor;
        public DoctorController(IAddData addData, IGetData getData)
        {
            _addData = addData;
            _getData = getData;
        }
        [Route("api/[Controller]")]
        [HttpPost]
        /// add new doctor
        public ActionResult AddDcotor(string doctorName)
        {

            doctor = new Doctor()
            {
                DoctorId = Guid.NewGuid(),
                DoctorNme = doctorName
            };
            var result = _addData.AddDoctor(doctor);
            if (result)
            {
                return Ok("Adding Success");
            }
            else
            {
                return Ok("this dotor is alredy exist");
            }
        }
        [Route("api/[Controller]")]
        [HttpGet]
        public ActionResult GetAllDoctor()
        {      // get all the doctor     
            return Ok(_getData.GetDoctorList());
        }
    }
}
