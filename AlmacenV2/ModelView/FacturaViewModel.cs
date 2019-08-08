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
    public class FacturaViewModel : INotifyPropertyChanged
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<Factura> _Factura;
        private bool _IsReadOnlyNit = true;
        private bool _IsReadOnlyFecha = true;
        private bool _IsReadOnlyTotal = true;

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

        public bool IsReadOnlyFecha
        {
            get
            {
                return this._IsReadOnlyFecha;
            }
            set
            {
                this._IsReadOnlyFecha = value;
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
        public FacturaViewModel()
        {
            this.Titulo = "Facturas:";
        }
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
