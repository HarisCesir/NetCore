using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.ViewModels
{
    public class LoginVM
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public bool zapamtiPassword { get; set; }
    }
}
