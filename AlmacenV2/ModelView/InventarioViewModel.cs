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
    public class InventarioViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<Inventario> _Inventario;
        private ACCION accion = ACCION.NINGUNO;
        private bool _IsReadOnlyCodigoProducto = true;
        private bool _IsReadOnlyFecha = true;
        private bool _IsReadOnlyTipoRegistro = true;
        private bool _IsReadOnlyPrecio = true;
        private bool _IsReadOnlyEntradas = true;
        private bool _IsReadOnlySalidas = true;
        private string _CodigoProducto;
        private string _Fecha;
        private string _TipoRegistro;
        private string _Precio;
        private string _Entradas;
        private string _Salidas;
        private Inventario _SeleccionarInventario;

        public Inventario SeleccionarInventario
        {
            get { return this._SeleccionarInventario; }
            set
            {
                if (value != null)
                {
                    this._SeleccionarInventario = value;
                    this.CodigoProducto = value.CodigoProducto.ToString();
                    this.Fecha = value.Fecha.ToString();
                    this.TipoRegistro = value.TipoRegistro;
                    this.Precio = value.Precio.ToString();
                    this.Entradas = value.Entradas.ToString();
                    this.Salidas = value.Salidas.ToString();
                    NotificarCambio("SeleccionarInventario");
                }
            }
        }




        private InventarioViewModel _Instancia;

        public InventarioViewModel()
        {
            this.Titulo = "Inventarios:";
            this.Instancia = this;
        }



        private ObservableCollection<Compra> _Compra;

        public InventarioViewModel Instancia
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

        public bool IsReadOnlyCodigoProducto
        {
            get
            {
                return this._IsReadOnlyCodigoProducto;
            }
            set
            {
                this._IsReadOnlyCodigoProducto = value;
                NotificarCambio("IsReadOnlyCodigoProducto");
            }
        }

        public bool IsReadOnlyFecha
        {
            get
            {
                return this._IsReadOnlyFecha;
            }
            set
            {
                this._IsReadOnlyFecha = value;
                NotificarCambio("IsReadOnlyFecha");
            }
        }

        public bool IsReadOnlyTipoRegistro
        {
            get
            {
                return this._IsReadOnlyTipoRegistro;
            }
            set
            {
                this._IsReadOnlyTipoRegistro = value;
                NotificarCambio("IsReadOnlyTipoRegistro");
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
                NotificarCambio("IsReadOnlyPrecio");
            }
        }

        public bool IsReadOnlyEntradas
        {
            get
            {
                return this._IsReadOnlyEntradas;
            }
            set
            {
                this._IsReadOnlyEntradas = value;
                NotificarCambio("IsReadOnlyEntradas");
            }
        }

        public bool IsReadOnlySalidas
        {
            get
            {
                return this._IsReadOnlySalidas;
            }
            set
            {
                this._IsReadOnlySalidas = value;
                NotificarCambio("IsReadOnlySalidas");
            }
        }
        public string CodigoProducto
        {
            get
            {
                return _CodigoProducto;
            }
            set
            {
                this._CodigoProducto = value;
                NotificarCambio("CodigoProducto");
            }
        }
        public string Fecha
        {
            get
            {
                return _Fecha;
            }
            set
            {
                this._Fecha = value;
                NotificarCambio("Fecha");
            }
        }

        public string TipoRegistro
        {
            get
            {
                return _TipoRegistro;
            }
            set
            {
                this._TipoRegistro = value;
                NotificarCambio("TipoRegistro");
            }
        }

        public string Precio
        {
            get
            {
                return _Precio;
            }
            set
            {
                this._Precio = value;
                NotificarCambio("Precio");
            }
        }
        public string Entradas
        {
            get
            {
                return _Entradas;
            }
            set
            {
                this._Entradas = value;
                NotificarCambio("Entradas");
            }
        }
        public string Salidas
        {
            get
            {
                return _Salidas;
            }
            set
            {
                this._Salidas = value;
                NotificarCambio("Salidas");
            }
        }

        public ObservableCollection<Inventario> Inventarios
        {
            get
            {
                if (this._Inventario == null)
                {
                    this._Inventario = new ObservableCollection<Inventario>();
                    foreach (Inventario elemento in db.Inventarios.ToList())
                    {
                        this._Inventario.Add(elemento);
                    }
                }
                return this._Inventario;
            }
            set { this._Inventario = value; }
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
                this.IsReadOnlyCodigoProducto = false;
                this.IsReadOnlyFecha = false;
                this.IsReadOnlyTipoRegistro = false;
                this.IsReadOnlyPrecio = false;
                this.IsReadOnlyEntradas = false;
                this.IsReadOnlySalidas = false;
                this.accion = ACCION.NUEVO;
            }
            if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.NUEVO:
                        Inventario nuevo = new Inventario();
                        nuevo.CodigoProducto = Convert.ToInt16(this.CodigoProducto);
                        nuevo.Fecha = DateTime.Now;
                        nuevo.TipoRegistro = this.TipoRegistro;
                        nuevo.Precio = Convert.ToDecimal(this.Precio);
                        nuevo.Entradas = Convert.ToInt16(this.Entradas);
                        nuevo.Salidas = Convert.ToInt16(this.Salidas);
                        db.Inventarios.Add(nuevo);
                        db.SaveChanges();
                        this.Inventarios.Add(nuevo);
                        MessageBox.Show("Registro Almacenado");
                        break;
                    case ACCION.ACTUALIZAR:
                        try
                        {

                            int posicion = this.Inventarios.IndexOf(this.SeleccionarInventario);
                            var updateInventario = this.db.Inventarios.Find(this.SeleccionarInventario.CodigoInventario);
                            updateInventario.CodigoProducto = Convert.ToInt16(this.CodigoProducto);
                            updateInventario.Fecha = Convert.ToDateTime(this.Fecha);
                            updateInventario.TipoRegistro = this.TipoRegistro;
                            updateInventario.Precio = Convert.ToDecimal(this.Precio);
                            updateInventario.Entradas = Convert.ToInt16(this.Entradas);
                            updateInventario.Salidas = Convert.ToInt16(this.Salidas);
                            this.db.Entry(updateInventario).State = EntityState.Modified;
                            this.db.SaveChanges();
                            this.Inventarios.RemoveAt(posicion);
                            this.Inventarios.Insert(posicion, updateInventario);
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
                if (this.SeleccionarInventario != null)
                {
                    var respuesta = MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {

                            db.Inventarios.Remove(this.SeleccionarInventario);
                            db.SaveChanges();
                            this.Inventarios.Remove(this.SeleccionarInventario);

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
