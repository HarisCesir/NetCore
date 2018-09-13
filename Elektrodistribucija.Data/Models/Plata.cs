
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrodistribucija.Data.Models
{
   public class Plata
    {
        public int Id { get; set; }
       

        public decimal Osnovica { get; set; }

        public decimal Bonus{ get; set; }

        public decimal Ukupno { get; set; }

        [ForeignKey(nameof(KorisnickiNalog))]
        public int? KorisnickiNalogId { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }



    }
}
