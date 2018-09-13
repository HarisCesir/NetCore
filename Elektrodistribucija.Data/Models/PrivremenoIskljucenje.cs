
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrodistribucija.Data.Models
{
   public class PrivremenoIskljucenje
    {
        public int Id { get; set; }
        

        public DateTime Datum { get; set; }

        public string Razlog { get; set; }

        public Prikljucak Prikljucak { get; set; }

        public int PrikljucakID { get; set; }
    }
}
