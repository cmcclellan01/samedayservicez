using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using samedayservicez.Models;

namespace samedayservicez
{
    public class ContractorRegistrationFormsController : Controller
    {
        private samedayservicezContext db = new samedayservicezContext();

        // GET: ContractorRegistrationForms
        public ActionResult Index()
        {
            return View(db.Contractors.ToList());
        }

        // GET: ContractorRegistrationForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractorRegistrationForm contractorRegistrationForm = db.Contractors.Find(id);
            if (contractorRegistrationForm == null)
            {
                return HttpNotFound();
            }
            return View(contractorRegistrationForm);
        }

        // GET: ContractorRegistrationForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContractorRegistrationForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,MiddleName,LastName,Address,City,State,ZipCode,PhoneNumber,Email,Password,ConfirmPassword,BirthDate,Bio")] ContractorRegistrationForm contractorRegistrationForm)
        {
            if (ModelState.IsValid)
            {
                db.Contractors.Add(contractorRegistrationForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contractorRegistrationForm);
        }

        // GET: ContractorRegistrationForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractorRegistrationForm contractorRegistrationForm = db.Contractors.Find(id);
            if (contractorRegistrationForm == null)
            {
                return HttpNotFound();
            }
            return View(contractorRegistrationForm);
        }

        // POST: ContractorRegistrationForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,Address,City,State,ZipCode,PhoneNumber,Email,Password,ConfirmPassword,BirthDate,Bio")] ContractorRegistrationForm contractorRegistrationForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contractorRegistrationForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contractorRegistrationForm);
        }

        // GET: ContractorRegistrationForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractorRegistrationForm contractorRegistrationForm = db.Contractors.Find(id);
            if (contractorRegistrationForm == null)
            {
                return HttpNotFound();
            }
            return View(contractorRegistrationForm);
        }

        // POST: ContractorRegistrationForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContractorRegistrationForm contractorRegistrationForm = db.Contractors.Find(id);
            db.Contractors.Remove(contractorRegistrationForm);
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
