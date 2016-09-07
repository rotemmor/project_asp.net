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
    public class RecommendationHotelsController : Controller
    {
        private WebContext db = new WebContext();

        // GET: RecommendationHotels
        public ActionResult Index(String city)
        {
            var recommendationsHotel = db.RecommendationsHotel.Include(r => r.hotel);
            if (!String.IsNullOrEmpty(city))        // search by city
            {
                recommendationsHotel = recommendationsHotel.Where(s => s.hotel.hotelCity.Contains(city));
            }
            return View(recommendationsHotel.ToList());
        }

        // GET: RecommendationHotels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecommendationHotel recommendationHotel = db.RecommendationsHotel.Find(id);
            if (recommendationHotel == null)
            {
                return HttpNotFound();
            }
            return View(recommendationHotel);
        }

        // GET: RecommendationHotels/Create
        public ActionResult Create()
        {
            ViewBag.HotelID = new SelectList(db.hotels, "ID", "hotelName");
            return View();
        }

        // POST: RecommendationHotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HotelID,recoName,recoPhone,recoRating,recoInfo")] RecommendationHotel recommendationHotel)
        {
            if (ModelState.IsValid)
            {
                db.RecommendationsHotel.Add(recommendationHotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HotelID = new SelectList(db.hotels, "ID", "hotelName", recommendationHotel.HotelID);
            return View(recommendationHotel);
        }

        // GET: RecommendationHotels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecommendationHotel recommendationHotel = db.RecommendationsHotel.Find(id);
            if (recommendationHotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelID = new SelectList(db.hotels, "ID", "hotelName", recommendationHotel.HotelID);   
            return View(recommendationHotel);
        }

        // POST: RecommendationHotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HotelID,recoName,recoPhone,recoRating,recoInfo")] RecommendationHotel recommendationHotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recommendationHotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HotelID = new SelectList(db.hotels, "ID", "hotelName", recommendationHotel.HotelID);
            return View(recommendationHotel);
        }

        // GET: RecommendationHotels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecommendationHotel recommendationHotel = db.RecommendationsHotel.Find(id);
            if (recommendationHotel == null)
            {
                return HttpNotFound();
            }
            return View(recommendationHotel);
        }

        // POST: RecommendationHotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecommendationHotel recommendationHotel = db.RecommendationsHotel.Find(id);
            db.RecommendationsHotel.Remove(recommendationHotel);
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
