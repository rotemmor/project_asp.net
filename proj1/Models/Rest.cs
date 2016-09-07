using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proj1.Models
{
   public class Rest
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Zא-ת''-'\s]{1,40}$",
         ErrorMessage = "שדה לא תקין")]
        [Display(Name = "שם המסעדה")]
        public string restName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Zא-ת''-'\s]{1,40}$",
         ErrorMessage = "שדה לא תקין")]
        [Display(Name = "סוג המסעדה")]
        public string restType { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Zא-ת''-'\s]{1,40}$",
         ErrorMessage = "שדה לא תקין")]       
        [Display(Name = "עיר")]
        public string restCity { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9à''-'','\s]{1,40}$",
        ErrorMessage = "יש להכניס כתובת מדוייקת")] 
        [Display(Name = "כתובת המסעדה")]
        public string restAddress { get; set; }

        [Range(1, 5)]
        [Required]
        [Display(Name = "הדירוג שלנו")]
        public string restRating { get; set; }

         [RegularExpression(@"^[a-zA-Z0-9''-''$'\s]{1,40}$",
         ErrorMessage = "שדה לא תקין")] 
        [Required]
        [Display(Name = "ממוצע מחיר לסועד")]
        public string restPrice { get; set; }

        [Display(Name = "כשרה")]
        public bool restKosher { get; set; }

        [Display(Name = "מלל על המסעדה")]
        public string restInfo { get; set; }

        public string imgRest1 { get; set; }
        public string imgRest2 { get; set; }
        public string imgRest3 { get; set; }        
        public string imgRest4 { get; set; }
        public string imgRest5 { get; set; }


        public virtual ICollection<RecommendationRest> RestsReco { get; set; }
    }
    }
