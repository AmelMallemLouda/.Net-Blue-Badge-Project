using BlueBadgeFinalProject.Data;
using BlueBadgeFinalProject.Models.CustomerFolder;
using BlueBadgeFinalProject.Models.HotelModels;
using BlueBadgeFinalProject.Models.Review;
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

        public bool CreateReview(ReviewCreate model)
        {
            var entity = new Review()
            {
                HotelId = model.HotelId,
                CustomerId = model.CustomerId,
                Text=model.Text,
                Rating=model.Rating,
                DateOfReview=model.DateOfReview
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReviewListItem> GetAllReviews()
        {
            using(var ctx=new ApplicationDbContext())
            {
                var query = ctx.Reviews.Select(e => new ReviewListItem
                {
                    Id = e.ReviewId,
                    CustomerId = e.CustomerId,
                    Customers = new CustomerList
                    {
                        CustomerId = e.Customers.CustomerId,
                        FullName = e.Customers.FirstName + " " + e.Customers.LastName

                    },

                    HotelId=e.HotelId,
                    Hotels=new HotelList
                    {
                        HotelId=e.Hotels.HotelId,
                        Name=e.Hotels.HotelName,

                    }
                });
                return query.ToArray();
            }
        }

        public bool DeleteReview(int customerId, int hotelId)
        {
            using(var ctx=new ApplicationDbContext())
            {
                var entity = ctx.Reviews.SingleOrDefault(e => e.CustomerId == customerId && e.HotelId == hotelId);
                if(entity != null)
                {
                    ctx.Reviews.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }
        
    }
}
