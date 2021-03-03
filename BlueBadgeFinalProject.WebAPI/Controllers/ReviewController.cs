using BlueBadgeFinalProject.Models.Review;
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
    public class ReviewController : ApiController
    {
        [HttpPost]
        public IHttpActionResult PostReview(ReviewCreate model)
        {
            var reviewService = CreateReviewService();
            if (!reviewService.CreateReview(model))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAllReviews()
        {
            var reviewService = CreateReviewService();
            var reviews = reviewService.GetAllReviews();
            return Ok(reviews);
        }

        [HttpDelete]
        public IHttpActionResult DeleteReview([FromUri] int hotelId, [FromUri] int reviewId) 
        {
            var service = CreateReviewService();
            if (service.DeleteReview(hotelId,reviewId))
                return Ok();

            return InternalServerError();
        }

        private ReviewService CreateReviewService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            return service;
        }
    }
}
