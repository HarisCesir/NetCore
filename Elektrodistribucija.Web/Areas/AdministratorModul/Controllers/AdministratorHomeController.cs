using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elektrodistribucija.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Elektrodistribucija.Web.Areas.AdministratorModul.ViewModels;
using Elektrodistribucija.Data.DAL;

namespace Elektrodistribucija.Web.Areas.AdministratorModul.Controllers
{
   [Autorizacija(administrator:true,ReferentKlijenti:false,Serviser:false)]
    [Area("AdministratorModul")]
    public class AdministratorHomeController : Controller
    {
        private MojContext _context;




        public AdministratorHomeController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            AdminInfoVM info = new AdminInfoVM();

            info.BrojKorisnika = _context.KorisnickiNalog.Count();
            info.BrojKlijenata = _context.Klijenti.Count();
            info.BrojPrikljucaka = _context.Prikljucak.Count();
            info.BrojDirekcija = _context.Direkcija.Count();
           
            

            return View("Index",info);
        }
        
    }
}