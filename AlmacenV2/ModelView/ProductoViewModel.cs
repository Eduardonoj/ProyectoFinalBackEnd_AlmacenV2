using AlmacenV2.Model;
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

namespace AlmacenV2.ModelView
{
    public class ProductoViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<Producto> _Producto;
        private ACCION accion = ACCION.NINGUNO;
        private bool _IsReadOnlyCodigoCategoria = true;
        private bool _IsReadOnlyCodigoEmpaque = true;
        private bool _IsReadOnlyDescripcion = true;
        private bool _IsReadOnlyPrecioUnitario = true;
        private bool _IsReadOnlyPrecioPorDocena = true;
        private bool _IsReadOnlyPrecioPorMayor = true;
        private bool _IsReadOnlyExistencia = true;
        private bool _IsReadOnlyImagen = true;
        private string _CodigoCategoria;
        private string _CodigoEmpaque;
        private string _Descripcion;
        private string _PrecioUnitario;
        private string _PrecioPorDocena;
        private string _PrecioPorMayor;
        private string _Existencia;
        private string _Imagen;
        private Producto _SeleccionarProducto;

        public Producto SeleccionarProducto
        {
            get { return this._SeleccionarProducto; }
            set
            {
                if (value != null)
                {
                    this._SeleccionarProducto = value;
                    this.CodigoCategoria = value.CodigoCategoria.ToString();
                    this.CodigoEmpaque = value.CodigoEmpaque.ToString();
                    this.Descripcion = value.Descripcion;
                    this.PrecioUnitario = value.PrecioUnitario.ToString();
                    this.PrecioPorDocena = value.PrecioPorDocena.ToString();
                    this.PrecioPorMayor = value.PrecioPorMayor.ToString();
                    this.Existencia = value.Existencia.ToString();
                    this.Imagen = value.Imagen;

                    NotificarCambio("SeleccionarProveedor");
                }
            }
        }





        public bool IsReadOnlyCodigoCategoria
        {
            get
            {
                return this._IsReadOnlyCodigoCategoria;
            }
            set
            {
                this._IsReadOnlyCodigoCategoria = value;
                NotificarCambio("IsReadOnlyCodigoCategoria");
            }
        }

