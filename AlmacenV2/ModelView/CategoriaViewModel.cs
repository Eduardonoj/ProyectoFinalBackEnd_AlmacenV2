using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AlmacenV2.Model;
namespace AlmacenV2.ModelView
{

   
    public class CategoriaViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<Categoria> _Categoria;
        private ACCION accion = ACCION.NINGUNO;
        private bool _IsReadOnlyDescripcion = true;
        private string _Descripcion;
        private Categoria _SeleccionarCategoria;

        public Categoria SeleccionarCategoria
        {
            get { return this._SeleccionarCategoria; }
            set
            {
                if (value != null)
                {
                    this._SeleccionarCategoria = value;
                    this.Descripcion = value.Descripcion;

                    NotificarCambio("SeleccionarCategoria");
                }
            }
        }
        private CategoriaViewModel _Instancia;

        public CategoriaViewModel()
        {
            this.Titulo = "Categorias:";
            this.Instancia = this;
        }



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
                    foreach (Categoria elemento in db.Categorias.ToList())
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
                this.IsReadOnlyDescripcion = false;
                this.accion = ACCION.NUEVO;
            }
            if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.NUEVO:
                        Categoria nuevo = new Categoria();
                        nuevo.Descripcion = this.Descripcion;
                        db.Categorias.Add(nuevo);
                        db.SaveChanges();
                        this.Categorias.Add(nuevo);
                        MessageBox.Show("Registro Almacenado");
                        break;
                    case ACCION.ACTUALIZAR:
                        try {
                            int posicion = this.Categorias.IndexOf(this.SeleccionarCategoria);
                            var updateCategoria = this.db.Categorias.Find(this.SeleccionarCategoria.CodigoCategoria);
                            updateCategoria.Descripcion = this.Descripcion;       
                            this.db.Entry(updateCategoria).State = EntityState.Modified;
                            this.db.SaveChanges();
                            this.Categorias.RemoveAt(posicion);
                            this.Categorias.Insert(posicion, updateCategoria);
                            MessageBox.Show("Registro Actualizado!!!");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        break;
                }
                
            }
            else if (parameter.Equals("Delete"))
            {
                if (this.SeleccionarCategoria != null)
                {
                    var respuesta = MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {

                            db.Categorias.Remove(this.SeleccionarCategoria);
                            db.SaveChanges();
                            this.Categorias.Remove(this.SeleccionarCategoria);

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        MessageBox.Show("Registro eliminado correctamente!!!");
                    }

                }
                else
                {
                    MessageBox.Show("Debe seleccionar un registro", "Eliminar", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
