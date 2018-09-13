using Elektrodistribucija.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.AdministratorModul.ViewModels
{
    public class KorisniciDodajVM
    {
        [Required(ErrorMessage = "Ime je obavezno"), MinLength(3,ErrorMessage ="Ime ne smije biti kraće od 5 karaktera")  ]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno"), MinLength(3, ErrorMessage = "Prezime ne smije biti kraće od 5 karaktera")]
        public string Prezime { get; set; }
        [Required(ErrorMessage ="Telefon je obavezan"),DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }
        [Required(ErrorMessage ="Korisnicko ime je obavezno"),MinLength(5,ErrorMessage ="Korisnicko ime ne smije biti krace od 5 karaktera")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezna"), MinLength(5, ErrorMessage = "Lozinka ne smije biti krace od 5 karaktera")]
        public string Lozinka { get; set; }
        [Required(ErrorMessage ="JMBG je obavezan"),StringLength(13,MinimumLength =13, ErrorMessage ="JMBG mora biti 13 brojeva")]
        public string JMBG { get; set; }
        [Required(ErrorMessage = "Adresa je obavezna")]
        public string Adresa { get; set; }
        [Required, Range(0, int.MaxValue, ErrorMessage = "Odaberite tip korisnika")]
        public int UlogaId { get; set; }

        public List<Uloge> uloge { get; set; }
    }
}
