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
    public class TelefonoProveedorViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();

        private bool _IsReadOnlyNumero = true;
        private bool _IsReadOnlyDescripcion = true;
        private bool _IsReadOnlyCodigoProveedor = true;
        private string _Numero;
        private string _Descripcion;
        private string _CodigoProveedor;

        public ObservableCollection<TelefonoProveedor> _TelefonoProveedor;

        private TelefonoProveedorViewModel _Instancia;

        public TelefonoProveedorViewModel()
        {
            this.Titulo = "Telefono Proveedores:";
            this.Instancia = this;
        }


        public TelefonoProveedorViewModel Instancia
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

        public bool IsReadOnlyNumero
        {
            get
            {
                return this._IsReadOnlyNumero;
            }
            set
            {
                this._IsReadOnlyNumero = value;
                NotificarCambio("IsReadOnlyNumero");
            }
        }
        public bool IsReadOnlyDescripcion
        {
            get
            {
                return this._IsReadOnlyDescripcion;
            }
            set
            {
                this._IsReadOnlyDescripcion = value;
                NotificarCambio("IsReadOnlyDescripcion");
            }
        }
        public bool IsReadOnlyCodigoProveedor
        {
            get
            {
                return this._IsReadOnlyCodigoProveedor;
            }
            set
            {
                this._IsReadOnlyCodigoProveedor = value;
                NotificarCambio("IsReadOnlyCodigoProveedor");
            }
        }
        public string Numero
        {
            get
            {
                return _Numero;
            }
            set
            {
                this._Numero = value;
                NotificarCambio("Numero");
            }
        }
        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                this._Descripcion = value;
                NotificarCambio("Descripcion");
            }
        }
        public string CodigoProveedor
        {
            get
            {
                return _CodigoProveedor;
            }
            set
            {
                this._CodigoProveedor = value;
                NotificarCambio("CodigoProveedor");
            }
        }



        public ObservableCollection<TelefonoProveedor> TelefonoProveedores
        {
            get
            {
                if(this._TelefonoProveedor == null)
                {
                    this._TelefonoProveedor = new ObservableCollection<TelefonoProveedor>();
                    foreach (TelefonoProveedor elemento in db.TelefonoProveedores.ToList())
                    {
                        this._TelefonoProveedor.Add(elemento);
                    }
                }
                return this._TelefonoProveedor;
            }
            set { this._TelefonoProveedor = value; }
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
                this.IsReadOnlyNumero = false;
                this.IsReadOnlyDescripcion = false;
                this.IsReadOnlyCodigoProveedor = false;
                
            }

        }
    }
}
