using BlueBadgeFinalProject.Data;
using BlueBadgeFinalProject.Models;
using BlueBadgeFinalProject.Models.CustomerFolder;
using BlueBadgeFinalProject.Models.HotelCustomer;
using BlueBadgeFinalProject.Models.HotelModels;
using BlueBadgeFinalProject.Models.ReviewModles;
using BlueBadgeFinalProject.Models.TransactionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Services
{
    public class JunctionService
    {

        private readonly Guid _userId;
        public  JunctionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateHotelCustomer(JunctionCreate model)
        {
            var entity = new Junction()
            {
                HotelId = model.HotelId,
                CustomerId = model.CustomerId,
                ReviewId=model.ReviewId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.HotelCustomers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<JunctionList> GetAllHotelCustomers()
        {
            using (var ctx= new ApplicationDbContext())
            {
                var query = ctx.HotelCustomers.Select(e => new JunctionList
                {
                    Id = e.Id,
                    CustomerId = e.CustomerId,
                    Customers = new CustomerList()
                    {
                        CustomerId = e.CustomerId,
                        FullName = e.Customer.FirstName + " " + e.Customer.LastName,
                        Transactions=e.Customer.Transactions.Select(
                          z => new TransactionListItem
                          {
                              TransactionId = z.TransactionId,
                              DateOfTransaction = z.DateOfTransaction,

                          }).ToList(),


                    },
                    HotelId=e.HotelId,
                    Hotels=new HotelList()
                    {
                        HotelId=e.HotelId,
                        Name=e.Hotel.HotelName,
                        VacationPackages=e.Hotel.VacationPackages.Select(
                          z => new VacationPackageListItem
                          {
                              VacId = z.VacId,
                              Price = Double.Parse(z.Price),
                              VacPacName=z.VacationPackageName

                          }).ToList()         
                    },
                    ReviewId=e.ReviewId,
                    Review= new ReviewListItem()
                    {
                        ReviewId=e.ReviewId,
                        Rating=e.Review.Rating,
                        DateOfReview=e.Review.DateOfReview
                    }

                });
                return query.ToArray();
            }
        }

        public bool DeleteHotelCustomer(int hotelCustomerId)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = ctx.HotelCustomers.Single(e => e.Id == hotelCustomerId);
                ctx.HotelCustomers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
                    
        }
    }
}
