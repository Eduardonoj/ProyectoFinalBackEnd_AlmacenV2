using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenV2.Model
{
    public class Proveedor
    {
        public int CodigoProveedor { get; set; }
        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string PaginaWeb { get; set; }
        public string ContactoPrincipal { get; set; }


        public virtual ICollection<TelefonoProveedor> TelefonoProveedores { get; set; }
        public virtual ICollection<EmailProveedor> EmailProveedores { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
