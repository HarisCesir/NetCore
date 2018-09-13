using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elektrodistribucija.Data.DAL;
using Elektrodistribucija.Data.Models;
using Elektrodistribucija.Web.Areas.ReferentZaKlijenteModul.ViewModels;
using Elektrodistribucija.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elektrodistribucija.Web.Areas.ReferentZaKlijente.Controllers
{
    [Autorizacija(administrator: false, ReferentKlijenti: true, Serviser: false)]
    [Area("ReferentZaKlijenteModul")]
    public class ReferentZaKlijenteHomeController : Controller
    {
        private MojContext _context;
        public ReferentZaKlijenteHomeController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Klijenti> klijenti = _context.Klijenti.Include(x => x.Grad).ToList();

            return View("Index",klijenti);
        }
        public IActionResult DodajKlijenta()
        {
            List<Grad> gradovi = _context.Grad.ToList();
            ViewData["gradovi"] = gradovi;
            KlijentiVM model = new KlijentiVM();

            return PartialView("DodajKlijenta",model);
        }
        public IActionResult SnimiKlijenta(KlijentiVM klijent)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            
            Klijenti k = new Klijenti();
            k.Ime = klijent.Ime;
            k.Prezime = klijent.Prezime;
            k.JMBG = klijent.JMBG;
            k.GradID = klijent.GradID;
            k.Telefon = klijent.Telefon;
            k.Adresa = klijent.Adresa;

            _context.Klijenti.Add(k);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        
       
    }
}