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
    public class ProductoViewModel : INotifyPropertyChanged
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<Producto> _Producto;
        
        public ObservableCollection<Producto> Productos
        {
            get
            {
                if(this._Producto == null)
                {
                    this._Producto = new ObservableCollection<Producto>();
                    foreach(Producto elemento in db.Productos.ToList())
                    {
                        this._Producto.Add(elemento);
                    }
                }
                return this._Producto;
            }
            set { this._Producto = value; }
        }

        public ProductoViewModel()
        {
            this.Titulo = "Productos:";
        }
        public string Titulo { get; set;}
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
