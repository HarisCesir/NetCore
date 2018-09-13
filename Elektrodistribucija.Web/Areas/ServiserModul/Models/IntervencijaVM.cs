using Elektrodistribucija.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.ServiserModul.Models
{
    public class IntervencijaVM
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Polje datum je obavezno")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Polje Lokacija je obavezno")]
        public string Lokacija { get; set; }
        public string Trajanje { get; set; }

        public string Alati { get; set; }

        public string Troskovi { get; set; }

        [RegularExpression(@"^\d$", ErrorMessage = "Odaberite opremu")]
        public int OpremaID { get; set; }

        [RegularExpression(@"^\d$", ErrorMessage = "Odaberite prijavu kvara")]
        public int PrijavaKvaraID { get; set; }

        [RegularExpression(@"^\d$", ErrorMessage = "Odaberite servisera")]
        public int ServiserID { get; set; }

    }
}
