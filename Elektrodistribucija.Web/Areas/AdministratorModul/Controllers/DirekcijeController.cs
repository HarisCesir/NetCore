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
    public class DirekcijeController : Controller
    {
        private MojContext _context;




        public DirekcijeController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dodaj()
        {
            ViewData["gradovi"] = _context.Grad.ToList();

            DirekcijeVM direkcije = new DirekcijeVM();

            return View("Dodaj",direkcije);
        }
        public IActionResult Snimi(DirekcijeVM direkcija)
        {
            if(!ModelState.IsValid)
            {
                ViewData["gradovi"] = _context.Grad.ToList();
                return View("Dodaj", direkcija);
            }
            Direkcija direkcije = new Direkcija
            {
                Adresa = direkcija.Adresa,
                GradID = direkcija.GradID
            };

            _context.Direkcija.Add(direkcije);
            _context.SaveChanges();

            return RedirectToAction("Prikazi");
        }

        public IActionResult Prikazi()
        {
            List<Direkcija> direkcije = _context.Direkcija.Include(x => x.Grad).ToList();
            return View("Prikazi",direkcije);
        }
        public IActionResult Obrisi(int id)
        {

            _context.Direkcija.Remove(_context.Direkcija.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();

            return RedirectToAction("Prikazi");

        }
        public IActionResult DodajGrad()
        {

            GradVM grad = new GradVM();
            return PartialView("DodajGrad",grad);
        }
        public IActionResult SnimiGrad(GradVM grad)
        {

            if(!ModelState.IsValid)
            {
                ViewData["gradovi"] = _context.Grad.ToList();

                DirekcijeVM direkcije = new DirekcijeVM();
                return View("Dodaj", direkcije);
            }
          

                _context.Grad.Add(new Grad
            {
                Naziv=grad.Naziv,
                PostanskiBroj=grad.PostanskiBroj
            });
            _context.SaveChanges();
            return RedirectToAction("Dodaj");
        }
    }
}