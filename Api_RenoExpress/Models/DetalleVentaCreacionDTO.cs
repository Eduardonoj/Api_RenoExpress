using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RenoExpress.Models
{
    public class DetalleVentaCreacionDTO
    {
        public int Cantidad { get; set; }
        public Decimal SubTotal { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }

    }
}
