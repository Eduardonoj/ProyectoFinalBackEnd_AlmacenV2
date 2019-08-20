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
   
    public class DetalleCompraViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<DetalleCompra> _DetalleCompra;
        private ACCION accion = ACCION.NINGUNO;
        private bool _IsReadOnlyIdCompra = true;
        private bool _IsReadOnlyCodigoProducto = true;
        private bool _IsReadOnlyCantidad = true;
        private bool _IsReadOnlyPrecio = true;
        private string _IdCompra;
        private string _CodigoProducto;
        private string _Cantidad;
        private string _Precio;
        private DetalleCompra _SeleccionarDetalleCompra;

        public DetalleCompra SeleccionarDetalleCompra
        {
            get { return this._SeleccionarDetalleCompra; }
            set
            {
                if (value != null)
                {
                    this._SeleccionarDetalleCompra = value;
                    this.IdCompra = value.IdCompra.ToString();
                    this.CodigoProducto = value.CodigoProducto.ToString();
                    this.Cantidad = value.Cantidad.ToString();
                    this.Precio = value.Precio.ToString();
                    NotificarCambio("SeleccionarDetalleCompra");
                }
            }
        }
        private DetalleCompraViewModel _Instancia;

        public DetalleCompraViewModel()
        {
            this.Titulo = "Detalle Compras:";
            this.Instancia = this;
        }



        public DetalleCompraViewModel Instancia
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


        public bool IsReadOnlyIdCompra
        {
            get
            {
                return this._IsReadOnlyIdCompra;
            }
            set
            {
                this._IsReadOnlyIdCompra = value;
                NotificarCambio("IsReadOnlyIdCompra");
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
        public bool IsReadOnlyCantidad
        {
            get
            {
                return this._IsReadOnlyCantidad;
            }
            set
            {
                this._IsReadOnlyCantidad = value;
                NotificarCambio("IsReadOnlyCantidad");
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
        public string IdCompra
        {
            get
            {
                return _IdCompra;
            }
            set
            {
                this._IdCompra = value;
                NotificarCambio("IdCompra");
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
        public string Cantidad
        {
            get
            {
                return _Cantidad;
            }
            set
            {
                this._Cantidad = value;
                NotificarCambio("Cantidad");
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


        public ObservableCollection<DetalleCompra> DetalleCompras
        {
            get
            {
                if (this._DetalleCompra == null)
                {
                    this._DetalleCompra = new ObservableCollection<DetalleCompra>();
                    foreach (DetalleCompra elemento in db.DetalleCompras.ToList())
                    {
                        this._DetalleCompra.Add(elemento);
                    }
                }
                return this._DetalleCompra;
            }
            set { this._DetalleCompra = value; }
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
            return true; ;
        }

        public void Execute(object parameter)
        {
            if (parameter.Equals("Add"))
            {
                this.IsReadOnlyIdCompra = false;
                this.IsReadOnlyCodigoProducto = false;
                this.IsReadOnlyCantidad = false;
                this.IsReadOnlyPrecio = false;
                this.accion = ACCION.NUEVO;
            }
            if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.NUEVO:

                        DetalleCompra nuevo = new DetalleCompra();
                        nuevo.IdCompra = Convert.ToInt32(this.IdCompra);
                        nuevo.CodigoProducto = Convert.ToInt32(this.CodigoProducto);
                        nuevo.Cantidad = Convert.ToInt16(this.Cantidad);
                        nuevo.Precio = Convert.ToDecimal(this.Precio);
                        db.DetalleCompras.Add(nuevo);
                        db.SaveChanges();
                        this.DetalleCompras.Add(nuevo);
                        MessageBox.Show("Registro Almacenado");
                        break;
                    case ACCION.ACTUALIZAR:
                        try
                        {
                            int posicion = this.DetalleCompras.IndexOf(this.SeleccionarDetalleCompra);
                            var updateDetalleCompra = this.db.DetalleCompras.Find(this.SeleccionarDetalleCompra.IdDetalle);
                            updateDetalleCompra.IdCompra = Convert.ToInt16(this.IdCompra);
                            updateDetalleCompra.CodigoProducto = Convert.ToInt16(this.CodigoProducto);
                            updateDetalleCompra.Cantidad = Convert.ToInt16(this.Cantidad);
                            updateDetalleCompra.Precio = Convert.ToDecimal(this.Precio);
                            this.db.Entry(updateDetalleCompra).State = EntityState.Modified;
                            this.db.SaveChanges();
                            this.DetalleCompras.RemoveAt(posicion);
                            this.DetalleCompras.Insert(posicion, updateDetalleCompra);
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
                if (this.SeleccionarDetalleCompra != null)
                {
                    var respuesta = MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {

                            db.DetalleCompras.Remove(this.SeleccionarDetalleCompra);
                            db.SaveChanges();
                            this.DetalleCompras.Remove(this.SeleccionarDetalleCompra);

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

