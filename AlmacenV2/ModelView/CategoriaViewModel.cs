using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AlmacenV2.Model;
namespace AlmacenV2.ModelView
{
    public class CategoriaViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private bool _IsReadOnlyDescripcion = true;
        private string _Descripcion;
        private CategoriaViewModel _Instancia;

        public CategoriaViewModel(){
            this.Titulo = "Categorias:";
            this.Instancia = this;
            }

        private ObservableCollection<Categoria> _Categoria;

        public CategoriaViewModel Instancia
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

        public bool IsReadOnlyDescripcion
        {
            get
            {
                return this._IsReadOnlyDescripcion;
            }
            set
            {
                this._IsReadOnlyDescripcion = value;
                NotificarCambio("IsReadOnlyDescripcion");
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                this._Descripcion = value;
                NotificarCambio("Descripcion");
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
       
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotificarCambio(string propiedad)
        {
            if(PropertyChanged != null)
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
            if(parameter.Equals("Add")){
                this.IsReadOnlyDescripcion = false;
            }
        }
    }
}
