using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RenoExpress.Entities
{
    public class Producto
    {
        public int IdProducto{ get; set; }
        public string NombreProducto { get; set; }
        public int TipoProducto{ get; set; }
        public int PrecioUnitario { get; set; }
    }
}
