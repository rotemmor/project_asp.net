using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proj1.DAL;
using proj1.Models;

namespace proj1.Controllers
{
    public class RestsController : Controller
    {
        private WebContext db = new WebContext();

        // GET: Rests
        public ActionResult Index(string searchRestCity, String searchRestName, String searchRestRating,String searchTypeRest)
        {
            var rest = from m in db.rests select m;           //Extended Search by topic

            if (!String.IsNullOrEmpty(searchRestCity))        // search rest by city
            {
                rest = rest.Where(s => s.restCity.Contains(searchRestCity));
            }
            if (!String.IsNullOrEmpty(searchRestName))         // search rest by name
            {
                rest = rest.Where(s => s.restName.Contains(searchRestName));
            }
            if (!String.IsNullOrEmpty(searchRestRating))        // search rest by rating
            {
                rest = rest.Where(s => s.restRating.Contains(searchRestRating));
            }
            if (!String.IsNullOrEmpty(searchTypeRest))        // search rest by type
            {
                rest = rest.Where(s => s.restType.Contains(searchTypeRest));
            }
            return View(rest);
        }

        // GET: Rests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rest rest = db.rests.Find(id);
            if (rest == null)
            {
                return HttpNotFound();
            }
            return View(rest);
        }

        // GET: Rests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,restName,restType,restCity,restAddress,restRating,restPrice,restKosher,restInfo,imgRest1,imgRest2,imgRest3,imgRest4,imgRest5")] Rest rest)
        {
            if (ModelState.IsValid)
            {
                db.rests.Add(rest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rest);
        }

        // GET: Rests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rest rest = db.rests.Find(id);
            if (rest == null)
            {
                return HttpNotFound();
            }
            return View(rest);
        }

        // POST: Rests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,restName,restType,restCity,restAddress,restRating,restPrice,restKosher,restInfo,imgRest1,imgRest2,imgRest3,imgRest4,imgRest5")] Rest rest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rest);
        }

        // GET: Rests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rest rest = db.rests.Find(id);
            if (rest == null)
            {
                return HttpNotFound();
            }
            return View(rest);
        }

        // POST: Rests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rest rest = db.rests.Find(id);
            db.rests.Remove(rest);
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
