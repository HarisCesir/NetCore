using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elektrodistribucija.Data.DAL;
using Elektrodistribucija.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Elektrodistribucija.Web.Areas.AdministratorModul.Controllers
{
    [Autorizacija(administrator: true, ReferentKlijenti: false,  Serviser: false)]
    [Area("AdministratorModul")]
    public class AdministratoriController : Controller
    {
        private MojContext _context;
        public AdministratoriController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
       
    }
}