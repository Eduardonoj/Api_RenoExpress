﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RenoExpress.Models
{
    public class CompraCreacionDTO
    {
        public string NoDocumento { get; set; }
        public DateTime FechaCompra { get; set; }
        public int IdProveedor { get; set; }
    }
}
