using BlueBadgeFinalProject.Data;
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
                CustomerId = model.CustomerId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
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
