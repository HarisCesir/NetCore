using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.ReferentZaKlijenteModul.ViewModels
{
    public class PrivremenoIskljucenjeVM
    {
        [Required(ErrorMessage ="Unesite datum u ispravnom formatu"),DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        
        public int PrikljucakID { get; set; }
        [Required]
        public string Razlog { get; set; }
    }
}
