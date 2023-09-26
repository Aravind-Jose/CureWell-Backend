using CureWellProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CureWellProject.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SpecializationController : ApiController
    {
        private readonly SpecializationServices specializationServices;
        public SpecializationController()
        {
            specializationServices = new SpecializationServicesImpl();
        }
        public IHttpActionResult Get()
        {
            try
            {
                var data = specializationServices.GetAllSpecializations();
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
    }
}
