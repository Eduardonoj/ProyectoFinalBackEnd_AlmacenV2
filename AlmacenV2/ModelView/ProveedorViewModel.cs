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
    public class ProveedorViewModel : INotifyPropertyChanged
    {
        private InventarioDataContext db = new InventarioDataContext();
        private bool _IsReadOnlyNit = true;
        private bool _IsReadOnlyRazonSocial = true;
        private bool _IsReadOnlyDireccion = true;
        private bool _IsReadOnlyPaginaWeb = true;
        private bool _IsReadOnlyContactoPrincipal = true;

        private ObservableCollection<Proveedor> _Proveedor;

        public bool IsReadOnlyNit
        {
            get
            {
                return this._IsReadOnlyNit;
            }
            set
            {
                this._IsReadOnlyNit = value;
            }
        }

        public bool IsReadOnlyRazonSocial
        {
            get
            {
                return this._IsReadOnlyRazonSocial;
            }
            set
            {
                this._IsReadOnlyRazonSocial = value;
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

        public bool IsReadOnlyPaginaWeb
        {
            get
            {
                return this._IsReadOnlyPaginaWeb;
            }
            set
            {
                this._IsReadOnlyPaginaWeb = value;
            }
        }

        public bool IsReadOnlyContactoPrincipal
        {
            get
            {
                return this._IsReadOnlyContactoPrincipal;
            }
            set
            {
                this._IsReadOnlyContactoPrincipal = value;
            }
        }
        public ObservableCollection<Proveedor> Proveedores
        {
            get
            {
                if (this._Proveedor == null)
                {
                    this._Proveedor = new ObservableCollection<Proveedor>();
                    foreach (Proveedor elemento in db.Proveedores.ToList())
                    {
                        this._Proveedor.Add(elemento);
                    }
                }
                return this._Proveedor;
            }
            set { this._Proveedor = value; }
        }
        public ProveedorViewModel()
        {
            this.Titulo = "Proveedores:";
        }
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
