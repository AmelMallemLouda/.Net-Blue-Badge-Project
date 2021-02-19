using BlueBadgeFinalProject.Models.HotelModels;
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
    public class HotelController : ApiController
    {
        private HotelService CreateHotelService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var hotelService = new HotelService(userId);
            return hotelService;
        }

        public IHttpActionResult GetAllHotels()
        {
            HotelService hotelService = CreateHotelService();
            var hotels = hotelService.GetHotels();
            return Ok(hotels);
        }
        public IHttpActionResult Post([FromBody] HotelCreate hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            HotelService hotelService = CreateHotelService();
            if (!hotelService.CreateHotel(hotel))
                return InternalServerError();
            return Ok("The Hotel Was Successfully Created.");
        }

        //[Route("{api}/{hotel}/{Id}")]
        public IHttpActionResult GetHotelById([FromUri] int Id)
        {
            HotelService hotelService = CreateHotelService();
            var hotel = hotelService.GetHotelByID(Id);
            return Ok(hotel);
        }

        public IHttpActionResult Put(HotelEdit Hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateHotelService();
            if (!service.UpdateHotel(Hotel))
            {
                return InternalServerError();
            }
            return Ok("The Hotel Was successfully Updated.");
        }

        public IHttpActionResult Delete(int Id)
        {
            var service = CreateHotelService();
            if (!service.DeleteHotel(Id))
                return InternalServerError();
            return Ok("The hotel was successfully deleted.");
        }

    }
    


}
