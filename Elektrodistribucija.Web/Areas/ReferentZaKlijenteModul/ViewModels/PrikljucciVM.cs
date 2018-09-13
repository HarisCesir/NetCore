using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.ReferentZaKlijenteModul.ViewModels
{
    public class PrikljucciVM
    {
        public int KlijentID { get; set; }
        public string Adresa { get; set; }
        public DateTime Datum { get; set; }
        public string Parcela { get; set; }
        public int GradID { get; set; }

    }
}
