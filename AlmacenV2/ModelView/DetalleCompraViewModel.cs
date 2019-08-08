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
   public class DetalleCompraViewModel : INotifyPropertyChanged
    {
        private InventarioDataContext db = new InventarioDataContext();
        private bool _IsReadOnlyIdCompra = true;
        private bool _IsReadOnlyCodigoProducto = true;
        private bool _IsReadOnlyCantidad = true;
        private bool _IsReadOnlyPrecio = true;
        private ObservableCollection<DetalleCompra> _DetalleCompra;

        public bool IsReadOnlyIdCompra
        {
            get
            {
                return this._IsReadOnlyIdCompra;
            }
            set
            {
                this._IsReadOnlyIdCompra = value;
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
            }
        }

        public ObservableCollection<DetalleCompra> DetalleCompras
        {
            get
            {
                if (this._DetalleCompra == null)
                {
                    this._DetalleCompra = new ObservableCollection<DetalleCompra>();
                    foreach (DetalleCompra elemento in db.DetalleCompras.ToList())
                    {
                        this._DetalleCompra.Add(elemento);
                    }
                }
                return this._DetalleCompra;
            }
            set { this._DetalleCompra = value; }
        }
        public DetalleCompraViewModel()
        {
            this.Titulo = "Detalle Compras:";
        }
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}

