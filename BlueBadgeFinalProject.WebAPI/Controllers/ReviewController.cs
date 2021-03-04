using BlueBadgeFinalProject.Models.ReviewModles;
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
        private ReviewService CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var reviewService = new ReviewService(userId);
            return reviewService;
        }

        public IHttpActionResult Post(ReviewCreate review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReviewService();

            if (!service.CreateReview(review))
                return InternalServerError();

            return Ok("Your review has been successfully created!");
        }

        public IHttpActionResult Get()
        {
            ReviewService reviewService = CreateReviewService();
            var reviews = reviewService.GetReviews();
            return Ok(reviews);
        }

        [Route("api/Review/{reviewId}")]
        public IHttpActionResult Get(int reviewId)
        {
            ReviewService reviewService = CreateReviewService();
            var review = reviewService.GetReviewById(reviewId);
            return Ok(review);
        }

        public IHttpActionResult Put(ReviewEdit review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReviewService();

            if (!service.UpdateReview(review))
                return InternalServerError();

            return Ok("Your review has been successfully updated!");
        }

        [Route("api/Review/{reviewId}")]
        public IHttpActionResult Delete(int reviewId)
        {
            var service = CreateReviewService();

            if (!service.DeleteReview(reviewId))
                return InternalServerError();

            return Ok("Your review has been deleted!");
        }
    }
}
