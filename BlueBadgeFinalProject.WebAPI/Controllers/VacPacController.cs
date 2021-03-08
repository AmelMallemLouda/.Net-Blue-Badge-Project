using BlueBadgeFinalProject.Models;
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
    [Authorize]
    public class VacPacController : ApiController
    {
        private VacationPackageService CreateVacPacService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var vacService = new VacationPackageService(userId);
            return vacService;
        }

        public IHttpActionResult Get()
        {
            VacationPackageService vacService = CreateVacPacService();
            var vacPacs = vacService.GetVacPacs();
            return Ok(vacPacs);
        }
        public IHttpActionResult Post(VacationPackageCreate vacpac)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateVacPacService();
            if (!service.CeateVacationPackage(vacpac))
                return InternalServerError();
            return Ok("The vacation package has been created.");
        }

        public IHttpActionResult Get(int id)
        {
            VacationPackageService vacService = CreateVacPacService();
            var vac = vacService.GetVacPacsById(id);
            return Ok(vac);
        }

        public IHttpActionResult Put(VacationEdit vacPac)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVacPacService();

            if (!service.UpdateVacPac(vacPac))
                return InternalServerError();

            return Ok("The vacation package has been updated");
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateVacPacService();

            if (!service.DeleteVacPac(id))
                return InternalServerError();

            return Ok("The vacation package has been deleted");
        }
    }
}
