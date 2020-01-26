using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BillingManagementSystem.Models;
using BillingManagementSystem.ViewModel;

namespace BillingManagementSystem.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            customer.payments = db.Payments.Where(m => m.cust_Id == id).ToList();
            var allMonths=GetMonthNamesByCulture();
            var paidMonths=customer.payments.Where(c=>c.payment_For.Year==DateTime.Now.Year).Select(m => m.payment_For.Month).ToList();
            var paidMonthsName = GetMonthNames(paidMonths);
            var unPaidMonths = allMonths.Where(c=>!paidMonthsName.Any(m => m==c)).ToList();
            CustomerDetailViewModel viewModel = new CustomerDetailViewModel();
            viewModel.customer = customer;
           
            viewModel.customer.payments = customer.payments.Where(c => c.payment_For.Year == DateTime.Now.Year).ToList();


            var monthscheckBoxListItems = new List<CheckBoxListItem>();
            foreach (var item in allMonths)
            {
                monthscheckBoxListItems.Add(new CheckBoxListItem()
                {
                    ID = item.IndexOf(item),
                    Display = item,
                    IsChecked = paidMonthsName.Where(m=>m==item).Count()>0?true:false,
                });
            }

            viewModel.months = monthscheckBoxListItems;
            return View(viewModel);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cust_Id,first_Name,last_Name,cell_Number,address,createdDate,cnic,cardNumber,boxNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.createdDate = DateTime.Now;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cust_Id,first_Name,last_Name,cell_Number,address,createdDate,cnic,cardNumber,boxNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.createdDate = DateTime.Now;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
        public List<string> GetMonthNamesByCulture()
        {
            CultureInfo culture= CultureInfo.InvariantCulture;
            return new List<string>
    {
        culture.DateTimeFormat.GetMonthName(1),
        culture.DateTimeFormat.GetMonthName(2),
        culture.DateTimeFormat.GetMonthName(3),
        culture.DateTimeFormat.GetMonthName(4),
        culture.DateTimeFormat.GetMonthName(5),
        culture.DateTimeFormat.GetMonthName(6),
        culture.DateTimeFormat.GetMonthName(7),
        culture.DateTimeFormat.GetMonthName(8),
        culture.DateTimeFormat.GetMonthName(9),
        culture.DateTimeFormat.GetMonthName(10),
        culture.DateTimeFormat.GetMonthName(11),
        culture.DateTimeFormat.GetMonthName(12),
    };
        }
  
    public List<string> GetMonthNames(List<int> months)
    {
        CultureInfo culture = CultureInfo.InvariantCulture;


        List<string> monthNames = new List<string>();
        foreach (var item in months)
        {

            monthNames.Add(culture.DateTimeFormat.GetMonthName(item));
        };

        return monthNames;
    }  
}}
