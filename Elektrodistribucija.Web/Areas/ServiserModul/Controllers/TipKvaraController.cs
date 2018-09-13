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

namespace Elektrodistribucija.Web.Areas.ServiserModul.Controllers
{
    [Autorizacija(administrator: true, ReferentKlijenti: false,  Serviser: true)]
    [Area("ServiserModul")]
    public class TipKvaraController : Controller
    {
        private MojContext _context;
        public TipKvaraController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dodaj()
        {
            return View("Dodaj");
        }
        public IActionResult Snimi(OpremaVM oprema)
        {
            if (ModelState.IsValid)
            {


                TipKvara o = new TipKvara();
                o.Naziv = oprema.Naziv;

                _context.TipKvara.Add(o);
                _context.SaveChanges();

                return RedirectToAction("Dodaj");
            }
            return View("Dodaj",oprema);
        }
        public IActionResult Prikazi()
        {
            List<TipKvara> tipkvara = _context.TipKvara.ToList();

            return View("Prikazi", tipkvara);
        }

        public IActionResult Obrisi(int id)
        {
            if (_context.TipKvara.SingleOrDefault(x => x.Id == id) != null)
            { 
            _context.TipKvara.Remove(_context.TipKvara.FirstOrDefault(x => x.Id == id));

                _context.SaveChanges();

                return RedirectToAction("Prikazi");
            }

            return View("Prikazi");
        }
        public IActionResult Izmjeni(int id)
        {

            TipKvara tipkv = _context.TipKvara.SingleOrDefault(x => x.Id == id);

            return View("Izmjeni", tipkv);
        }

        public IActionResult SnimiIzmjene(TipKvara tipkvara)
        {

            _context.TipKvara.Update(tipkvara);
            _context.SaveChanges();

            return RedirectToAction("Prikazi");
        }
    }
}