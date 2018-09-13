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
    [Autorizacija(administrator: true, ReferentKlijenti: false, Serviser: true)]
    [Area("ServiserModul")]
    public class PrijavaKvaraController : Controller
    {
        private MojContext _context;
        public PrijavaKvaraController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dodaj()
        {
            PrijavaKvaraVM model = new PrijavaKvaraVM();

            ViewData["tipkvara"] = _context.TipKvara.ToList();
            ViewData["prikljucak"] = _context.Prikljucak.ToList();
            return View("Dodaj", model);
        }
        public IActionResult Snimi(PrijavaKvaraVM prijavaKvaraVM)
        {
            if (!ModelState.IsValid)
            {
                ViewData["tipkvara"] = _context.TipKvara.ToList();
                ViewData["prikljucak"] = _context.Prikljucak.ToList();
                return View("Dodaj", prijavaKvaraVM);
            }
            PrijavaKvara o = new PrijavaKvara();
            o.Opis = prijavaKvaraVM.Opis;
            o.Prikljucak = prijavaKvaraVM.Prikljucak;
            o.PrikljucakID = prijavaKvaraVM.PrikljucakID;
            o.Status = prijavaKvaraVM.Status;
            o.TipKvara = prijavaKvaraVM.TipKvara;
            o.TipKvaraID = prijavaKvaraVM.TipKvaraID;
            _context.PrijavaKvara.Add(o);
            _context.SaveChanges();

            return RedirectToAction("Dodaj");
        }
        public IActionResult Prikazi()
        {
            List<PrijavaKvara> prijavaKvaras = _context.PrijavaKvara.Include(x => x.TipKvara).ToList();
            prijavaKvaras = _context.PrijavaKvara.Include(x => x.Prikljucak).ToList();

            return View("Prikazi", prijavaKvaras);
        }

        public IActionResult Obrisi(int id)
        {
            _context.PrijavaKvara.Remove(_context.PrijavaKvara.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();

            return RedirectToAction("Prikazi");
        }
    }
}