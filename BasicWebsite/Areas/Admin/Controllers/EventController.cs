﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BasicWebsite.Models;
using System.Web.Configuration;

namespace BasicWebsite.Areas.Admin.Controllers
{
    public class EventController : Controller
    {
        private BasicWebDbContext db = new BasicWebDbContext();

        // GET: /Admin/Event/
        public ActionResult Index()
        {
            return View(db.EvenModels.ToList());
        }

        // GET: /Admin/Event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel eventmodel = db.EvenModels.Find(id);
            if (eventmodel == null)
            {
                return HttpNotFound();
            }
            return View(eventmodel);
        }

        // GET: /Admin/Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Created,CreatedBy,Modified,ModifiedBy,Status,Title,Organizer,Type,StartDate,EndDate,Description")] EventModel eventmodel)
        {
            if (ModelState.IsValid)
            {
                eventmodel.Created = eventmodel.Modified = DateTime.Now;
                eventmodel.CreatedBy = eventmodel.ModifiedBy = User.Identity.Name;
                eventmodel.Status = "Open";
                db.EvenModels.Add(eventmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventmodel);
        }

        // GET: /Admin/Event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel eventmodel = db.EvenModels.Find(id);
            if (eventmodel == null)
            {
                return HttpNotFound();
            }
            return View(eventmodel);
        }

        // POST: /Admin/Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Created,CreatedBy,Modified,ModifiedBy,Status,Title,Organizer,Type,StartDate,EndDate,Description")] EventModel eventmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventmodel);
        }

        // GET: /Admin/Event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel eventmodel = db.EvenModels.Find(id);
            if (eventmodel == null)
            {
                return HttpNotFound();
            }
            return View(eventmodel);
        }

        // POST: /Admin/Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventModel eventmodel = db.EvenModels.Find(id);
            db.EvenModels.Remove(eventmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetAllEvent(string date)
        {
            var currentDate = Convert.ToDateTime(date);
            var applicationUrl = WebConfigurationManager.AppSettings["application-url"];
            var allEvent = db.EvenModels.Where(e => (e.StartDate.Month.Equals(currentDate.Month)
                                              && e.StartDate.Year.Equals(currentDate.Year))
                                              || (e.EndDate.Month.Equals(currentDate.Month)
                                              && e.EndDate.Year.Equals(currentDate.Year)));
            return Json(allEvent.ToList().Select(e => new {
                                                    title=e.Title,
                                                    status=e.Status,
                                                    organizer = e.Organizer,
                                                    start=Convert.ToDateTime(e.StartDate).ToString("yyyy-MM-ddThh:mm:ss"),
                                                    end = Convert.ToDateTime(e.EndDate).ToString("yyyy-MM-ddThh:mm:ss"),
                                                    description = e.Description,
                                                    url=string.Format("{0}/Admin/Event/Details/{1}",applicationUrl,e.ID)
                                                 }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EventList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                var listEvent = new List<EventTable>();
                IQueryable<EventModel> events;
                var sord = string.Empty;
                var order = string.Empty;
                if (!string.IsNullOrEmpty(jtSorting))
                {
                    sord = jtSorting.Split(' ')[0];
                    order = jtSorting.Split(' ')[1];
                    if (order.Equals("ASC"))
                    {
                        switch (sord)
                        {
                            case "Title":
                                events = db.EvenModels.OrderBy(e => e.Title).Skip(jtStartIndex).Take(jtPageSize);
                                break;
                            case "Organizer":
                                events = db.EvenModels.OrderBy(e => e.Organizer).Skip(jtStartIndex).Take(jtPageSize);
                                break;
                            case "Type":
                                events = db.EvenModels.OrderBy(e => e.Type).Skip(jtStartIndex).Take(jtPageSize);
                                break;
                            default:
                                events = db.EvenModels.OrderBy(e => e.ID).Skip(jtStartIndex).Take(jtPageSize);
                                break;

                        }
                    }
                    else
                    {
                        switch (sord)
                        {
                            case "Title":
                                events = db.EvenModels.OrderByDescending(e => e.Title).Skip(jtStartIndex).Take(jtPageSize);
                                break;
                            case "Organizer":
                                events = db.EvenModels.OrderByDescending(e => e.Organizer).Skip(jtStartIndex).Take(jtPageSize);
                                break;
                            case "Type":
                                events = db.EvenModels.OrderByDescending(e => e.Type).Skip(jtStartIndex).Take(jtPageSize);
                                break;
                            default:
                                events = db.EvenModels.OrderByDescending(e => e.ID).Skip(jtStartIndex).Take(jtPageSize);
                                break;

                        }
                    }
                }
                else
                {
                    events = db.EvenModels.OrderBy(e => e.ID).Skip(jtStartIndex).Take(jtPageSize);
                }
                listEvent = events.Select(e => new EventTable
                {
                    ID=e.ID.ToString(),
                    Title=e.Title,
                    Organizer=e.Organizer,
                    Type=e.Type
                }).ToList();
                int eventCount = db.EvenModels.ToList().Count();
                return Json(new { Result = "OK", Records = listEvent, TotalRecordCount = eventCount });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
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

    public class EventTable
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Organizer { get; set; }
        public string Type { get; set; }
    }
}
