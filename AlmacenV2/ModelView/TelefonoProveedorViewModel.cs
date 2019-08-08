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
    public class TelefonoProveedorViewModel : INotifyPropertyChanged
    {
        private InventarioDataContext db = new InventarioDataContext();

        private bool _IsReadOnlyNumero = true;
        private bool _IsReadOnlyDescripcion = true;
        private bool _IsReadOnlyCodigoProveedor = true;
        public ObservableCollection<TelefonoProveedor> _TelefonoProveedor;

        public bool IsReadOnlyNumero
        {
            get
            {
                return this._IsReadOnlyNumero;
            }
            set
            {
                this._IsReadOnlyNumero = value;
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

        public TelefonoProveedorViewModel()
        {
            this.Titulo = "Telefono Proveedores:";
        }
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
