using Elektrodistribucija.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.Areas.ServiserModul.Models
{
    public class PrijavaKvaraVM
    {
        
        public int Id { get; set; }

        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Polje opis je obavezno")]
        public string Opis { get; set; }

        
        public Prikljucak Prikljucak { get; set; }

        [RegularExpression(@"^\d$", ErrorMessage = "Polje prikljucak je obavezno")]
        public int? PrikljucakID { get; set; }
        [Required(ErrorMessage = "Polje tip kvara je obavezno")]
        public TipKvara TipKvara { get; set; }

        [RegularExpression(@"^\d$", ErrorMessage = "Polje tip kvara je obavezno")]
        public int TipKvaraID { get; set; }

        public bool Status { get; set; }
    }
}
