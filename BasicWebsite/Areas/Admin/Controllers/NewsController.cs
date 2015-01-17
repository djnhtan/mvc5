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
    public class NewsController : Controller
    {
        private BasicWebDbContext db = new BasicWebDbContext();

        // GET: /Admin/News/
        public ActionResult Index()
        {
            return View(db.NewsModels.ToList());
        }

        // GET: /Admin/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsModel newsmodel = db.NewsModels.Find(id);
            if (newsmodel == null)
            {
                return HttpNotFound();
            }
            return View(newsmodel);
        }

        // GET: /Admin/News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Created,CreatedBy,Modified,ModifiedBy,Title,Status,StartDate,EndDate,Category,Description,Content,Position")] NewsModel newsmodel)
        {
            if (ModelState.IsValid)
            {
                db.NewsModels.Add(newsmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsmodel);
        }

        // GET: /Admin/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsModel newsmodel = db.NewsModels.Find(id);
            if (newsmodel == null)
            {
                return HttpNotFound();
            }
            return View(newsmodel);
        }

        // POST: /Admin/News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Created,CreatedBy,Modified,ModifiedBy,Title,Status,StartDate,EndDate,Category,Description,Content,Position")] NewsModel newsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsmodel);
        }

        // GET: /Admin/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsModel newsmodel = db.NewsModels.Find(id);
            if (newsmodel == null)
            {
                return HttpNotFound();
            }
            return View(newsmodel);
        }

        // POST: /Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsModel newsmodel = db.NewsModels.Find(id);
            db.NewsModels.Remove(newsmodel);
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
