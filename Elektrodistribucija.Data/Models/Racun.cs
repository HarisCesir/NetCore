
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrodistribucija.Data.Models
{
  public  class Racun
    {
        public int Id { get; set; }
        

      

        public string Mjesec { get; set; }

        public decimal Dug { get; set; }

        public decimal Ukupno { get; set; }

       

        
        public decimal Potrosnja_Skupa { get; set; }
        public decimal Potrosnja_jeftina { get; set; }
        public CijenaKwh Cijena { get; set; }
        public int CijenaId { get; set; }
        public Brojilo Brojilo { get; set; }

        public int BrojiloID { get; set; }
    }
}
