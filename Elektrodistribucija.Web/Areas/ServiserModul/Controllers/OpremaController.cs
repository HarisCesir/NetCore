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
    public class OpremaController : Controller
    {
        private MojContext _context;
        public OpremaController(MojContext context)
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


                Oprema o = new Oprema();
                o.Naziv = oprema.Naziv;

                _context.Oprema.Add(o);
                _context.SaveChanges();

                return RedirectToAction("Dodaj");
            }
            return View("Dodaj",oprema);
        }
        public IActionResult Prikazi()
        {
            List<Oprema> oprema = _context.Oprema.ToList();

            return View("Prikazi",oprema);
        }

        public IActionResult Obrisi(int id)
        {
            if (_context.Oprema.SingleOrDefault(x => x.Id == id) != null)
            { 
            _context.Oprema.Remove(_context.Oprema.FirstOrDefault(x => x.Id == id));

                _context.SaveChanges();

                return RedirectToAction("Prikazi");
            }

            return View("Prikazi");
        }

        public IActionResult Izmjeni(int id)
        {
           
            Oprema opr=_context.Oprema.SingleOrDefault(x => x.Id == id);

            return View("Izmjeni",opr);
        }

        public IActionResult SnimiIzmjene(Oprema oprema)
        {

            _context.Oprema.Update(oprema);
            _context.SaveChanges();

            return RedirectToAction("Prikazi");
        }


    }
}