using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using membakery_inventory.Models;

namespace membakery_inventory.Controllers
{
    public class TransactionInsController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: TransactionIns
        public ActionResult Index()
        {
            var transactionIns = db.TransactionIns.Include(t => t.Employee).Include(t => t.Stock);
            return View(transactionIns.ToList());
        }

        // GET: TransactionIns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionIn transactionIn = db.TransactionIns.Find(id);
            if (transactionIn == null)
            {
                return HttpNotFound();
            }
            return View(transactionIn);
        }

        // GET: TransactionIns/Create
        public ActionResult Create()
        {
            ViewBag.Emp_ID = new SelectList(db.Employees, "name", "name");
            ViewBag.Stock_ID = new SelectList(db.Stocks, "Stock_ID", "Stock_Name");
            return View();
        }

        // POST: TransactionIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionNoIn,Emp_ID,Stock_ID,IQuantity,IPrice,Date")] TransactionIn transactionIn)
        {
            if (ModelState.IsValid)
            {
                db.TransactionIns.Add(transactionIn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Emp_ID = new SelectList(db.Employees, "Emp_ID", "password", transactionIn.Emp_ID);
            ViewBag.Stock_ID = new SelectList(db.Stocks, "Stock_ID", "Stock_Name", transactionIn.Stock_ID);
            return View(transactionIn);
        }

        // GET: TransactionIns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionIn transactionIn = db.TransactionIns.Find(id);
            if (transactionIn == null)
            {
                return HttpNotFound();
            }
            ViewBag.Emp_ID = new SelectList(db.Employees, "Emp_ID", "password", transactionIn.Emp_ID);
            ViewBag.Stock_ID = new SelectList(db.Stocks, "Stock_ID", "Stock_Name", transactionIn.Stock_ID);
            return View(transactionIn);
        }

        // POST: TransactionIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionNoIn,Emp_ID,Stock_ID,IQuantity,IPrice,Date")] TransactionIn transactionIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactionIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Emp_ID = new SelectList(db.Employees, "Emp_ID", "password", transactionIn.Emp_ID);
            ViewBag.Stock_ID = new SelectList(db.Stocks, "Stock_ID", "Stock_Name", transactionIn.Stock_ID);
            return View(transactionIn);
        }

        // GET: TransactionIns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionIn transactionIn = db.TransactionIns.Find(id);
            if (transactionIn == null)
            {
                return HttpNotFound();
            }
            return View(transactionIn);
        }

        // POST: TransactionIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransactionIn transactionIn = db.TransactionIns.Find(id);
            db.TransactionIns.Remove(transactionIn);
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
