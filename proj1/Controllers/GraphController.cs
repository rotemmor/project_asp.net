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
    public class GraphController : Controller
    {
        private WebContext db = new WebContext();

 
        //class for garph
        public class getNumHotel 
        {
            public string State { get; set; }
            public int freq { get; set; }
        }

        // details for graph - num of hotels in each city
        public JsonResult getGraphA()
        {

            List<getNumHotel> citys = new List<getNumHotel>();

            var result = (from du in db.hotels
                          group du by new { du.hotelCity }
                              into gr
                              select new
                              {
                                  gr.Key.hotelCity,
                                  Amount = gr.Count()
                              }
              );

            foreach (var x in result)
            {
                getNumHotel sum = new getNumHotel();
                sum.State = x.hotelCity;
                sum.freq = x.Amount;
                citys.Add(sum);
            }

            return Json(citys, JsonRequestBehavior.AllowGet);
        }


        // details for graph - num of recommendations in each city
        public JsonResult getGraphB()
        {

            List<getNumHotel> citys = new List<getNumHotel>();

            var result = (from h in db.hotels
                          join r in db.RecommendationsHotel on h.ID equals r.HotelID
                          group h by new { h.hotelCity }
                              into gr
                              select new
                              {
                                  gr.Key.hotelCity,
                                  Amount = gr.Count()
                              }
              );

            foreach (var x in result)
            {
                getNumHotel sum = new getNumHotel();
                sum.State = x.hotelCity;
                sum.freq = x.Amount;
                citys.Add(sum);
            }

            return Json(citys, JsonRequestBehavior.AllowGet);
        }


        //class for graph
          public class getNumRest
        {
            public string State { get; set; } // עיר
            public int freq { get; set; } 
        }

        //details for graph - num of rest in each city
        public JsonResult getGraphC()
        {

            List<getNumRest> citys = new List<getNumRest>();

            var result = (from du in db.rests
                          group du by new { du.restCity}
                              into gr
                              select new
                              {
                                  gr.Key.restCity,
                                  Amount = gr.Count()
                              }
              );

            foreach (var x in result)
            {
                getNumRest sum = new getNumRest();
                sum.State = x.restCity;
                sum.freq = x.Amount;
                citys.Add(sum);
            }

            return Json(citys, JsonRequestBehavior.AllowGet);
        }

        //details for graph - nu of recommendations in each city
        public JsonResult getGraphD()
        {

            List<getNumRest> citys = new List<getNumRest>();

            var result = (from re in db.rests
                          join r in db.RecommendationsRest on re.ID equals r.RestID
                          group re by new { re.restCity }
                              into gr
                              select new
                              {
                                  gr.Key.restCity,
                                  Amount = gr.Count()
                              }
              );

            foreach (var x in result)
            {
                getNumRest sum = new getNumRest();
                sum.State = x.restCity;
                sum.freq = x.Amount;
                citys.Add(sum);
            }

            return Json(citys, JsonRequestBehavior.AllowGet);

        }
    }
}
