using CureWellProject.DAL;
using CureWellProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Web.Http;

namespace CureWellProject.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DoctorSpecializationController : ApiController
    {
        private readonly DoctorSpecializationServices doctorSpecializationServices;
        public DoctorSpecializationController()
        {
            doctorSpecializationServices = new DoctorSpecializationServicesImpl();
        }
        [HttpGet]
        public IHttpActionResult Get(string specializationCode)
        {
            try
            {
                var data = doctorSpecializationServices.GetDoctorsBySpecializations(specializationCode);
                if (data == null || data.Count() == 0)
                {
                    return Content(HttpStatusCode.NotFound, data);
                }
                return Ok(data);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, false);
            }
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody] DoctorSpecialization doctorSpecialization)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, false);
            }
            try
            {
                var data = doctorSpecializationServices.AddDoctorSpecialization(doctorSpecialization);
                if (data == false)
                {
                    return Content(HttpStatusCode.NotFound, data);
                }
                return Ok(data);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, false);
            }
        }
    }
}
