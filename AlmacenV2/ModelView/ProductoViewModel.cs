using AlmacenV2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AlmacenV2.ModelView
{
    public class ProductoViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
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


        private ObservableCollection<Producto> _Producto;

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
            }
        }
    }
}
