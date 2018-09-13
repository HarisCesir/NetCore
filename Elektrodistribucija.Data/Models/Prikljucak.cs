
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrodistribucija.Data.Models
{
  public  class Prikljucak
    {
      public int Id { get; set; }
       

        public DateTime DatumPrikljucenja { get; set; }

        public string Adresa { get; set; }
        public string Parcela { get; set; }

        public Klijenti Klijent { get; set; }

        public int? KlijentID { get; set; }

        public Grad Grad { get; set; }

        public int GradID { get; set; }

    }
}
