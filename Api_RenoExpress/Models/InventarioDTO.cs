using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RenoExpress.Models
{
    public class InventarioDTO
    {
        public int IdInventario { get; set; }
        public int IdProducto { get; set; }
        public int CantidadExistencia { get; set; }
        public int IdSucursal { get; set; }
    }
}
