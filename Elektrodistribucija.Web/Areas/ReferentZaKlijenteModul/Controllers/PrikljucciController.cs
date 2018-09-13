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

namespace Elektrodistribucija.Web.Areas.ReferentZaKlijenteModul.Controllers
{
    [Autorizacija(administrator: false, ReferentKlijenti: true, Serviser: false)]
    [Area("ReferentZaKlijenteModul")]
    public class PrikljucciController : Controller
    {
        private MojContext _context;
        public PrikljucciController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Prikazi(int KlijentID)
        {
            ViewData["Klijent"] = _context.Klijenti.FirstOrDefault(x => x.Id == KlijentID);
            List<Prikljucak> prikljucci = _context.Prikljucak.Include(x => x.Grad).Where(a => a.KlijentID == KlijentID).ToList();
            return View("Prikazi",prikljucci);
        }
        public IActionResult DodajPrikljucak(int KlijentID)
        {
            ViewData["Gradovi"] = _context.Grad.ToList();
            PrikljucciVM model = new PrikljucciVM();

            model.KlijentID = KlijentID;
            return PartialView("DodajPrikljucak",model);
        }
        public IActionResult SnimiPrikljucak(PrikljucciVM prikljucak)
        {
            Prikljucak p = new Prikljucak();
            p.DatumPrikljucenja = prikljucak.Datum;
            p.KlijentID = prikljucak.KlijentID;
            p.GradID = prikljucak.GradID;
            p.Adresa = prikljucak.Adresa;
            p.Parcela = prikljucak.Parcela;

            _context.Prikljucak.Add(p);
            _context.SaveChanges();

            return RedirectToAction("Prikazi",new {KlijentID=prikljucak.KlijentID });
        }
        public IActionResult PrivremenoIskljucenje(int PrikljucakID)
        {
           
                PrivremenoIskljucenjeVM privremenoIskljucenje = new PrivremenoIskljucenjeVM();
                if (_context.PrivremenoIskljucenje.FirstOrDefault(x => x.PrikljucakID == PrikljucakID) != null)
                {
                    PrivremenoIskljucenje p = _context.PrivremenoIskljucenje.FirstOrDefault(x => x.PrikljucakID == PrikljucakID);

                    privremenoIskljucenje.Datum = p.Datum;
                    privremenoIskljucenje.Razlog = p.Razlog;
                    privremenoIskljucenje.PrikljucakID = p.PrikljucakID;

                }
                else
                {
                    privremenoIskljucenje.PrikljucakID = PrikljucakID;
                    privremenoIskljucenje.Datum = DateTime.Now;

                }


                return PartialView("PrivremenoIskljucenje", privremenoIskljucenje);
            
        }
        public IActionResult SnimiPrivremenoIskljucenje(PrivremenoIskljucenjeVM privremenoIskljucenjeVM)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Prikazi", new { KlijentID = _context.Prikljucak.FirstOrDefault(x => x.Id == privremenoIskljucenjeVM.PrikljucakID).KlijentID });

            }
            PrivremenoIskljucenje p = new Data.Models.PrivremenoIskljucenje();

            p.Datum = privremenoIskljucenjeVM.Datum;
            p.Razlog = privremenoIskljucenjeVM.Razlog;
            p.PrikljucakID = privremenoIskljucenjeVM.PrikljucakID;

           
                if (_context.PrivremenoIskljucenje.FirstOrDefault(x => x.PrikljucakID == privremenoIskljucenjeVM.PrikljucakID) != null)
                {
                    PrivremenoIskljucenje privremeno = _context.PrivremenoIskljucenje.FirstOrDefault(x => x.PrikljucakID == privremenoIskljucenjeVM.PrikljucakID);

                    privremeno.Datum = privremenoIskljucenjeVM.Datum;
                    privremeno.Razlog = privremenoIskljucenjeVM.Razlog;

                    _context.PrivremenoIskljucenje.Update(privremeno);
                    _context.SaveChanges();


                }
                else
                {
                    _context.PrivremenoIskljucenje.Add(p);
                    _context.SaveChanges();
                }

