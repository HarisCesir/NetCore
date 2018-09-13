using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrodistribucija.Data.Models
{
  public class CijenaKwh
    {
        public int Id { get; set; }
        public decimal CijenaKwHJeftina { get; set; }
        public decimal CijenaKwhSkupa { get; set; }
    }
}
