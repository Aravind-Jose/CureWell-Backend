using CureWellProject.DAL;
using CureWellProject.Entity;
using Microsoft.AspNetCore.Cors;
using System.Web.Http.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Numerics;

namespace CureWellProject.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DoctorController : ApiController
    {
        
        private readonly DoctorService doctorRepository;
        public DoctorController()
        {
            doctorRepository = new DoctorServicesImpl();
        }
        public IHttpActionResult Get()
        {
            try
            {
                var data = doctorRepository.GetAllDoctors();
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
        public IHttpActionResult Post([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var data = doctorRepository.AddDoctor(doctor);
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
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var data = doctorRepository.DeleteDoctor(id);
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
        [HttpPut]
        public IHttpActionResult Put([FromBody] Doctor doctor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Content(HttpStatusCode.BadRequest, false);
                }
                var data = doctorRepository.UpdateDoctorDetails(doctor);
                if (data == false)
                {
                    return Content(HttpStatusCode.NotFound, data);
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, false);
            }
            
        }
    }
}
