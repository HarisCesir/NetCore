using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.AdministratorModul.ViewModels
{
    public class PlataVM
    {
        
        public int KorisnickiNalogID { get; set; }
        [Required(ErrorMessage = "Osnovica je obavezna")]
        public decimal Osnova { get; set; }
       
        public decimal Bonus { get; set; }
        public decimal Ukupno { get; set; }

    }
}
