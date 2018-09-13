
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrodistribucija.Data.Models
{
    public class PrijavaKvara 
    {
        public int Id { get; set; }
        
        

        public DateTime Datum { get; set; }

        public string Opis { get; set; }

       

        public Prikljucak Prikljucak { get; set; }

        public int? PrikljucakID { get; set; }

        public TipKvara TipKvara { get; set; }

        public int TipKvaraID { get; set; }

        public bool Status { get; set; }


    }
}
