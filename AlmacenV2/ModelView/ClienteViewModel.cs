using AlmacenV2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenV2.ModelView
{
    public class ClienteViewModel : INotifyPropertyChanged
    {
        private InventarioDataContext db = new InventarioDataContext();
        private bool _IsReadOnlyDpi = true;
        private bool _IsReadOnlyNombre = true;
        private bool _IsReadOnlyDireccion = true;

        private ObservableCollection<Cliente> _Cliente;

        public bool IsReadOnlyDpi
        {
            get
            {
                return this._IsReadOnlyDpi;
            }
            set
            {
                this._IsReadOnlyDpi = value;
            }
        }

        public bool IsReadOnlyNombre
        {
            get
            {
                return this._IsReadOnlyNombre;
            }
            set
            {
                this._IsReadOnlyNombre = value;
            }
        }

        public bool IsReadOnlyDireccion
        {
            get
            {
                return this._IsReadOnlyDireccion;
            }
            set
            {
                this._IsReadOnlyDireccion = value;
            }
        }
        public ObservableCollection<Cliente> Clientes
        {
            get
            {
                if(this._Cliente == null)
                {
                    this._Cliente = new ObservableCollection<Cliente>();
                    foreach (Cliente elemento in db.Clientes.ToList())
                    {
                        this._Cliente.Add(elemento);
                    }
                }
                return this._Cliente;
            }
            set { this._Cliente = value;}
        }
        public ClienteViewModel()
        {
            this.Titulo = "Clientes:";
        }
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
