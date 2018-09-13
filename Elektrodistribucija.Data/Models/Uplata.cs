
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrodistribucija.Data.Models
{
   public class Uplata
    {
        public int Id { get; set; }
        

        public DateTime Datum { get; set; }

        public decimal Iznos { get; set; }

        public Brojilo brojilo { get; set; }

        public int BrojiloID { get; set; }

    }
}
