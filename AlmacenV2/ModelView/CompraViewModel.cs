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
    class CompraViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private bool _IsReadOnlyNumeroDocumento = true;
        private bool _IsReadOnlyCodigoProveedor = true;
        private bool _IsReadOnlyFecha = true;
        private bool _IsReadOnlyTotal = true;
        private string _NumeroDocumento;
        private string _CodigoProveedor;
        private string _Fecha;
        private string _Total;
        private CompraViewModel _Instancia;

        public CompraViewModel()
        {
            this.Titulo = "Compras:";
            this.Instancia = this;
        }



        private ObservableCollection<Compra> _Compra;

        public CompraViewModel Instancia
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


        public bool IsReadOnlyNumeroDocumento
        {
            get
            {
                return this._IsReadOnlyNumeroDocumento;
            }
            set
            {
                this._IsReadOnlyNumeroDocumento = value;
                NotificarCambio("IsReadOnlyNumeroDocumento");
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

        public bool IsReadOnlyTotal
        {
            get
            {
                return this._IsReadOnlyTotal;
            }
            set
            {
                this._IsReadOnlyTotal = value;
                NotificarCambio("IsReadOnlyTotal");
            }
        }

        public string NumeroDocumento
        {
            get
            {
                return _NumeroDocumento;
            }
            set
            {
                this._NumeroDocumento = value;
                NotificarCambio("NumeroDocumento");
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
        public string Total
        {
            get
            {
                return _Total;
            }
            set
            {
                this._Total = value;
                NotificarCambio("Total");
            }
        }



        public ObservableCollection<Compra> Compras
        {
            get
            {
                if (this._Compra == null)
                {
                    this._Compra = new ObservableCollection<Compra>();
                    foreach (Compra elemento in db.Compras.ToList())
                    {
                        this._Compra.Add(elemento);
                    }
                }
                return this._Compra;
            }
            set { this._Compra = value; }
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
                this.IsReadOnlyNumeroDocumento = false;
                this.IsReadOnlyCodigoProveedor = false;
                this.IsReadOnlyFecha = false;
                this.IsReadOnlyTotal = false;
            }
        }
    }

}
