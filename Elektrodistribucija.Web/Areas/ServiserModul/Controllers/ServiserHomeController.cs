using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elektrodistribucija.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Elektrodistribucija.Web.Areas.ServiserModul.Controllers
{
    [Autorizacija(administrator: true, ReferentKlijenti: false,  Serviser: true)]
    [Area("ServiserModul")]
    public class ServiserHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}