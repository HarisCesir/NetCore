using Elektrodistribucija.Data.DAL;
using Elektrodistribucija.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Elektrodistribucija.Web.Helper
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool administrator, bool ReferentKlijenti,  bool Serviser) : base(typeof(MyAutorizeIml))
        {
            Arguments = new object[] { administrator, ReferentKlijenti,  Serviser };
        }

    }

    public class MyAutorizeIml : IAsyncActionFilter
    {
        private readonly bool _administrator;

        private readonly bool _referentklijenti;
        
        private readonly bool _serviser;

        public MyAutorizeIml(bool administrator, bool ReferentKlijenti,  bool Serviser)
        {
            _administrator = administrator;
            _referentklijenti = ReferentKlijenti;
         
            _serviser = Serviser;

        }
        public async Task OnActionExecutionAsync(ActionExecutingContext filtercontext, ActionExecutionDelegate next)
        {
            KorisnickiNalog korisnik = Autentifikacija.GetLogiraniKorisnik(filtercontext.HttpContext);
            if (korisnik == null)
            {
                if (filtercontext.Controller is Controller controller)
                {
                    controller.TempData["error_poruka"] = "Niste prijavljeni";
                }
                filtercontext.Result = new RedirectToActionResult("Index", "Login", new { area = "" });
                return;
            }

            MojContext mojContext = filtercontext.HttpContext.RequestServices.GetService<MojContext>();

            if (_administrator && mojContext.Administrator.Any(x => x.KorisnickiNalogId == korisnik.Id))
            {
                await next();
                return;
            }
            if (_referentklijenti && mojContext.ReferentKlijenti.Any(x => x.KorisnickiNalogId == korisnik.Id))
            {
                await next();
                return;
            }
           
            if (_serviser && mojContext.Serviser.Any(x => x.KorisnickiNalogId == korisnik.Id))
            {
                await next();
                return;
            }

            if (filtercontext.Controller is Controller c)
            {
                c.ViewData["error_poruka"] = "Nemate pravo pristupa";


                filtercontext.Result = new RedirectToActionResult("Index", "Home", new { area = "" });

            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
