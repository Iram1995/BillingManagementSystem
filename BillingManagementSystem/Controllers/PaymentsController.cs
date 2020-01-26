using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BillingManagementSystem.Models;

namespace BillingManagementSystem.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Payments
        public ActionResult Index()
        {
            var payments = db.Payments.Include(p => p.Customer);
            return View(payments.ToList());
        }

        // GET: Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create
        public ActionResult Create (int id=0)
        {
            ViewBag.customers = db.Customers.ToList();
            //ViewBag.cust_Id = new SelectList(db.Customers, "cust_Id", "first_Name");
            Payment payment = new Payment();
          
            if (id != 0) {
                payment.Customer = db.Customers.Find(id);
                payment.cust_Id=db.Customers.Find(id).cust_Id;
            }
            payment.payment_Date = DateTime.Now;
            return View(payment);
        }
      
        

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "payment_Id,paid_By,payment_Amount,payment_For,employee_Name,payment_Date,cust_Id")] Payment payment)
        {
            if (ModelState.IsValid)
            {

                payment.Customer = db.Customers.Find(payment.cust_Id);
                payment.payment_Date = DateTime.Now;
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cust_Id = new SelectList(db.Customers, "cust_Id", "first_Name", payment.cust_Id);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            //ViewBag.cust_Id = new SelectList(db.Customers, "cust_Id", "first_Name", payment.cust_Id);
            ViewBag.customers = db.Customers.ToList();
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "payment_Id,paid_By,payment_Amount,payment_For,employee_Name,payment_Date,cust_Id")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cust_Id = new SelectList(db.Customers, "cust_Id", "first_Name", payment.cust_Id);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
