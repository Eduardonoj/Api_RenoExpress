using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RenoExpress.Entities
{
    public class Compra
    {
        public int IdCompra{ get; set; }
        public string NoDocumento { get; set; }
        public DateTime FechaCompra { get; set; }
        public int IdProveedor { get; set; }


    }
}
