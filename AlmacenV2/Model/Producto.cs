using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenV2.Model
{
    public class Producto
    {
        public int CodigoProducto { get; set; }
        public int CodigoCategoria { get; set; }
        public int CodigoEmpaque { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get;set; }
        public decimal PrecioPorDocena { get;set;}
        public decimal PrecioPorMayor { get; set; }
        public int Existencia { get; set; }
        public string Imagen { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual TipoEmpaque TipoEmpaque { get; set;}

        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
