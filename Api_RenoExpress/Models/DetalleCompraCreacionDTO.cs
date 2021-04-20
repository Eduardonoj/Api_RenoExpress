using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RenoExpress.Models
{
    public class DetalleCompraCreacionDTO
    {
        public int Cantidad { get; set; }
        public Decimal PrecioTotal { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
    }
}
