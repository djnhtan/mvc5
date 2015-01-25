using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BasicWebsite.Models;

namespace BasicWebsite.Areas.Admin.Controllers
{
    public class CompanyController : Controller
    {
        private BasicWebDbContext db = new BasicWebDbContext();

        // GET: /Admin/Company/
        public ActionResult Index()
        {
            return View(db.CompanyModels.ToList());
        }

        // GET: /Admin/Company/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyModel companymodel = db.CompanyModels.Find(id);
            if (companymodel == null)
            {
                return HttpNotFound();
            }
            return View(companymodel);
        }

        // GET: /Admin/Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,StockId,Founded,Director,Country,Headquarters,Description,Tags,IsActive")] CompanyModel companymodel)
        {
            if (ModelState.IsValid)
            {
                db.CompanyModels.Add(companymodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companymodel);
        }

        // GET: /Admin/Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyModel companymodel = db.CompanyModels.Find(id);
            if (companymodel == null)
            {
                return HttpNotFound();
            }
            return View(companymodel);
        }

        // POST: /Admin/Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,StockId,Founded,Director,Country,Headquarters,Description,Tags,IsActive")] CompanyModel companymodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companymodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companymodel);
        }

        // GET: /Admin/Company/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyModel companymodel = db.CompanyModels.Find(id);
            if (companymodel == null)
            {
                return HttpNotFound();
            }
            return View(companymodel);
        }

        // POST: /Admin/Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyModel companymodel = db.CompanyModels.Find(id);
            db.CompanyModels.Remove(companymodel);
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
