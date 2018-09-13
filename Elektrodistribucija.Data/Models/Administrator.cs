using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Elektrodistribucija.Data.Models
{
   public class Administrator
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string JMBG { get; set; }
        public string Adresa { get; set; }
        [ForeignKey(nameof(KorisnickiNalog))]
        public int? KorisnickiNalogId { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
    }
}
