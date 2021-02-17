﻿using BlueBadgeFinalProject.Data;
using BlueBadgeFinalProject.Models;
using BlueBadgeFinalProject.Models.TransactionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Services
{
   public class TransactionService
   {
        private readonly Guid _userId;

        public TransactionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTransaction(TransactionCreate model)
        {
            var entity =
                new Transaction()
                {
                    OwnerId = _userId,
                    Price = model.Price,
                    DateOfTransaction = DateTime.Now,
                    CustomerName = model.CustomerName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Transactions
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TransactionListItem
                                {
                                    TransactionId = e.TransactionId,
                                    DateOfTransaction = e.DateOfTransaction,
                                    Price = e.Price,
                                    CustomerName = e.CustomerName
                                }
                        );

                return query.ToArray();
            }
        }

        public TransactionDetail GetTransactionById(int transactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId == transactionId && e.OwnerId == _userId);
                return
                    new TransactionDetail
                    {
                        TransactionId = entity.TransactionId,
                        CustomerName = entity.CustomerName,
                        Price = entity.Price,
                        DateOfTransaction = entity.DateOfTransaction
                    };
            }
        }

        public bool UpdateTransaction(TransactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId == model.TransactionId && e.OwnerId == _userId);

                entity.TransactionId = model.TransactionId;
                entity.Price = model.Price;
                entity.CustomerName = model.CustomerName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int transactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId == transactionId && e.OwnerId == _userId);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
   }
}