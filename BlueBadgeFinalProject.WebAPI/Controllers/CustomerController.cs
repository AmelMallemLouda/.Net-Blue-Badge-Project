using BlueBadgeFinalProject.Models.CustomerFolder;
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
    public class CustomerController : ApiController
    {
        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var customerService = new CustomerService(userId);
            return customerService;
        }
        public IHttpActionResult Get()
        {
            CustomerService customerService = CreateCustomerService();
            var customers = customerService.GetAllCustomers();
            return Ok(customers);
        }
       // [Route("{api}/{customer}/{Id}")]
        public IHttpActionResult GetCustomerById([FromUri] int Id)
        {
            CustomerService customerService = CreateCustomerService();
            var customer = customerService.GetCustomerById(Id);
            return Ok(customer);
        }
        public IHttpActionResult Post(CustomerCreate customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCustomerService();
            if (!service.CeateCustomer(customer))
                return InternalServerError();
            return Ok("The customer has been created");
        }

        public IHttpActionResult Put(CustomerEdit customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCustomerService();
            if (!service.UpdateCustomerInformations(customer))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int customerId)
        {
            var service = CreateCustomerService();

            if (!service.DeleteCustomer(customerId))
                return InternalServerError();

            return Ok("The customer has been deleted");


        }


    }
}
