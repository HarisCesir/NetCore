using Elektrodistribucija.Data.DAL;
using Elektrodistribucija.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Elektrodistribucija.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Elektrodistribucija.Web.Helper
{
        public static class Autentifikacija
        {
            private const string LogiraniKorisnik = "logirani_korisnik";

            public static void SetLogiraniKorisnik(this HttpContext context, KorisnickiNalog korisnik, bool snimiUCookie = false)
            {

               MojContext db = context.RequestServices.GetService<MojContext>();

                string stariToken1 = context.Request.GetCookieJson<string>(LogiraniKorisnik);
                if (stariToken1 != null)
                {
                    AutorizacijaToken obrisati = db.AutorizacijaToken.FirstOrDefault(x => x.Vrijednost == stariToken1);
                    if (obrisati != null)
                    {
                        db.AutorizacijaToken.Remove(obrisati);
                        db.SaveChanges();
                    }
                }

                string stariToken2 = context.Session.Get<string>(LogiraniKorisnik);
                if (stariToken2 != null)
                {
                    AutorizacijaToken obrisati = db.AutorizacijaToken.FirstOrDefault(x => x.Vrijednost == stariToken2);
                    if (obrisati != null)
                    {
                        db.AutorizacijaToken.Remove(obrisati);
                        db.SaveChanges();
                    }
                }

                if (korisnik != null)
                {

                    string token = Guid.NewGuid().ToString();
                    db.AutorizacijaToken.Add(new AutorizacijaToken
                    {
                        Vrijednost = token,
                        KorisnickiNalogId = korisnik.Id,
                        VrijemeEvidentiranja = DateTime.Now,
                        IpAdresa= new WebClient().DownloadString("http://icanhazip.com")
            });
                    db.SaveChanges();
                    context.Session.Set(LogiraniKorisnik, token);
                    if (snimiUCookie)
                        context.Response.SetCookieJson(LogiraniKorisnik, token);
                }
            }

            public static string GetTrenutniToken(this HttpContext context)
            {
                string token = context.Session.Get<string>(LogiraniKorisnik);
                if (token == null)
                    token = context.Request.GetCookieJson<string>(LogiraniKorisnik);

                return token;
            }

            public static KorisnickiNalog GetLogiraniKorisnik(this HttpContext context)
            {
                MojContext db = context.RequestServices.GetService<MojContext>();

                string token = GetTrenutniToken(context);
                if (token == null)
                    return null;

                return db.AutorizacijaToken
                    .Where(x => x.Vrijednost == token)
                    .Select(s => s.KorisnickiNalog)
                    .SingleOrDefault();

            }

        }
    }
