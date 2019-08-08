using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmacenV2.Model;
namespace AlmacenV2.ModelView
{
    public class CategoriaViewModel : INotifyPropertyChanged
    {
        private InventarioDataContext db = new InventarioDataContext();
        private bool _IsReadOnlyDescripcion = true;
        private ObservableCollection<Categoria> _Categoria;

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
        public ObservableCollection<Categoria> Categorias
        {
            get
            {
                if (this._Categoria == null)
                {
                    this._Categoria = new ObservableCollection<Categoria>();
                    foreach(Categoria elemento in db.Categorias.ToList())
                    {
                        this._Categoria.Add(elemento);
                    }
                }
                return this._Categoria;
            }
            set { this._Categoria = value; }
        }
        public CategoriaViewModel()
        {
            this.Titulo = "Categorias:";
        }
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
