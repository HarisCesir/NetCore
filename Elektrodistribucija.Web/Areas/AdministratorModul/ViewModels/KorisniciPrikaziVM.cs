using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.AdministratorModul.ViewModels
{
    public class KorisniciPrikaziVM
    {
        public int KorisniciPrikaziID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string JMBG { get; set; }
        public string Adresa { get; set; }
        public string Uloga { get; set; }
       
    }
}
