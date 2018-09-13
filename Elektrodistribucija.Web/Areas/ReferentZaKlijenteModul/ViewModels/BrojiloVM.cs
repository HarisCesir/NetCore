using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.ReferentZaKlijenteModul.ViewModels
{
    public class BrojiloVM
    {
      
        public decimal StaroStanjeJeftina { get; set; }
     
        public decimal StatoStanjeSkupa { get; set; }
        [Required]
        public decimal TrenutnoStanjeJeftina { get; set; }
        [Required]
        public decimal TrenutnoStanjeSkupa { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        public int PrikljucakID { get; set; }
        public int BrojiloID { get; set; }
    }
}
