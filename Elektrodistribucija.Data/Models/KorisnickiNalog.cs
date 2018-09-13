using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Elektrodistribucija.Data.Models
{
  public class KorisnickiNalog
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        [ForeignKey(nameof(Uloge))]
        public int? UlogaID { get; set; }
        public Uloge Uloga { get; set; }
    }
}
