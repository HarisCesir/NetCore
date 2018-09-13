using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elektrodistribucija.Data.DAL;
using Elektrodistribucija.Data.EntityModels;
using Elektrodistribucija.Data.Models;
using Elektrodistribucija.Web.Helper;
using Elektrodistribucija.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elektrodistribucija.Web.Controllers
{
    public class LoginController : Controller
    {
        private MojContext _context;
        public LoginController(MojContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new LoginVM()
            {
                zapamtiPassword = true,
            });

        }

        public IActionResult Login(LoginVM input)
        {
            KorisnickiNalog korisnickiNalog = _context.KorisnickiNalog.SingleOrDefault(x => x.KorisnickoIme == input.KorisnickoIme && x.Lozinka == input.Lozinka);




            if (korisnickiNalog == null)
            {
                TempData["error_poruka"] = "Pogrešni podatci za login";

               return View("Index", input);
            }

            HttpContext.SetLogiraniKorisnik(korisnickiNalog, input.zapamtiPassword);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
         

            
            
            return RedirectToAction("Index");
            
        }
    }
}
