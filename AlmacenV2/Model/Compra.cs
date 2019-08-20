using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenV2.Model
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public int NumeroDocumento { get; set; }
        public int CodigoProveedor { get; set;}
        public DateTime Fecha { get; set; }
        public Decimal Total { get; set;}

        public virtual Proveedor Proveedor { get; set; }

        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
    }
}
