using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RenoExpress.Models
{
    public class CompraDetCreacionDTO
    {
        public string NoDocumento { get; set; }
        public DateTime FechaCompra { get; set; }
        public int IdProveedor { get; set; }
        public int Cantidad { get; set; }
        public Decimal PrecioTotal { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public int IdSucursal { get; set; }
    }
}
