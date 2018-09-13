using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.AdministratorModul.ViewModels
{
    public class GradVM
    {   [Required (ErrorMessage ="Naziv grada je obavezan")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Postanski broj je obavezan")]
        public string  PostanskiBroj { get; set; }
    }
}
