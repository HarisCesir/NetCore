using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.ReferentZaKlijenteModul.ViewModels
{
    public class CijenaVM
    {
        [Required(ErrorMessage = "CijenaKwhJeftina je obavezna")]
        public decimal CijenaKwhJeftina { get; set; }
        [Required(ErrorMessage = "CijenaKwhSkupa je obavezna")]
        public decimal CijenaKwhSkupa { get; set; }
    }
}
