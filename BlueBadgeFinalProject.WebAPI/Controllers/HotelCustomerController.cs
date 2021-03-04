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
    public class HotelCustomerController : ApiController
    {
        private HotelCustomerService CreateHotelCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var HotelCustomerService = new HotelCustomerService(userId);
            return HotelCustomerService;
        }
        public IHttpActionResult Get()
        {
            HotelCustomerService hotelCustomerService = CreateHotelCustomerService();
            var hotelCustomers = hotelCustomerService.GetAllHotelCustomers();
            return Ok(hotelCustomers);
        }
        public IHttpActionResult Post(HotelCustomerCreate hotelCustomer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateHotelCustomerService();
            if (!service.CreateHotelCustomer(hotelCustomer))
                return InternalServerError();
            return Ok("The HotelCustomer has been created.");
        }
        public IHttpActionResult Delete(int hotelCustomerId)
        {
            var service = CreateHotelCustomerService();

            if (!service.DeleteHotelCustomer(hotelCustomerId))
                return InternalServerError();

            return Ok("The HotelCustomer has been deleted.");
        }
    }
}
