using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrodistribucija.Data.Models
{
   public class Opomena
    {
        public int Id { get; set; }
      

        public string Sadrzaj { get; set; }

        public DateTime Datum { get; set; }

        public Prikljucak Prikljucak { get; set; }

        public int PrikljucakID { get; set; }
    }
}
