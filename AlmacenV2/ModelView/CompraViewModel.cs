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
    class CompraViewModel : INotifyPropertyChanged
    {
        private InventarioDataContext db = new InventarioDataContext();
        private bool _IsReadOnlyNumeroDocumento = true;
        private bool _IsReadOnlyCodigoProveedor = true;
        private bool _IsReadOnlyFecha = true;
        private bool _IsReadOnlyTotal = true;
        private ObservableCollection<Compra> _Compra;

        public bool IsReadOnlyNumeroDocumento
        {
            get
            {
                return this._IsReadOnlyNumeroDocumento;
            }
            set
            {
                this._IsReadOnlyNumeroDocumento = value;
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
        public CompraViewModel()
        {
            this.Titulo = "Compras:";
        }
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
