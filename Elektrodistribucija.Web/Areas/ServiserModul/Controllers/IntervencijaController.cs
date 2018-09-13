using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elektrodistribucija.Data.DAL;
using Elektrodistribucija.Data.Models;
using Elektrodistribucija.Web.Areas.AdministratorModul.ViewModels;
using Elektrodistribucija.Web.Areas.ServiserModul.Models;
using Elektrodistribucija.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elektrodistribucija.Web.Areas.ServiserModul.Controllers
{
    [Autorizacija(administrator: true, ReferentKlijenti: false,  Serviser: true)]
    [Area("ServiserModul")]
    public class IntervencijaController : Controller
    {
        private MojContext _context;
        public IntervencijaController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dodaj()
        { 
            IntervencijaVM model = new IntervencijaVM();

            ViewData["serviser"] = _context.Serviser.ToList();
            ViewData["prijavakvara"] = _context.PrijavaKvara.ToList();
            ViewData["oprema"] = _context.Oprema.ToList();
            return View("Dodaj", model);
        }
        public IActionResult Snimi(IntervencijaVM intervencija)
        {
            if (ModelState.IsValid)
            {

                Intervencija o = new Intervencija();
                o.Alati = intervencija.Alati;
                o.Datum = intervencija.Datum;
                o.Lokacija = intervencija.Lokacija;
                o.PrijavaKvaraID = intervencija.PrijavaKvaraID;
                o.ServiserID = intervencija.ServiserID;
                o.Trajanje = intervencija.Trajanje;
                o.Troskovi = intervencija.Troskovi;
                o.OpremaID = intervencija.OpremaID;
                _context.Intervencija.Add(o);
                _context.SaveChanges();

            }
            return RedirectToAction("Dodaj");
        }
        public IActionResult Prikazi()
        {
            List<Intervencija> intervencijas = _context.Intervencija.Include(x => x.Serviser).ToList();

            intervencijas = _context.Intervencija.Include(x => x.Oprema).ToList();

            intervencijas = _context.Intervencija.Include(x => x.PrijavaKvara).ToList();
            
            return View("Prikazi", intervencijas);

        }

        public IActionResult Obrisi(int id)
        {
            if (_context.Intervencija.SingleOrDefault(x => x.Id == id) != null)
            { 
            _context.Intervencija.Remove(_context.Intervencija.FirstOrDefault(x => x.Id == id));

                _context.SaveChanges();

                return RedirectToAction("Prikazi");
            }

            return View("Prikazi");
        }
        public IActionResult Izmjeni(int id)
        {
            ViewData["serviser"] = _context.Serviser.ToList();
            ViewData["prijavakvara"] = _context.PrijavaKvara.ToList();
            ViewData["oprema"] = _context.Oprema.ToList();

            Intervencija intervencija = _context.Intervencija.SingleOrDefault(x => x.Id == id);

            return View("Izmjeni", intervencija);
        }

        public IActionResult SnimiIzmjene(Intervencija intervencija)
        {

            _context.Intervencija.Update(intervencija);
            _context.SaveChanges();

            return RedirectToAction("Prikazi");
        }
    }
}