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
    public class DetalleFacturaViewModel : INotifyPropertyChanged
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<DetalleFactura> _DetalleFactura;

        private bool _IsReadOnlyNumeroFactura = true;
        private bool _IsReadOnlyCodigoProducto = true;
        private bool _IsReadOnlyCantidad = true;
        private bool _IsReadOnlyPrecio = true;
        private bool _IsReadOnlyDescuento = true;

        public bool IsReadOnlyNumeroFactura
        {
            get
            {
                return this._IsReadOnlyNumeroFactura;
            }
            set
            {
                this._IsReadOnlyNumeroFactura = value;
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

        public bool IsReadOnlyDescuento
        {
            get
            {
                return this._IsReadOnlyDescuento;
            }
            set
            {
                this._IsReadOnlyDescuento = value;
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
        public DetalleFacturaViewModel()
        {
            this.Titulo = "Detalle Facturas:";
        }
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
