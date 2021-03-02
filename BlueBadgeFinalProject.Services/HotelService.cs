﻿using BlueBadgeFinalProject.Data;
using BlueBadgeFinalProject.Models;
using BlueBadgeFinalProject.Models.CustomerFolder;
using BlueBadgeFinalProject.Models.HotelModels;
using BlueBadgeFinalProject.Models.ReviewModels;
using BlueBadgeFinalProject.Models.TransactionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Services
{
   public class HotelService
    {
        private readonly Guid _UserId;
        public HotelService(Guid userId)
        {
            _UserId = userId;
        }

        //Create an instance of Hotel
        public bool CreateHotel(HotelCreate hotel)
        {
            var entity = new Hotel()
            {
                OwnerId = _UserId,
                HotelName = hotel.Name,
                Location = hotel.Location,
                HasFreeParking = hotel.HasFreeParking

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Hotels.Add(entity);
                return ctx.SaveChanges() == 1;
            }


        }
        //Display all Hotels
        public IEnumerable<HotelList> GetHotels()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Hotels.Where(e => e.OwnerId == _UserId)
                    .Select(e => new HotelList
                    {
                        HotelId = e.HotelId,
                        Name = e.HotelName,
                        Customers = e.Customers.Select(
                            x => new CustomerList
                            {
                                CustomerId = x.CustomerId,
                                FullName = x.FirstName + " " + x.LastName,
                                Transactions = x.Transactions.Select(
                          z => new TransactionListItem
                          {
                              TransactionId = z.TransactionId,
                              DateOfTransaction = z.DateOfTransaction,
  
                          }).ToList(),
                            }).ToList(),

                             VacationPackages = e.VacationPackages.Select(
                            y => new VacationPackageListItem
                            {
                                VacId = y.VacId,
                                Price = y.Price,
                                VacPacName = y.VacationPackageName,
                            }).ToList(),

                             Reviews=e.Reviews.Select(
                                 w=> new ReviewListItem
                                 {
                                     Rating=w.Rating,
                                     ReviewId=w.ReviewId,
                                     DateOfReview=w.DateOfReview,
                                    
                                 }).ToList()
   
                    }) ;
  
                return query.ToArray();
            }

        }


        public HotelDetails GetHotelByID(int Id)
        {
    
                using (var ctx = new ApplicationDbContext())
                {
                    var entity = ctx.Hotels.Single(e => e.HotelId == Id && e.OwnerId == _UserId);
                    return new HotelDetails
                    {
                        HotelId = entity.HotelId,
                        HotelName = entity.HotelName,
                        Location=entity.Location,
                        HasFreeParking=entity.HasFreeParking,
   
                        Customers = entity.Customers.Select(
                            x => new CustomerList
                            {
                                CustomerId = x.CustomerId,
                                FullName = x.FirstName + " " + x.LastName,
                                Transactions = x.Transactions.Select(
                          z => new TransactionListItem
                          {
                              TransactionId = z.TransactionId,
                              DateOfTransaction = z.DateOfTransaction,
  
                          }).ToList(),
                            }).ToList(),

                        VacationPackages = entity.VacationPackages.Select(
                            y => new VacationPackageListItem
                            {
                                VacId = y.VacId,
                                Price = y.Price,
                                VacPacName = y.VacationPackageName,
                            }).ToList(),

                        Reviews = entity.Reviews.Select(
                                 w => new ReviewListItem
                                 {
                                     Rating = w.Rating,
                                     ReviewId = w.ReviewId,
                                     DateOfReview = w.DateOfReview,
                                     
                                 }).ToList()


                    };

                }
        }

        public bool UpdateHotel(HotelEdit hotel)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Hotels.Single(e => e.HotelId ==hotel.HotelId && e.OwnerId == _UserId);
                entity.HotelId = hotel.HotelId;
                entity.HotelName = hotel.Name;
                entity.Location = hotel.Location;
                entity.HasFreeParking = hotel.HasFreeParking;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteHotel(int hotelId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Hotels.Single(e => e.HotelId == hotelId && e.OwnerId == _UserId);
                ctx.Hotels.Remove(entity);

                return ctx.SaveChanges() == 1;
            }


        }

    }
}
