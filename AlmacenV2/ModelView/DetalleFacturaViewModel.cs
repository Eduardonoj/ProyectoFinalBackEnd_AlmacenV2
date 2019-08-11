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
    public class DetalleFacturaViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<DetalleFactura> _DetalleFactura;

        private bool _IsReadOnlyNumeroFactura = true;
        private bool _IsReadOnlyCodigoProducto = true;
        private bool _IsReadOnlyCantidad = true;
        private bool _IsReadOnlyPrecio = true;
        private bool _IsReadOnlyDescuento = true;
        private string _NumeroFactura;
        private string _CodigoProducto;
        private string _Cantidad;
        private string _Precio;
        private string _Descuento;

        private DetalleFacturaViewModel _Instancia;

        public DetalleFacturaViewModel()
        {
            this.Titulo = "Detalle Facturas:";
            this.Instancia = this;
        }



       
        public DetalleFacturaViewModel Instancia
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

        public bool IsReadOnlyNumeroFactura
        {
            get
            {
                return this._IsReadOnlyNumeroFactura;
            }
            set
            {
                this._IsReadOnlyNumeroFactura = value;
                NotificarCambio("IsReadOnlyNumeroFactura");
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

        public bool IsReadOnlyCantidad
        {
            get
            {
                return this._IsReadOnlyCantidad;
            }
            set
            {
                this._IsReadOnlyCantidad = value;
                NotificarCambio("IsReadOnlyCantidad");
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

        public bool IsReadOnlyDescuento
        {
            get
            {
                return this._IsReadOnlyDescuento;
            }
            set
            {
                this._IsReadOnlyDescuento = value;
                NotificarCambio("IsReadOnlyDescuento");
            }
        }
        public string NumeroFactura
        {
            get
            {
                return _NumeroFactura;
            }
            set
            {
                this._NumeroFactura = value;
                NotificarCambio("NumeroFactura");
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
        public string Cantidad
        {
            get
            {
                return _Cantidad;
            }
            set
            {
                this._Cantidad = value;
                NotificarCambio("Cantidad");
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
        public string Descuento
        {
            get
            {
                return _Descuento;
            }
            set
            {
                this._Descuento = value;
                NotificarCambio("Descuento");
            }
        }
        public ObservableCollection<DetalleFactura> DetalleFacturas
        {
            get
            {
                if (this._DetalleFactura == null)
                {
                    this._DetalleFactura = new ObservableCollection<DetalleFactura>();
                    foreach (DetalleFactura elemento in db.DetalleFacturas.ToList())
                    {
                        this._DetalleFactura.Add(elemento);
                    }
                }
                return this._DetalleFactura;
            }
            set { this._DetalleFactura = value; }
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
                this.IsReadOnlyNumeroFactura = false;
                this.IsReadOnlyCodigoProducto = false;
                this.IsReadOnlyCantidad = false;
                this.IsReadOnlyPrecio = false;
                this._IsReadOnlyDescuento = false;
            }
        }
    }

}
