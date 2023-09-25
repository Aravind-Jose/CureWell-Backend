using CureWellProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CureWellProject.Controllers
{
    public class SpecializationController : ApiController
    {
        private readonly SpecializationServices specializationServices;
        public SpecializationController()
        {
            specializationServices = new SpecializationServicesImpl();
        }
        public IHttpActionResult Get()
        {
            var data = specializationServices.GetAllSpecializations();
            return Ok(data);
        }
    }
}