                return RedirectToAction("Prikazi", new { KlijentID = _context.Prikljucak.FirstOrDefault(x => x.Id == privremenoIskljucenjeVM.PrikljucakID).KlijentID });
           
        }
        public IActionResult Brojilo(int PrikljucakID)
        {
            BrojiloVM brojilo = new BrojiloVM();
           if(_context.Brojilo.FirstOrDefault(x=>x.PrikljucakID==PrikljucakID)!=null)
            {
                Brojilo b =_context.Brojilo.FirstOrDefault(x => x.PrikljucakID == PrikljucakID);
                brojilo.StaroStanjeJeftina = b.StaroStanjeJeftina;

                brojilo.StatoStanjeSkupa = b.StaroStanjeSkupa; 
                brojilo.TrenutnoStanjeJeftina = b.TrenutnoStanjeJeftina; ;
                brojilo.TrenutnoStanjeSkupa = b.TrenutnoStanjeSkupa;
                brojilo.Datum = DateTime.Now;
                brojilo.PrikljucakID = PrikljucakID;
                brojilo.BrojiloID = b.Id;

                return PartialView("Brojilo", brojilo);
            }
           else
            {
                brojilo.StaroStanjeJeftina = 0;
                brojilo.StatoStanjeSkupa = 0;
                brojilo.TrenutnoStanjeJeftina = 0;
                brojilo.TrenutnoStanjeSkupa = 0;
                brojilo.PrikljucakID = PrikljucakID;
                brojilo.Datum = DateTime.Now;
                brojilo.BrojiloID = 0;
                return PartialView("Brojilo", brojilo);

            }
        }
        public IActionResult SnimiBrojilo(BrojiloVM brojilo)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Prikazi", new { KlijentID = _context.Prikljucak.FirstOrDefault(x => x.Id == brojilo.PrikljucakID).KlijentID });

            }
            Brojilo b = new Data.Models.Brojilo();
            if(_context.Brojilo.FirstOrDefault(x=>x.Id==brojilo.BrojiloID)!=null)
            {
                b = _context.Brojilo.FirstOrDefault(x => x.Id == brojilo.BrojiloID);
                b.StaroStanjeJeftina = b.TrenutnoStanjeJeftina;
                b.StaroStanjeSkupa = b.TrenutnoStanjeSkupa;
                b.TrenutnoStanjeJeftina = brojilo.TrenutnoStanjeJeftina;
                b.TrenutnoStanjeSkupa = brojilo.TrenutnoStanjeSkupa;
                _context.Brojilo.Update(b);
                _context.SaveChanges();

                CijenaKwh cijena = _context.Cijena.FirstOrDefault();

                Racun racun = new Racun();
                racun.Potrosnja_jeftina = brojilo.TrenutnoStanjeJeftina - brojilo.StaroStanjeJeftina;
                racun.Potrosnja_Skupa = brojilo.TrenutnoStanjeSkupa - brojilo.StatoStanjeSkupa;
                racun.BrojiloID = brojilo.BrojiloID;
                racun.Ukupno = racun.Potrosnja_jeftina * cijena.CijenaKwHJeftina + racun.Potrosnja_Skupa * cijena.CijenaKwhSkupa;
                racun.Mjesec = DateTime.Now.Month.ToString();
                racun.CijenaId = cijena.Id;
                if(_context.Dugovanja.FirstOrDefault(x=>x.BrojiloID==brojilo.BrojiloID)!=null)
                {
                    racun.Dug = _context.Dugovanja.FirstOrDefault(x => x.BrojiloID == brojilo.BrojiloID).Ukupno;

                    Dugovanja d = _context.Dugovanja.FirstOrDefault(x => x.BrojiloID == brojilo.BrojiloID);
                    d.RacuniUkupno = d.RacuniUkupno + racun.Ukupno;
                    d.Ukupno = d.RacuniUkupno - d.Uplata;
                    _context.Dugovanja.Update(d);
                    _context.SaveChanges();

                }
                else
                {
                    Dugovanja dug = new Dugovanja();
                    dug.BrojiloID = brojilo.BrojiloID;
                    dug.RacuniUkupno = _context.Racun.Where(x => x.BrojiloID == brojilo.BrojiloID).Select(x => x.Ukupno).Sum() + racun.Ukupno;
                    dug.Uplata = 0;
                    dug.Ukupno = dug.RacuniUkupno - dug.Uplata;

                    _context.Dugovanja.Add(dug);
                    _context.SaveChanges();

                    racun.Dug= _context.Racun.Where(x => x.BrojiloID == brojilo.BrojiloID).Select(x => x.Ukupno).Sum();
                }
               
                _context.Racun.Add(racun);
                _context.SaveChanges();

                return RedirectToAction("Prikazi", new { KlijentID = _context.Prikljucak.FirstOrDefault(x => x.Id == brojilo.PrikljucakID).KlijentID });
            }
            else
            {
                b.StaroStanjeJeftina = brojilo.TrenutnoStanjeJeftina;
                b.StaroStanjeSkupa = brojilo.TrenutnoStanjeSkupa;
                b.TrenutnoStanjeJeftina = brojilo.TrenutnoStanjeJeftina;
                b.TrenutnoStanjeSkupa = brojilo.TrenutnoStanjeSkupa;
                b.PrikljucakID = brojilo.PrikljucakID;
                b.Datum = brojilo.Datum;
                _context.Brojilo.Add(b);
                _context.SaveChanges();
                Brojilo bro = _context.Brojilo.FirstOrDefault(x => x.PrikljucakID == brojilo.PrikljucakID);
               

                CijenaKwh cijena = _context.Cijena.FirstOrDefault();

                Racun racun = new Racun();
                racun.Potrosnja_jeftina = brojilo.TrenutnoStanjeJeftina - brojilo.StaroStanjeJeftina;
                racun.Potrosnja_Skupa = brojilo.TrenutnoStanjeSkupa - brojilo.StatoStanjeSkupa;
                racun.BrojiloID = bro.Id;
                racun.Ukupno = racun.Potrosnja_jeftina * cijena.CijenaKwHJeftina + racun.Potrosnja_Skupa * cijena.CijenaKwhSkupa;
                racun.Mjesec = DateTime.Now.Month.ToString();
                racun.CijenaId = cijena.Id;
                racun.Dug = 0;
                    Dugovanja dug = new Dugovanja();
                    dug.BrojiloID = bro.Id;
                    dug.RacuniUkupno = _context.Racun.Where(x => x.BrojiloID == brojilo.BrojiloID).Select(x => x.Ukupno).Sum() + racun.Ukupno;
                  dug.Uplata = 0;
                    dug.Ukupno = dug.RacuniUkupno - dug.Uplata;
                    _context.Dugovanja.Add(dug);
                    _context.SaveChanges();
                

                _context.Racun.Add(racun);
                _context.SaveChanges();
                return RedirectToAction("Prikazi", new { KlijentID= _context.Prikljucak.FirstOrDefault(x=>x.Id==brojilo.PrikljucakID).KlijentID });
            }
        }

        public IActionResult Opomene(int PrikljucakID)
        {
            TempData["prikljucakid"] = PrikljucakID;
            List<Opomena> opomene = _context.Opomena.Where(x => x.PrikljucakID == PrikljucakID).ToList();

            return View("Opomene", opomene);
        }
        public IActionResult DodajOpomenu(int prikljucakID)
        {
          
            OpomenaVM opomena = new OpomenaVM();
            opomena.PrikljucakID = prikljucakID;

            return PartialView("DodajOpomenu", opomena);
        }
        public IActionResult SnimiOpomenu(OpomenaVM opomena)
        {
            Opomena o = new Opomena();
            o.Datum = opomena.Datum;
            o.Sadrzaj = opomena.Sadrzaj;
            o.PrikljucakID = opomena.PrikljucakID;

            _context.Opomena.Add(o);
            _context.SaveChanges();

            return RedirectToAction("Opomene", new { PrikljucakID = opomena.PrikljucakID });
        }

        public IActionResult Racuni(int PrikljucakId)
        {
            List<Racun> racuni = new List<Racun>();
            Brojilo brojilo = _context.Brojilo.FirstOrDefault(x => x.PrikljucakID == PrikljucakId);

            ViewData["dug"] = 0;

            if(brojilo!=null)
            {
                racuni = _context.Racun.Where(x => x.BrojiloID == brojilo.Id).ToList();
                ViewData["dug"] = _context.Dugovanja.SingleOrDefault(x => x.BrojiloID == brojilo.Id).Ukupno;
            }
            
            

            return View("Racuni",racuni);
        }
        public IActionResult PlatiRacun(int BrojiloId)
        {
            Uplata uplata = new Uplata();
            uplata.BrojiloID = BrojiloId;

            return PartialView("PlatiRacun",uplata);
        }
        public IActionResult SnimiUplatu(Uplata uplata)
        {
            uplata.Datum = DateTime.Now;

            Dugovanja dug = _context.Dugovanja.FirstOrDefault(x => x.BrojiloID == uplata.BrojiloID);
            dug.Uplata = uplata.Iznos;
            dug.Ukupno = dug.Ukupno - dug.Uplata;
            _context.Dugovanja.Update(dug);

            
            _context.Uplata.Add(uplata);
            _context.SaveChanges();

            int PrikljucakId = _context.Brojilo.FirstOrDefault(x => x.Id == uplata.BrojiloID).PrikljucakID;

            return RedirectToAction("Racuni", new { PrikljucakId = PrikljucakId });
        }
        
    }
}