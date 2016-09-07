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
    public class RecommendationRestsController : Controller
    {
        private WebContext db = new WebContext();

        // GET: RecommendationRests
        public ActionResult Index(String city)
        {
            var recommendationsRest = db.RecommendationsRest.Include(r => r.rest);
            if (!String.IsNullOrEmpty(city))        // search by city
            {
                recommendationsRest = recommendationsRest.Where(s => s.rest.restCity.Contains(city));
            }
            return View(recommendationsRest.ToList());
        }

        // GET: RecommendationRests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecommendationRest recommendationRest = db.RecommendationsRest.Find(id);
            if (recommendationRest == null)
            {
                return HttpNotFound();
            }
            return View(recommendationRest);
        }

        // GET: RecommendationRests/Create
        public ActionResult Create()
        {
            ViewBag.RestID = new SelectList(db.rests, "ID", "restName");
            return View();
        }

        // POST: RecommendationRests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RestID,recoName,recoPhone,recoRating,recoInfo")] RecommendationRest recommendationRest)
        {
            if (ModelState.IsValid)
            {
                db.RecommendationsRest.Add(recommendationRest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestID = new SelectList(db.rests, "ID", "restName", recommendationRest.RestID);
            return View(recommendationRest);
        }

        // GET: RecommendationRests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecommendationRest recommendationRest = db.RecommendationsRest.Find(id);
            if (recommendationRest == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestID = new SelectList(db.rests, "ID", "restName", recommendationRest.RestID);
            return View(recommendationRest);
        }

        // POST: RecommendationRests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RestID,recoName,recoPhone,recoRating,recoInfo")] RecommendationRest recommendationRest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recommendationRest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestID = new SelectList(db.rests, "ID", "restName", recommendationRest.RestID);
            return View(recommendationRest);
        }

        // GET: RecommendationRests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecommendationRest recommendationRest = db.RecommendationsRest.Find(id);
            if (recommendationRest == null)
            {
                return HttpNotFound();
            }
            return View(recommendationRest);
        }

        // POST: RecommendationRests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecommendationRest recommendationRest = db.RecommendationsRest.Find(id);
            db.RecommendationsRest.Remove(recommendationRest);
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
