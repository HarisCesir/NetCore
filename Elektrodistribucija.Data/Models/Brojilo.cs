using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrodistribucija.Data.Models
{
   public class Brojilo
    {
        public int Id { get; set; }
     

        public decimal TrenutnoStanjeSkupa { get; set; }

        public decimal StaroStanjeSkupa { get; set; }
        public decimal TrenutnoStanjeJeftina { get; set; }
        public decimal StaroStanjeJeftina { get; set; }

        public DateTime Datum { get; set; }

        public Prikljucak Prikljucak { get; set; }

        public int PrikljucakID { get; set; }
    }
}
