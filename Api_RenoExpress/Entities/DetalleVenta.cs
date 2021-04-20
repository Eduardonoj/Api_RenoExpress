using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RenoExpress.Entities
{
    public class DetalleVenta
    {

        public int IdDetalleVenta { get; set; }
        public int Cantidad { get; set; }
        public Decimal SubTotal { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }

    }
}
