﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elektrodistribucija.Web.ViewModels
{
    public class SesijaIndexVM
    {
        public List<Row> Rows { get; set; }
        public string TrenutniToken { get; set; }

        public class Row
        {
            public DateTime VrijemeLogiranja { get; set; }
            public string token { get; set; }
            public string IPAdresa { get; set; }
        }
    }
}
