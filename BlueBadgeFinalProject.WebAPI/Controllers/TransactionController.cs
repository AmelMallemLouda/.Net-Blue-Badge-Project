using BlueBadgeFinalProject.Models.TransactionModels;
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
    public class TransactionController : ApiController
    {
        private TransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var transactionService = new TransactionService(userId);
            return transactionService;
        }

        public IHttpActionResult Post(TransactionCreate transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTransactionService();

            if (!service.CreateTransaction(transaction))
                return InternalServerError();

            return Ok("The transaction has been successfully created!");
        }

        public IHttpActionResult Get()
        {
            TransactionService transactionService = CreateTransactionService();
            var transactions = transactionService.GetTransactions();
            return Ok(transactions);
        }

        [Route("api/Transaction/GetByTransactionId/{transactionId}")]
        public IHttpActionResult Get(int transactionId)
        {
            TransactionService transactionService = CreateTransactionService();
            var transaction = transactionService.GetTransactionById(transactionId);
            return Ok(transaction);
        }

        public IHttpActionResult Put(TransactionEdit transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTransactionService();

            if (!service.UpdateTransaction(transaction))
                return InternalServerError();

            return Ok("The transaction has been successfully updated!");
        }

        [Route("api/Transaction/DeleteTransaction/{transactionId}")]
        public IHttpActionResult Delete(int transactionId)
        {
            var service = CreateTransactionService();

            if (!service.DeleteTransaction(transactionId))
                return InternalServerError();

            return Ok("The transaction has been deleted!");
        }
    }
}
