using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proj1.Models
{
    public class RecommendationHotel
    {
        public int ID { get; set; }
        //מפתח זר
        [Display(Name = "בחר מלון")]
        public int HotelID { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9''-'\s]{1,40}$",
         ErrorMessage = "שדה לא תקין")]
        [StringLength(25, MinimumLength = 3)]
        [Display(Name = "שם הממליץ")]
        public string recoName { get; set; }

        [Phone]
        [Display(Name = "טלפון הממליץ")]
        public string recoPhone { get; set; }


        [Range(1, 5)]
        [Display(Name = "דירוג הממליץ")]
        public string recoRating { get; set; }

        [StringLength(400, MinimumLength = 10)]
        [Display(Name = "תוכן")]
        public string recoInfo { get; set; }

        public virtual Hotel hotel { get; set; }
    }
}