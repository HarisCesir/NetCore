using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elektrodistribucija.Data.DAL;
using Elektrodistribucija.Data.Models;
using Elektrodistribucija.Web.Helper;
using Elektrodistribucija.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Elektrodistribucija.Web.Controllers
{
    [Autorizacija(administrator:true,ReferentKlijenti:true,Serviser:true)]
    public class SesijeController : Controller
    {
        private MojContext _context;
        public SesijeController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            SesijaIndexVM model = new SesijaIndexVM();
            model.Rows = _context.AutorizacijaToken.Select(x => new SesijaIndexVM.Row
            {
                VrijemeLogiranja = x.VrijemeEvidentiranja,
                token = x.Vrijednost,
                IPAdresa = x.IpAdresa

            }).ToList();

            model.TrenutniToken = HttpContext.GetTrenutniToken();
            KorisnickiNalog korisnik = Autentifikacija.GetLogiraniKorisnik(HttpContext);
           
            ViewData["permisija"] = _context.Uloge.FirstOrDefault(x => x.Id == korisnik.UlogaID).NazivUloge.ToString();

            return View(model);
        }
        public IActionResult Obrisi(string token)
        {
            var obrisati = _context.AutorizacijaToken.FirstOrDefault(x => x.Vrijednost == token);
            if(obrisati!=null)
            {
                _context.AutorizacijaToken.Remove(obrisati);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}