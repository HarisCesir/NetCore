using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.ServiserModul.Models
{
    public class OpremaVM
    {
        [Required (ErrorMessage ="Polje naziv je obavezno")]
        public string Naziv { get; set; }

       
    }
}
