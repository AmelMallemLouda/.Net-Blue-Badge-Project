﻿using BlueBadgeFinalProject.Data;
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
        public JunctionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateJunction(JunctionCreate model)
        {
            var entity = new Junction()
            {
                HotelId = model.HotelId,
                CustomerId = model.CustomerId,
                ReviewId=model.ReviewId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Junctions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<JunctionList> GetAllJunctions()
        {
            using (var ctx= new ApplicationDbContext())
            {
                var query = ctx.Junctions.Select(e => new JunctionList
                {
                    Id = e.Id,
                    CustomerId = e.CustomerId,
                    //CustomerList
                    Customers = new CustomerList()
                    {
                        CustomerId = e.CustomerId,
                        FullName = e.Customer.FirstName + " " + e.Customer.LastName,
                        //List<TransactionListItems>
                        Transactions = e.Customer.Transactions.Select(
                          z => new TransactionListItem
                          {
                              TransactionId = z.TransactionId,
                              DateOfTransaction = z.DateOfTransaction,

                          }).ToList(),


                    },
                    HotelId=e.HotelId,
                    //HotelList
                    Hotels =new HotelList()
                    {
                        HotelId=e.HotelId,
                        Name=e.Hotel.HotelName,
                        //List<VacationPackagesListItems>
                        VacationPackages = e.Hotel.VacationPackages.Select(
                          z => new VacationPackageListItem
                          {
                              VacId = z.VacId,
                              Price = z.Price,
                              VacPacName=z.VacationPackageName

                          }).ToList()         
                    },
                    ReviewId=e.ReviewId,
                    //ReviewList
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

        public bool DeleteJunction(int hotelCustomerId)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = ctx.Junctions.Single(e => e.Id == hotelCustomerId);
                ctx.Junctions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
                    
        }
    }
}
