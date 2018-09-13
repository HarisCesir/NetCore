using Elektrodistribucija.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elektrodistribucija.Data.DAL
{
    public class MojDBInitializer
    {
        public static void Izvrsi(MojContext _context)
        {
            if(_context.Cijena.Any())
            {

            }
            else
            {
                CijenaKwh cijena = new CijenaKwh();
                cijena.CijenaKwHJeftina = Convert.ToDecimal(0.12);
                cijena.CijenaKwhSkupa = Convert.ToDecimal(0.40);
                _context.Cijena.Add(cijena);
                _context.SaveChanges();
            }
            if(_context.Uloge.Any())
            {
              
            }
            else
            {
                List<Uloge> uloge = new List<Uloge>();
                Uloge admin = new Uloge
                {
                    NazivUloge = "Administrator"
                };
                uloge.Add(admin);

                Uloge ReferentKlijenti = new Uloge
                {
                    NazivUloge = "Referent za klijente"
                };

                uloge.Add(ReferentKlijenti);

                Uloge Serviser = new Uloge
                {
                    NazivUloge = "Serviser"
                };
                uloge.Add(Serviser);

                foreach(Uloge u in uloge)
                {
                    _context.Uloge.Add(u);
                }
                _context.SaveChanges();

            }

            if(_context.Administrator.Any())
            {
                
            }
            else
            {
                Administrator a = new Administrator
                {
                    Ime = "Haris",
                    Prezime = "Cesir",
                    Telefon = "061536411",
                    KorisnickiNalog = new KorisnickiNalog
                    {
                        KorisnickoIme = "admin",
                        Lozinka = "admin",
                        UlogaID=1
                    }
                    
                };

                _context.Administrator.Add(a);
                _context.SaveChanges();

            }

            if(_context.Grad.Any())
            {

            }
            else
            {
                Grad grad1 = new Grad
                {
                    Naziv = "Konjic",
                    PostanskiBroj = "88400"
                };
                _context.Grad.Add(grad1);

                Grad grad2 = new Grad
                {
                    Naziv = "Mostar",
                    PostanskiBroj = "88000"
                };
                _context.Grad.Add(grad2);

                _context.SaveChanges();

            }
        }
    }
}
