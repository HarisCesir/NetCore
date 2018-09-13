using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.AdministratorModul.ViewModels
{
    public class AdminInfoVM
    {
        public int BrojKorisnika { get; set; }
        public int BrojKlijenata { get; set; }
        public int BrojPrikljucaka { get; set; }
        public int BrojDirekcija { get; set; }
        
    }
}
