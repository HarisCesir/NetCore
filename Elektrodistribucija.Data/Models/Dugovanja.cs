using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrodistribucija.Data.Models
{
    public class Dugovanja
    {
        public int Id { get; set; }
        public decimal Uplata { get; set; }
        public decimal RacuniUkupno { get; set; }
        public decimal Ukupno { get; set; }
        public Brojilo Brojilo { get; set; }
        public int BrojiloID { get; set; }
    }
}
