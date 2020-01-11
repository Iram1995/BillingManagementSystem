using BillingManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillingManagementSystem.Controllers.APIController
{
    public class PaymentAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/Payment
        [HttpGet]
        public IHttpActionResult getCustomersList(int id=0) {
            var response = db.Customers.Select(
                t => new { 
                name=t.first_Name+" "+t.last_Name,
                customerId=t.cust_Id,
                t.cell_Number,
                t.createdDate,
                t.address,
                t.cardNumber,
                t.cnic,
                
                }
                ).ToList();
            return Ok(response);
        }
       

        // GET: api/Payment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Payment
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Payment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Payment/5
        public void Delete(int id)
        {
        }
    }
}
