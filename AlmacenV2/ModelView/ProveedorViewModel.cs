using AlmacenV2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AlmacenV2.ModelView
{
    public class ProveedorViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private bool _IsReadOnlyNit = true;
        private bool _IsReadOnlyRazonSocial = true;
        private bool _IsReadOnlyDireccion = true;
        private bool _IsReadOnlyPaginaWeb = true;
        private bool _IsReadOnlyContactoPrincipal = true;
        private string _Nit;
        private string _RazonSocial;
        private string _Direccion;
        private string _PaginaWeb;
        private string _ContactoPrincipal;

        private ObservableCollection<Proveedor> _Proveedor;

        private ProveedorViewModel _Instancia;

        public ProveedorViewModel()
        {
            this.Titulo = "Proveedores:";
            this.Instancia = this;
        }


        public ProveedorViewModel Instancia
        {
            get
            {
                return this._Instancia;
            }
            set
            {
                this._Instancia = value;
            }
        }

        public bool IsReadOnlyNit
        {
            get
            {
                return this._IsReadOnlyNit;
            }
            set
            {
                this._IsReadOnlyNit = value;
                NotificarCambio("IsReadOnlyNit");
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
                NotificarCambio("IsReadOnlyRazonSocial");
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
                NotificarCambio("IsReadOnlyDireccion");
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
                NotificarCambio("IsReadOnlyPaginaWeb");
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
                NotificarCambio("IsReadOnlyContactoPrincipal");
            }
        }
        public string Nit
        {
            get
            {
                return _Nit;
            }
            set
            {
                this._Nit = value;
                NotificarCambio("Nit");
            }
        }

        public string RazonSocial
        {
            get
            {
                return _RazonSocial;
            }
            set
            {
                this._RazonSocial = value;
                NotificarCambio("RazonSocial");
            }
        }
        public string Direccion
        {
            get
            {
                return _Direccion;
            }
            set
            {
                this._Direccion = value;
                NotificarCambio("Direccion");
            }
        }
        public string PaginaWeb
        {
            get
            {
                return _PaginaWeb;
            }
            set
            {
                this._PaginaWeb = value;
                NotificarCambio("PaginaWeb");
            }
        }
        public string ContactoPrincipal
        {
            get
            {
                return _ContactoPrincipal;
            }
            set
            {
                this._ContactoPrincipal = value;
                NotificarCambio("ContactoPrincipal");
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
        
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotificarCambio(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.Equals("Add"))
            {
                this.IsReadOnlyNit = false;
                this.IsReadOnlyRazonSocial = false;
                this.IsReadOnlyDireccion = false;
                this.IsReadOnlyPaginaWeb = false;
                this.IsReadOnlyContactoPrincipal = false;
                
            }
        }
    }
}
