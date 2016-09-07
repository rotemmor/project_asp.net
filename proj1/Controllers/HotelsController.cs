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
    public class HotelsController : Controller
    {
        private WebContext db = new WebContext();

        // GET: Hotels 

        
        public ActionResult Index(String searchHotelCity, String searchHotelName, String searchHotelRating)
        {
            var hotel = from m in db.hotels select m;           //Extended Search by topic

            if (!String.IsNullOrEmpty(searchHotelCity))        // search hotel by city
            {
                hotel = hotel.Where(s => s.hotelCity.Contains(searchHotelCity));
            }
            if (!String.IsNullOrEmpty(searchHotelName))         // search hotel by name
            {
                hotel = hotel.Where(s => s.hotelName.Contains(searchHotelName));
            }
            if (!String.IsNullOrEmpty(searchHotelRating))        // search hotel by rating
            {
                hotel = hotel.Where(s => s.hotelRating.Contains(searchHotelRating));
            }
            {
            }
        
            return View(hotel);
        }


        // GET: Hotels/Details/5     
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // GET: Hotels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,hotelName,hotelCity,hotelAddress,hotelRating,hotelPrice,Wifi,hotelTransportation,imghotel1,imghotel2,imghotel3,imghotel4,imghotel5,hotelInfo")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.hotels.Add(hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,hotelName,hotelCity,hotelAddress,hotelRating,hotelPrice,Wifi,hotelTransportation,imghotel1,imghotel2,imghotel3,imghotel4,imghotel5,hotelInfo")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = db.hotels.Find(id);
            db.hotels.Remove(hotel);
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


        //getAddress - google maps, places
        public ActionResult getAddress()
        {
            List<String> address = new List<string>();
            var hotels = from n in db.hotels select n;
            foreach (var item in hotels)
            {
                if (item.hotelAddress != null)
                {
                    address.Add(item.hotelAddress);
                }
            }

            return Json(address, JsonRequestBehavior.AllowGet);
        }
      
    }
}
