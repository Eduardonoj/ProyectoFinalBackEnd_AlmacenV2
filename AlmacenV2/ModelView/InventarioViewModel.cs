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
    public class InventarioViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private bool _IsReadOnlyCodigoProducto = true;
        private bool _IsReadOnlyFecha = true;
        private bool _IsReadOnlyTipoRegistro = true;
        private bool _IsReadOnlyPrecio = true;
        private bool _IsReadOnlyEntradas = true;
        private bool _IsReadOnlySalidas = true;
        private string _CodigoProducto;
        private string _Fecha;
        private string _TipoRegistro;
        private string _Precio;
        private string _Entradas;
        private string _Salidas;


        private ObservableCollection<Inventario> _Inventario;

        private InventarioViewModel _Instancia;

        public InventarioViewModel()
        {
            this.Titulo = "Inventarios:";
            this.Instancia = this;
        }



        private ObservableCollection<Compra> _Compra;

        public InventarioViewModel Instancia
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

        public bool IsReadOnlyCodigoProducto
        {
            get
            {
                return this._IsReadOnlyCodigoProducto;
            }
            set
            {
                this._IsReadOnlyCodigoProducto = value;
                NotificarCambio("IsReadOnlyCodigoProducto");
            }
        }

        public bool IsReadOnlyFecha
        {
            get
            {
                return this._IsReadOnlyFecha;
            }
            set
            {
                this._IsReadOnlyFecha = value;
                NotificarCambio("IsReadOnlyFecha");
            }
        }

        public bool IsReadOnlyTipoRegistro
        {
            get
            {
                return this._IsReadOnlyTipoRegistro;
            }
            set
            {
                this._IsReadOnlyTipoRegistro = value;
                NotificarCambio("IsReadOnlyTipoRegistro");
            }
        }

        public bool IsReadOnlyPrecio
        {
            get
            {
                return this._IsReadOnlyPrecio;
            }
            set
            {
                this._IsReadOnlyPrecio = value;
                NotificarCambio("IsReadOnlyPrecio");
            }
        }

        public bool IsReadOnlyEntradas
        {
            get
            {
                return this._IsReadOnlyEntradas;
            }
            set
            {
                this._IsReadOnlyEntradas = value;
                NotificarCambio("IsReadOnlyEntradas");
            }
        }

        public bool IsReadOnlySalidas
        {
            get
            {
                return this._IsReadOnlySalidas;
            }
            set
            {
                this._IsReadOnlySalidas = value;
                NotificarCambio("IsReadOnlySalidas");
            }
        }
        public string CodigoProducto
        {
            get
            {
                return _CodigoProducto;
            }
            set
            {
                this._CodigoProducto = value;
                NotificarCambio("CodigoProducto");
            }
        }
        public string Fecha
        {
            get
            {
                return _Fecha;
            }
            set
            {
                this._Fecha = value;
                NotificarCambio("Fecha");
            }
        }

        public string TipoRegistro
        {
            get
            {
                return _TipoRegistro;
            }
            set
            {
                this._TipoRegistro = value;
                NotificarCambio("TipoRegistro");
            }
        }

        public string Precio
        {
            get
            {
                return _Precio;
            }
            set
            {
                this._Precio = value;
                NotificarCambio("Precio");
            }
        }
        public string Entradas
        {
            get
            {
                return _Entradas;
            }
            set
            {
                this._Entradas = value;
                NotificarCambio("Entradas");
            }
        }
        public string Salidas
        {
            get
            {
                return _Salidas;
            }
            set
            {
                this._Salidas = value;
                NotificarCambio("Salidas");
            }
        }

        public ObservableCollection<Inventario> Inventarios
        {
            get
            {
                if (this._Inventario == null) { 
                    this._Inventario = new ObservableCollection<Inventario>();
                foreach(Inventario elemento in db.Inventarios.ToList())
                {
                    this._Inventario.Add(elemento);
                }
                }
                return this._Inventario;
            }
            set { this._Inventario = value; }
        }
       
        public string Titulo { get; set;}
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
                this.IsReadOnlyCodigoProducto = false;
                this.IsReadOnlyFecha = false;
                this.IsReadOnlyTipoRegistro = false;
                this.IsReadOnlyPrecio = false;
                this.IsReadOnlyEntradas = false;
                this.IsReadOnlySalidas = false;
            }
        }
    }
}