        public bool IsReadOnlyCodigoEmpaque
        {
            get
            {
                return this._IsReadOnlyCodigoEmpaque;
            }
            set
            {
                this._IsReadOnlyCodigoEmpaque = value;
                NotificarCambio("IsReadOnlyCodigoEmpaque");
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

        public bool IsReadOnlyPrecioUnitario
        {
            get
            {
                return this._IsReadOnlyPrecioUnitario;
            }
            set
            {
                this._IsReadOnlyPrecioUnitario = value;
                NotificarCambio("IsReadOnlyPrecioUnitario");
            }
        }

        public bool IsReadOnlyPrecioPorDocena
        {
            get
            {
                return this._IsReadOnlyPrecioPorDocena;
            }
            set
            {
                this._IsReadOnlyPrecioPorDocena = value;
                NotificarCambio("IsReadOnlyPrecioPorDocena");
            }
        }

        public bool IsReadOnlyPrecioPorMayor
        {
            get
            {
                return this._IsReadOnlyPrecioPorMayor;
            }
            set
            {
                this._IsReadOnlyPrecioPorMayor = value;
                NotificarCambio("IsReadOnlyPrecioPorMayor");
            }
        }

        public bool IsReadOnlyExistencia
        {
            get
            {
                return this._IsReadOnlyExistencia;
            }
            set
            {
                this._IsReadOnlyExistencia = value;
                NotificarCambio("IsReadOnlyExistencia");
            }
        }

        public bool IsReadOnlyImagen
        {
            get
            {
                return this._IsReadOnlyImagen;
            }
            set
            {
                this._IsReadOnlyImagen = value;
                NotificarCambio("IsReadOnlyImagen");
            }
        }

        public string CodigoCategoria
        {
            get
            {
                return _CodigoCategoria;
            }
            set
            {
                this._CodigoCategoria = value;
                NotificarCambio("CodigoCategoria");
            }
        }

        public string CodigoEmpaque
        {
            get
            {
                return _CodigoEmpaque;
            }
            set
            {
                this._CodigoEmpaque = value;
                NotificarCambio("_CodigoEmpaque");
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
        public string PrecioUnitario
        {
            get
            {
                return _PrecioUnitario;
            }
            set
            {
                this._PrecioUnitario = value;
                NotificarCambio("PrecioUnitario");
            }
        }
        public string PrecioPorDocena
        {
            get
            {
                return _PrecioPorDocena;
            }
            set
            {
                this._PrecioPorDocena = value;
                NotificarCambio("PrecioPorDocena");
            }
        }
        public string PrecioPorMayor
        {
            get
            {
                return _PrecioPorMayor;
            }
            set
            {
                this._PrecioPorMayor = value;
                NotificarCambio("PrecioPorMayor");
            }
        }
        public string Existencia
        {
            get
            {
                return _Existencia;
            }
            set
            {
                this._Existencia = value;
                NotificarCambio("Existencia");
            }
        }

        public string Imagen
        {
            get
            {
                return _Imagen;
            }
            set
            {
                this._Imagen = value;
                NotificarCambio("Imagen");
            }
        }
        public ObservableCollection<Producto> Productos
        {
            get
            {
                if (this._Producto == null)
                {
                    this._Producto = new ObservableCollection<Producto>();
                    foreach (Producto elemento in db.Productos.ToList())
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
                this.IsReadOnlyCodigoCategoria = false;
                this.IsReadOnlyCodigoEmpaque = false;
                this.IsReadOnlyDescripcion = false;
                this.IsReadOnlyPrecioUnitario = false;
                this.IsReadOnlyPrecioPorDocena = false;
                this.IsReadOnlyPrecioPorMayor = false;
                this.IsReadOnlyExistencia = false;
                this.IsReadOnlyImagen = false;
                this.accion = ACCION.NUEVO;
            }
            if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.NUEVO:
                        Producto nuevo = new Producto();
                        nuevo.CodigoCategoria = Convert.ToInt16(this.CodigoCategoria);
                        nuevo.CodigoEmpaque = Convert.ToInt16(this.CodigoEmpaque);
                        nuevo.Descripcion = this.Descripcion;
                        nuevo.PrecioUnitario = Convert.ToDecimal(this.PrecioUnitario);
                        nuevo.PrecioPorDocena = Convert.ToDecimal(this.PrecioPorDocena);
                        nuevo.PrecioPorMayor = Convert.ToDecimal(this.PrecioUnitario);
                        nuevo.Existencia = Convert.ToInt32(this.Existencia);
                        nuevo.Imagen = this.Imagen;
                        db.Productos.Add(nuevo);
                        db.SaveChanges();
                        this.Productos.Add(nuevo);
                        MessageBox.Show("Registro Almacenado");
                        break;
                    case ACCION.ACTUALIZAR:
                        try
                        {
                            int posicion = this.Productos.IndexOf(this.SeleccionarProducto);
                            var updateProducto = this.db.Productos.Find(this.SeleccionarProducto.CodigoProducto);
                            updateProducto.CodigoCategoria = Convert.ToInt16(this.CodigoCategoria);
                            updateProducto.CodigoEmpaque = Convert.ToInt16(this.CodigoEmpaque);
                            updateProducto.Descripcion = this.Descripcion;
                            updateProducto.PrecioUnitario = Convert.ToDecimal(this.PrecioUnitario);
                            updateProducto.PrecioPorDocena = Convert.ToDecimal(this.PrecioPorDocena);
                            updateProducto.PrecioPorMayor = Convert.ToDecimal(this.PrecioUnitario);
                            updateProducto.Existencia = Convert.ToInt32(this.Existencia);
                            updateProducto.Imagen = this.Imagen;
                            this.db.Entry(updateProducto).State = EntityState.Modified;
                            this.db.SaveChanges();
                            this.Productos.RemoveAt(posicion);
                            this.Productos.Insert(posicion, updateProducto);
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
                if (this.SeleccionarProducto != null)
                {
                    var respuesta = MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {

                            db.Productos.Remove(this.SeleccionarProducto);
                            db.SaveChanges();
                            this.Productos.Remove(this.SeleccionarProducto);

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
