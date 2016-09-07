using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proj1.Models
{
    public class Hotel
    {
        public int ID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "שדה לא תקין")]
        [Display(Name = "שם המלון")]
        public string hotelName { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "יש להכניס רק אותיות")]
        [Required]
        [Display(Name = "עיר")]
        public string hotelCity { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9à''-'','\s]{1,40}$",
       ErrorMessage = "יש להכניס כתובת מדוייקת")]
        [Required]
        [Display(Name = "כתובת המלון")]
        public string hotelAddress { get; set; }

        [Range(1, 5)]
        [Required]
        [Display(Name = "הדירוג שלנו")]
        public string hotelRating { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9''-''$'\s]{1,40}$",
         ErrorMessage = "שדה לא תקין")]
        [Required]
        [Display(Name = "ממוצע מחיר ללילה")]
        public string hotelPrice { get; set; }


        [Display(Name = "Free Wifi")]
        public bool Wifi { get; set; }

        [Display(Name = "נגישות לתחבורה ציבורית")]
        public bool hotelTransportation { get; set; }
       
        public string imghotel1 { get; set; }
        public string imghotel2 { get; set; }
        public string imghotel3 { get; set; }
        public string imghotel4 { get; set; }
        public string imghotel5 { get; set; }


        [Display(Name = "מידע על המלון")]
        public string hotelInfo { get; set; }

        public virtual ICollection<RecommendationHotel> RecommendationsHotel { get; set; }
    }
}