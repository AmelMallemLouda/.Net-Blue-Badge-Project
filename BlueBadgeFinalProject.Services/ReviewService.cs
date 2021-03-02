using BlueBadgeFinalProject.Data;
using BlueBadgeFinalProject.Models.ReviewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Services
{
    public class ReviewService
    {
        private readonly Guid _userId;

        public ReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReview(ReviewCreate review)
        {
            var entity =
                new Review()
                {
                    OwnerId = _userId,
                    Text = review.Text,
                    Rating = review.Rating,
                    HotelId=review.HotelId,
                    DateOfReview = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reviews
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ReviewListItem
                                {
                                    ReviewId = e.ReviewId,
                                    Rating = e.Rating,
                                    DateOfReview = e.DateOfReview,                           
                                }
                        );

                return query.ToArray();
            }
        }

        public ReviewDetail GetReviewById(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == reviewId && e.OwnerId == _userId);
                return
                    new ReviewDetail
                    {
                        ReviewId = entity.ReviewId,
                        Text = entity.Text,
                        Rating = entity.Rating,
                        DateOfReview = entity.DateOfReview,
                        HotelId=entity.HotelId
                    };
            }
        }

        public bool UpdateReview(ReviewEdit review)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == review.ReviewId && e.OwnerId == _userId);

                entity.ReviewId = review.ReviewId;
                entity.Text = review.Text;
                entity.Rating = review.Rating;
                entity.HotelId = review.HotelId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == reviewId && e.OwnerId == _userId);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
