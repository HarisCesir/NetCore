using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elektrodistribucija.Data.DAL;
using Elektrodistribucija.Data.Models;
using Elektrodistribucija.Web.Areas.AdministratorModul.ViewModels;
using Elektrodistribucija.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elektrodistribucija.Web.Areas.AdministratorModul.Controllers
{
    [Autorizacija(administrator: true, ReferentKlijenti: false,  Serviser: false)]
    [Area("AdministratorModul")]
    public class OdjelController : Controller
    {
        private MojContext _context;
        public OdjelController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dodaj()
        {
            DodajOdjelVM model = new DodajOdjelVM();

            ViewData["direkcije"] = _context.Direkcija.ToList();
            return View("Dodaj",model);
        }
        public IActionResult Snimi(DodajOdjelVM odjel)
        {
            if(!ModelState.IsValid)
            {
                ViewData["direkcije"] = _context.Direkcija.ToList();

                return View("Dodaj", odjel);
            }
            Odjel o = new Odjel();
            o.DirekcijaID = odjel.DirekcijaID;
            o.Adresa = odjel.Adresa;

            o.Svrha = odjel.Svrha;

            _context.Odjel.Add(o);
            _context.SaveChanges();

            return RedirectToAction("Dodaj");
        }
        public IActionResult Prikazi()
        {
            List<Odjel> Odjeli = _context.Odjel.Include(x => x.Direkcija).ToList();

            return View("Prikazi", Odjeli);
        }
        public IActionResult Obrisi(int id)
        {
            _context.Odjel.Remove(_context.Odjel.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();

            return RedirectToAction("Prikazi");

        }
    }
}