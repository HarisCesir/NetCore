using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrodistribucija.Data.Models
{
  public class Odjel 
    {
        public int Id { get; set; }


        

        public string Adresa { get; set; }
        public string Svrha { get; set; }

        public Direkcija Direkcija { get; set; }

        public int DirekcijaID { get; set; }
    }
}
