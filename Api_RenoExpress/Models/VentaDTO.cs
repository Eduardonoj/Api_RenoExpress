using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RenoExpress.Models
{
    public class VentaDTO
    {
        public int IdVenta { get; set; }
        public string Factura { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdSucursal { get; set; }
        public int IdCliente { get; set; }
    }
}
