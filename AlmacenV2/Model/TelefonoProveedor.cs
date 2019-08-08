using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenV2.Model
{
    public class TelefonoProveedor
    {
        public int CodigoTelefono { get; set;}
        public string Numero { get; set;}
        public string Descripcion { get; set; }
        public int CodigoProveedor { get; set; }


        public virtual Proveedor Proveedor { get; set; }
     
    }
}
