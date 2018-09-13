using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrodistribucija.Data.Models
{
   public class Klijenti
    {
        public int Id { get; set; }


       

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }

        public string Telefon { get; set; }

        public string JMBG { get; set; }

        public Grad Grad { get; set; }
        public int GradID { get; set; }
    }
}
