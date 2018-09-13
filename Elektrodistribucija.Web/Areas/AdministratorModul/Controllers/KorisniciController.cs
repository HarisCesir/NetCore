using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elektrodistribucija.Data.DAL;
using Elektrodistribucija.Data.Models;
using Elektrodistribucija.Web.Areas.AdministratorModul.ViewModels;
using Elektrodistribucija.Web.Helper;
using Elektrodistribucija.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elektrodistribucija.Web.Areas.AdministratorModul.Controllers
{
    [Autorizacija(administrator: true, ReferentKlijenti: false,  Serviser: false)]
    [Area("AdministratorModul")]
    public class KorisniciController : Controller
    {
        private MojContext _context;
        

        

        public KorisniciController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dodaj()
        {
            KorisniciDodajVM korisnici = new KorisniciDodajVM();
            korisnici.uloge = new List<Uloge>();
           
            List<Uloge> uloge = _context.Uloge.ToList();

            foreach(Uloge u in uloge)
            {

                korisnici.uloge.Add(u);
            }


            return View("Dodaj",korisnici);
        }
        public IActionResult Snimi(KorisniciDodajVM korisnik)
        {
            if (!ModelState.IsValid)
            {
                KorisniciDodajVM korisnici = new KorisniciDodajVM();
                korisnici.uloge = new List<Uloge>();

                List<Uloge> uloge = _context.Uloge.ToList();

                foreach (Uloge u in uloge)
                {

                    korisnici.uloge.Add(u);
                }
                return View("Dodaj", korisnici);
            }



            Uloge uloga = _context.Uloge.FirstOrDefault(x => x.Id == korisnik.UlogaId);

            if(uloga.NazivUloge=="Administrator")
            {
                Administrator administrator = new Administrator
                {
                    Ime = korisnik.Ime,
                    Prezime = korisnik.Prezime,
                    Telefon = korisnik.Telefon,
                    JMBG = korisnik.JMBG,
                    Adresa = korisnik.Adresa,
                    KorisnickiNalog = new KorisnickiNalog
                    {
                        KorisnickoIme = korisnik.KorisnickoIme,
                        Lozinka = korisnik.Lozinka,
                        UlogaID = korisnik.UlogaId
                    }
                };

                _context.Administrator.Add(administrator);
                _context.SaveChanges();
                return RedirectToAction("Prikazi");
            }

            if(uloga.NazivUloge== "Referent za klijente")
            {
                ReferentKlijenti Rklijenti = new ReferentKlijenti
                {
                    Ime = korisnik.Ime,
                    Prezime = korisnik.Prezime,
                    Telefon = korisnik.Telefon,
                    JMBG = korisnik.JMBG,
                    Adresa = korisnik.Adresa,
                    KorisnickiNalog = new KorisnickiNalog
                    {
                        KorisnickoIme = korisnik.KorisnickoIme,
                        Lozinka = korisnik.Lozinka,
                        UlogaID = korisnik.UlogaId
                    }
                };
                _context.ReferentKlijenti.Add(Rklijenti);
                _context.SaveChanges();
                return RedirectToAction("Prikazi");
            }

           


            if (uloga.NazivUloge == "Serviser")
            {
               Serviser serviser = new Serviser
                {
                    Ime = korisnik.Ime,
                    Prezime = korisnik.Prezime,
                    Telefon = korisnik.Telefon,
                    JMBG = korisnik.JMBG,
                    Adresa = korisnik.Adresa,
                    KorisnickiNalog = new KorisnickiNalog
                    {
                        KorisnickoIme = korisnik.KorisnickoIme,
                        Lozinka = korisnik.Lozinka,
                        UlogaID = korisnik.UlogaId
                    }
                };
                _context.Serviser.Add(serviser);
                _context.SaveChanges();
                return RedirectToAction("Prikazi");
            }


            return RedirectToAction("Prikazi");







        }

        public IActionResult Prikazi()
        {

           List<KorisniciPrikaziVM> korisnici = new List<KorisniciPrikaziVM>();

            List<Administrator> administratori = _context.Administrator.Include(x => x.KorisnickiNalog).ThenInclude(y => y.Uloga).ToList();
            List<ReferentKlijenti> referentZaklijente = _context.ReferentKlijenti.Include(x => x.KorisnickiNalog).ThenInclude(y => y.Uloga).ToList();
            List<Serviser> serviser = _context.Serviser.Include(x => x.KorisnickiNalog).ThenInclude(y => y.Uloga).ToList();

           
            foreach(Administrator a in administratori)
            {
                KorisniciPrikaziVM k = new KorisniciPrikaziVM
                {
                    
                    Ime = a.Ime,
                    Prezime = a.Prezime,
                    KorisnickoIme = a.KorisnickiNalog.KorisnickoIme,
                    Lozinka = a.KorisnickiNalog.Lozinka,
                    Telefon = a.Telefon,
                    JMBG = a.JMBG,
                    Adresa = a.Adresa,
                    Uloga = a.KorisnickiNalog.Uloga.NazivUloge,
                    KorisniciPrikaziID=Convert.ToInt32(a.KorisnickiNalogId)
                };

                korisnici.Add(k);
               
            }

            foreach (ReferentKlijenti a in referentZaklijente)
            {
                KorisniciPrikaziVM k = new KorisniciPrikaziVM
                {
                    Ime = a.Ime,
                    Prezime = a.Prezime,
                    KorisnickoIme = a.KorisnickiNalog.KorisnickoIme,
                    Lozinka = a.KorisnickiNalog.Lozinka,
                    Telefon = a.Telefon,
                    JMBG = a.JMBG,
                    Adresa = a.Adresa,
                    Uloga = a.KorisnickiNalog.Uloga.NazivUloge,
                    KorisniciPrikaziID = Convert.ToInt32(a.KorisnickiNalogId)
                };

                korisnici.Add(k);

            }

           
            foreach (Serviser a in serviser)
            {
                KorisniciPrikaziVM k = new KorisniciPrikaziVM
                {
                    Ime = a.Ime,
                    Prezime = a.Prezime,
                    KorisnickoIme = a.KorisnickiNalog.KorisnickoIme,
                    Lozinka = a.KorisnickiNalog.Lozinka,
                    Telefon = a.Telefon,
                    JMBG = a.JMBG,
                    Adresa = a.Adresa,
                    Uloga = a.KorisnickiNalog.Uloga.NazivUloge,
                    KorisniciPrikaziID = Convert.ToInt32(a.KorisnickiNalogId)
                };

                korisnici.Add(k);

            }




            return View("Prikazi",korisnici);
        }

        
        public IActionResult Obrisi(int id)
        {
            
            if(_context.Administrator.SingleOrDefault(x=>x.KorisnickiNalogId==id)!=null)
            {
                _context.Administrator.Remove(_context.Administrator.FirstOrDefault(x => x.KorisnickiNalogId == id));
                _context.KorisnickiNalog.Remove(_context.KorisnickiNalog.FirstOrDefault(x => x.Id == id));
                _context.SaveChanges();
               
                return RedirectToAction("Prikazi");
            }

            if (_context.ReferentKlijenti.SingleOrDefault(x => x.KorisnickiNalogId == id) != null)
            {
                _context.ReferentKlijenti.Remove(_context.ReferentKlijenti.FirstOrDefault(x => x.KorisnickiNalogId == id));
                _context.KorisnickiNalog.Remove(_context.KorisnickiNalog.FirstOrDefault(x => x.Id == id));
                _context.SaveChanges();
                return RedirectToAction("Prikazi");
            }

           

            if (_context.Serviser.SingleOrDefault(x => x.KorisnickiNalogId == id) != null)
            {
                _context.Serviser.Remove(_context.Serviser.FirstOrDefault(x => x.KorisnickiNalogId == id));
                _context.KorisnickiNalog.Remove(_context.KorisnickiNalog.FirstOrDefault(x => x.Id == id));
                _context.SaveChanges();
                return RedirectToAction("Prikazi");
            }
            return RedirectToAction("Prikazi");
        }
        public IActionResult Izmjeni(int id)
        {

            KorisnickiNalog nalog = _context.KorisnickiNalog.FirstOrDefault(x => x.Id == id);
            KorisniciDodajVM korisn = new KorisniciDodajVM();
            Uloge u = _context.Uloge.FirstOrDefault(x => x.Id == nalog.UlogaID);
          if (u.NazivUloge=="Administrator")
            {
                Administrator a = _context.Administrator.SingleOrDefault(x => x.KorisnickiNalogId == nalog.Id);


               korisn.Ime = a.Ime;
                korisn.Prezime = a.Prezime;
               korisn.Telefon = a.Telefon;
               korisn.JMBG = a.JMBG;
               korisn.Adresa = a.Adresa;
               korisn.KorisnickoIme = nalog.KorisnickoIme;
               korisn.Lozinka = nalog.Lozinka;
               korisn.UlogaId = Convert.ToInt32(nalog.UlogaID);
                

                korisn.uloge = new List<Uloge>();
                List<Uloge> ulog = _context.Uloge.ToList();

                foreach (Uloge ulo in ulog)
                {

                    korisn.uloge.Add(ulo);
                }
                
            }
            if (u.NazivUloge == "Referent za klijente")
            {
                ReferentKlijenti a = _context.ReferentKlijenti.SingleOrDefault(x => x.KorisnickiNalogId == nalog.Id);


                korisn.Ime = a.Ime;
                korisn.Prezime = a.Prezime;
                korisn.Telefon = a.Telefon;
                korisn.JMBG = a.JMBG;
                korisn.Adresa = a.Adresa;
                korisn.KorisnickoIme = nalog.KorisnickoIme;
                korisn.Lozinka = nalog.Lozinka;
                korisn.UlogaId = Convert.ToInt32(nalog.UlogaID);


                korisn.uloge = new List<Uloge>();
                List<Uloge> ulog = _context.Uloge.ToList();

                foreach (Uloge ulo in ulog)
                {

                    korisn.uloge.Add(ulo);
                }

            }
            
            if (u.NazivUloge == "Serviser")
            {
                Serviser a = _context.Serviser.SingleOrDefault(x => x.KorisnickiNalogId == nalog.Id);


                korisn.Ime = a.Ime;
                korisn.Prezime = a.Prezime;
                korisn.Telefon = a.Telefon;
                korisn.JMBG = a.JMBG;
                korisn.Adresa = a.Adresa;
                korisn.KorisnickoIme = nalog.KorisnickoIme;
                korisn.Lozinka = nalog.Lozinka;
                korisn.UlogaId = Convert.ToInt32(nalog.UlogaID);


                korisn.uloge = new List<Uloge>();
                List<Uloge> ulog = _context.Uloge.ToList();

                foreach (Uloge ulo in ulog)
                {

                    korisn.uloge.Add(ulo);
                }

            }

            return View("Izmjeni", korisn);


        }
        public IActionResult Update(KorisniciDodajVM korisnik)
        {
            Uloge uloga = _context.Uloge.FirstOrDefault(x => x.Id == korisnik.UlogaId);
            KorisnickiNalog korisnickiNalog = _context.KorisnickiNalog.SingleOrDefault(x => x.KorisnickoIme == korisnik.KorisnickoIme);


            korisnickiNalog.Lozinka = korisnik.Lozinka;
            korisnickiNalog.UlogaID = korisnik.UlogaId;

            _context.KorisnickiNalog.Update(korisnickiNalog);
            
            _context.SaveChanges();

            if (uloga.NazivUloge=="Administrator")
            {
                Administrator administrator = _context.Administrator.SingleOrDefault(x => x.KorisnickiNalog == korisnickiNalog);

                administrator.Ime = korisnik.Ime;
                administrator.Prezime = korisnik.Prezime;
                administrator.Telefon = korisnik.Telefon;
                administrator.Adresa = korisnik.Adresa;
                administrator.JMBG = korisnik.JMBG;

                _context.Administrator.Update(administrator);
                _context.SaveChanges();
            }

            if (uloga.NazivUloge == "Referent za klijente")
            {
                ReferentKlijenti referentKlijenti= _context.ReferentKlijenti.SingleOrDefault(x => x.KorisnickiNalog == korisnickiNalog);

                referentKlijenti.Ime = korisnik.Ime;
                referentKlijenti.Prezime = korisnik.Prezime;
                referentKlijenti.Telefon = korisnik.Telefon;
                referentKlijenti.Adresa = korisnik.Adresa;
                referentKlijenti.JMBG = korisnik.JMBG;

                _context.ReferentKlijenti.Update(referentKlijenti);
                _context.SaveChanges();
            }


          
            if (uloga.NazivUloge == "Serviser")
            {
                Serviser serviser = _context.Serviser.SingleOrDefault(x => x.KorisnickiNalog == korisnickiNalog);

                serviser.Ime = korisnik.Ime;
                serviser.Prezime = korisnik.Prezime;
                serviser.Telefon = korisnik.Telefon;
                serviser.Adresa = korisnik.Adresa;
                serviser.JMBG = korisnik.JMBG;

                _context.Serviser.Update(serviser);
                _context.SaveChanges();
            }
            return RedirectToAction("Prikazi");
        }

        public IActionResult DodajPlatu(int korisniciNalogID)
        {

            PlataVM plata = new PlataVM();
            plata.KorisnickiNalogID = korisniciNalogID;
            if(_context.Plata.FirstOrDefault(x=>x.KorisnickiNalogId==korisniciNalogID)!=null)
            {
                Plata p = _context.Plata.FirstOrDefault(x => x.KorisnickiNalogId == korisniciNalogID);
                plata.Osnova = p.Osnovica;
                plata.Bonus = p.Bonus;
                plata.Ukupno = p.Osnovica + p.Bonus;
            }
            else
            {
                plata.Osnova = 0;
                plata.Bonus = 0;
                plata.Ukupno = 0;
            }
           

            return PartialView("DodajPlatu",plata);
        }
        public IActionResult SnimiPlatu(PlataVM plata)
        {
            
            if (_context.Plata.SingleOrDefault(x => x.KorisnickiNalogId == plata.KorisnickiNalogID) == null)
            {

                Plata p = new Plata();
                p.Osnovica = plata.Osnova;
                p.Bonus = plata.Bonus;
                p.KorisnickiNalogId = plata.KorisnickiNalogID;
                p.Ukupno = plata.Osnova + plata.Bonus;

                _context.Plata.Add(p);
                _context.SaveChanges();

                return RedirectToAction("Prikazi");
            }
            else
            {
                Plata pl = _context.Plata.SingleOrDefault(x => x.KorisnickiNalogId == plata.KorisnickiNalogID);

                pl.Osnovica = plata.Osnova;
                pl.Bonus = plata.Bonus;
                pl.Ukupno = plata.Osnova + plata.Bonus;
                _context.Plata.Update(pl);
                _context.SaveChanges();

                return RedirectToAction("Prikazi");
            }
            

        }
    }
}

