using BillingManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillingManagementSystem.Controllers.APIController
{
    public class SystemAPIsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IHttpActionResult getCustomersList()
        {
            var response = db.Customers.Select(
                t => new
                {
                    name = t.first_Name + " " + t.last_Name,
                    customerId = t.cust_Id,
                    t.cell_Number,
                    t.createdDate,
                    t.address,
                    cardNumber=t.cardNumber==null?"-":t.cardNumber,
                    boxNumber=t.boxNumber==null?"-":t.boxNumber,
                    t.cnic,

                }
                ).ToList();
            return Ok(response);
        }
        public IHttpActionResult getPaymentsList()
        {
            var response = db.Payments.Select(
                t => new
                {
                    name = t.Customer.first_Name + " " + t.Customer.last_Name,
                    customerId = t.cust_Id,
                    paidBy=t.paid_By,
                    payment_Amount=t.payment_Amount,
                    payment_For=t.payment_For,
                    employee_Name=t.employee_Name,
                    payment_Date=t.payment_Date,
                    payment_Id=t.payment_Id

                }
                ).ToList();
            return Ok(response);
        }
    }
}
