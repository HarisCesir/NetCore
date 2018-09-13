using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Elektrodistribucija.Web.Models;
using Elektrodistribucija.Web.Helper;
using Elektrodistribucija.Data.DAL;
using Elektrodistribucija.Data.Models;

namespace Elektrodistribucija.Web.Controllers
{
    public class HomeController : Controller
    {
        private MojContext _context;
        public HomeController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            MojDBInitializer.Izvrsi(_context);
            KorisnickiNalog korisnik = Autentifikacija.GetLogiraniKorisnik(HttpContext);


            if (korisnik == null)
            {
                return Redirect("/login");
            }

            if(korisnik.UlogaID==1)
            {
                return Redirect("/AdministratorModul/AdministratorHome");
            }
            if (korisnik.UlogaID == 2)
            {
                return Redirect("/ReferentZaKlijenteModul/ReferentZaKlijenteHome");
            }
            if (korisnik.UlogaID == 3)
            {
                return Redirect("/ServiserModul/ServiserHome");
            }



            return View();
        }
        
    }
}
