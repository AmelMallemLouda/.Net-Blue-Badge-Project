using BlueBadgeFinalProject.Data;
using BlueBadgeFinalProject.Models.CustomerFolder;
using BlueBadgeFinalProject.Models.TransactionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Services
{
    public class CustomerService
    {
        private readonly Guid _UserId;
        public CustomerService(Guid userId)
        {
            _UserId = userId;
        }

        //Create an Instance of customer

        public bool CeateCustomer(CustomerCreate customer)
        {
            var entity = new Customer()
            {
                OwnerId = _UserId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                EmailAddress = customer.EmailAddress,
            };

            using (var ctx=new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Get all Customers

        public IEnumerable<CustomerList> GetAllCustomers()
        {
            using (var ctx= new ApplicationDbContext())
            {
                var entity = ctx.Customers.Where(e => e.OwnerId == _UserId)
                    .Select(e => new CustomerList
                    {
                        FullName =e.FirstName + " " +e.LastName,
                        CustomerId = e.CustomerId,
                        Transactions = e.Transactions.Select(
                          z => new TransactionListItem
                          {
                              TransactionId = z.TransactionId,
                              DateOfTransaction = z.DateOfTransaction,
        
                          }).ToList(),
                    });

                return entity.ToArray();
            }
        }

        public CustomerDetails GetCustomerById(int customerId)
        {
            using(var ctx=new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(e => e.CustomerId == customerId && e.OwnerId == _UserId);
                return new CustomerDetails
                {
                    CustomerId = entity.CustomerId,
                    FullName=entity.FirstName+" "+ entity.LastName,
                    PhoneNumber = entity.PhoneNumber,
                    EmailAddress = entity.EmailAddress,
                    Transactions = entity.Transactions.Select(
                          z => new TransactionListItem
                          {
                              TransactionId = z.TransactionId,
                              DateOfTransaction = z.DateOfTransaction,
    
                          }).ToList(),
                };
            }
        }

        public bool UpdateCustomerInformations(CustomerEdit customer)
        {
            using(var ctx= new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(e => e.CustomerId == customer.CustomerId && e.OwnerId == _UserId);
                entity.CustomerId = customer.CustomerId;
                entity.FirstName = customer.FirstName;
                entity.LastName = customer.LastName;
                entity.PhoneNumber = customer.PhoneNumber;
           
                return ctx.SaveChanges() == 1;
            }
        }
        
        public bool DeleteCustomer(int customerId)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(e => e.CustomerId == customerId && e.OwnerId == _UserId);
                ctx.Customers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
