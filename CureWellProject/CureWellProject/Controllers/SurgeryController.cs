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
    public class SurgeryController : ApiController
    {
        private readonly SurgerySevices surgerySevices;
        public SurgeryController()
        {
            surgerySevices = new SurgeryServicesImpl();
        }
        public IHttpActionResult Get()
        {
            try
            {
                var data = surgerySevices.GetAllSurgeryTypeForToday();
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
        [HttpPut]
        public IHttpActionResult Put([FromBody] Surgery surgery)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Content(HttpStatusCode.BadRequest, false);
                }
                var data = surgerySevices.UpdateSurgery(surgery);
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
