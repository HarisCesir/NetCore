using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.ReferentZaKlijenteModul.ViewModels
{
    public class OpomenaVM
    {
        public int PrikljucakID { get; set; }
        public DateTime Datum { get; set; }
        public string Sadrzaj { get; set; }
    }
}
