using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.AdministratorModul.ViewModels
{
    public class DirekcijeVM
    {
        [Required(ErrorMessage ="Adresa je obavezna")]
        public string Adresa { get; set; }
        [RegularExpression(@"^\d$",ErrorMessage ="Odaberite grad")]
         public int GradID { get; set; }
    }
}
