using Elektrodistribucija.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.AdministratorModul.ViewModels
{
    public class DodajOdjelVM
    {
        [Required(ErrorMessage = "Adresa je obavezna")]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Svrha je obavezna")]
        public string Svrha { get; set; }


        [RegularExpression(@"^\d$", ErrorMessage = "Odaberite direkciju")]
        public int DirekcijaID { get; set; }
    }
}
