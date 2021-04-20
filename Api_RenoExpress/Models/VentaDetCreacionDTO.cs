using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RenoExpress.Models
{
    public class VentaDetCreacionDTO
    {
        public string NoFactura { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdSucursal { get; set; }
        public int IdCliente { get; set; }

        public int Cantidad { get; set; }
        public Decimal SubTotal { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }

    }
}
