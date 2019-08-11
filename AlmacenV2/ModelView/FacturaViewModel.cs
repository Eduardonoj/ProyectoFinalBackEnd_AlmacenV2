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
    public class FacturaViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<Factura> _Factura;
        private bool _IsReadOnlyNit = true;
        private bool _IsReadOnlyFecha = true;
        private bool _IsReadOnlyTotal = true;
        private string _Nit;
        private string _Fecha;
        private string _Total;

        private FacturaViewModel _Instancia;

        public FacturaViewModel()
        {
            this.Titulo = "Facturas:";
            this.Instancia = this;
        }


        public FacturaViewModel Instancia
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
        public string Fecha
        {
            get
            {
                return _Fecha;
            }
            set
            {
                this._Nit = value;
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
        public ObservableCollection<Factura> Facturas
        {
            get
            {
                if (this._Factura == null)
                {
                    this._Factura = new ObservableCollection<Factura>();
                    foreach (Factura elemento in db.Facturas.ToList())
                    {
                        this._Factura.Add(elemento);
                    }
                }
                return this._Factura;
            }
            set { this._Factura = value; }
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
                this.IsReadOnlyFecha = false;
                this.IsReadOnlyTotal = false;
            }
        }
    }

}
