using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrodistribucija.Data.Models
{
   public class Intervencija
    {
        public int Id { get; set; }
        

        public DateTime Datum { get; set; }

        public string Lokacija { get; set; }
        public string Trajanje { get; set; }

        public string Alati { get; set; }

        public string Troskovi { get; set; }

        public Oprema Oprema { get; set; }

        public int OpremaID { get; set; }

        public PrijavaKvara PrijavaKvara { get; set; }

        public int PrijavaKvaraID { get; set; }
        
        public Serviser Serviser { get; set; }

        public int ServiserID { get; set; }
    }
}
