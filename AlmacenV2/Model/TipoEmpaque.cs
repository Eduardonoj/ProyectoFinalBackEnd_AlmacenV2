using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenV2.Model
{
    public class TipoEmpaque
    {
        public int CodigoEmpaque { get; set; }
        public int Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
