using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.ReferentZaKlijenteModul.ViewModels
{
    public class KlijentiVM
    {
        [Required(ErrorMessage = "Ime je obavezno")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "JMBG je obavezan"), StringLength(13, MinimumLength = 13, ErrorMessage = "JMBG mora biti 13 brojeva")]
        public string JMBG { get; set; }
        [Required(ErrorMessage = "Adresa je obavezna")]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Telefon je obavezan"), DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }
        [Required, Range(0, int.MaxValue, ErrorMessage = "Odaberite grad")]
        public int GradID { get; set; }
    }
}
