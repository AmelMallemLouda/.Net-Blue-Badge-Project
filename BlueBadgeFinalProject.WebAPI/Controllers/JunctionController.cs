using BlueBadgeFinalProject.Models.HotelCustomer;
using BlueBadgeFinalProject.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadgeFinalProject.WebAPI.Controllers
{
    public class JunctionController : ApiController
    {
        private JunctionService CreateJunctionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var junctionService = new JunctionService(userId);
            return junctionService;
        }
        public IHttpActionResult Get()
        {
            JunctionService junctionService = CreateJunctionService();
            var junctions = junctionService.GetAllJunctions();
            return Ok(junctions);
        }
        public IHttpActionResult Post(JunctionCreate junction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateJunctionService();
            if (!service.CreateJunction(junction))
                return InternalServerError();
            return Ok("The junction has been created.");
        }
        public IHttpActionResult Delete(int junctionId)
        {
            var service = CreateJunctionService();

            if (!service.DeleteJunction(junctionId))
                return InternalServerError();

            return Ok("The junction has been deleted.");
        }
    }
}
