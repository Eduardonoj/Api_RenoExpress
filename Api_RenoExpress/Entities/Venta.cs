using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RenoExpress.Entities
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public string NoFactura { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdSucursal { get; set; }
        public int IdCliente { get; set; }

    }
}
