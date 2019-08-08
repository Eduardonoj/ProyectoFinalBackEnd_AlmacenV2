using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenV2.Model
{
    public class Cliente
    {
        public string Nit { get; set; }
        public string Dpi { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<TelefonoCliente> TelefonoClientes { get; set;}
        public virtual ICollection<EmailCliente> EmailClientes { get; set;}
    }
}
