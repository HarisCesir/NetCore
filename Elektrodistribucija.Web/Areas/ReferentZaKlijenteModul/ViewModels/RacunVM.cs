using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.ReferentZaKlijenteModul.ViewModels
{
    public class RacunVM
    {
        public int BrojiloID  { get; set; }
        public decimal CijenaJeftina { get; set; }
        public decimal CijenaSkupa { get; set; }
        public decimal PotrosnjaJeftina { get; set; }
        public decimal PotreosnjaSkupa { get; set; }
        public string Mjesec { get; set; }
        public decimal Ukupno { get; set; }
        public decimal Dug { get; set; }
    }
}
