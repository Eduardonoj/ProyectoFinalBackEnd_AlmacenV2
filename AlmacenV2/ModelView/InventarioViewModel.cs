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
    public class InventarioViewModel : INotifyPropertyChanged
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<Inventario> _Inventario;
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
        public InventarioViewModel()
        {
            this.Titulo = "Inventarios :";
        }
        public string Titulo { get; set;}
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
