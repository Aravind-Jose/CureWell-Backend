using CureWellProject.DAL;
using CureWellProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CureWellProject.Controllers
{
    public class DoctorController : ApiController
    {
        private readonly DoctorService doctorRepository;
        public DoctorController()
        {
            doctorRepository = new DoctorServicesImpl();
        }
        public IHttpActionResult Get()
        {
            var data = doctorRepository.GetAllDoctors();
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Doctor d)
        {
            var data = doctorRepository.AddDoctor(d);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var data = doctorRepository.DeleteDoctor(id);
            return Ok(data);
        }
        [HttpPut]
        public IHttpActionResult Put(Doctor d)
        {
            var data = doctorRepository.UpdateDoctorDetails(d);
            return Ok(data);
        }
    }
}
