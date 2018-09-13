using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elektrodistribucija.Data.DAL;
using Elektrodistribucija.Data.Models;
using Elektrodistribucija.Web.Areas.ReferentZaKlijenteModul.ViewModels;
using Elektrodistribucija.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Elektrodistribucija.Web.Areas.ReferentZaKlijenteModul.Controllers
{
    [Autorizacija(administrator: false, ReferentKlijenti: true, Serviser: false)]
    [Area("ReferentZaKlijenteModul")]
    public class CijenaController : Controller
    {
        private MojContext _context;
        public CijenaController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
       public IActionResult Cijena()
        {
            CijenaVM cijena= new CijenaVM();

            cijena.CijenaKwhJeftina = _context.Cijena.FirstOrDefault().CijenaKwHJeftina;
            cijena.CijenaKwhSkupa = _context.Cijena.FirstOrDefault().CijenaKwhSkupa;


            return View("Cijena",cijena);
        }
        public IActionResult Snimi(CijenaVM cijena)
        {
            CijenaKwh cij = _context.Cijena.FirstOrDefault();
            cij.CijenaKwHJeftina = cijena.CijenaKwhJeftina;
            cij.CijenaKwhSkupa = cijena.CijenaKwhSkupa;

            _context.Cijena.Update(cij);
            _context.SaveChanges();

            return RedirectToAction("Cijena");
        }
    }
}