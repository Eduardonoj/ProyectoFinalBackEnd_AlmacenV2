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
    
    class CompraViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<Compra> _Compra;
        private ACCION accion = ACCION.NINGUNO;
        private bool _IsReadOnlyNumeroDocumento = true;
        private bool _IsReadOnlyCodigoProveedor = true;
        private bool _IsReadOnlyFecha = true;
        private bool _IsReadOnlyTotal = true;
        private string _NumeroDocumento;
        private string _CodigoProveedor;
        private string _Fecha;
        private string _Total;
        private Compra _SeleccionarCompra;

        public Compra SeleccionarCompra
        {
            get { return this._SeleccionarCompra; }
            set
            {
                if (value != null)
                {
                    this._SeleccionarCompra = value;
                    this.NumeroDocumento = value.NumeroDocumento.ToString();
                    this.CodigoProveedor = value.CodigoProveedor.ToString();
                    this.Fecha = value.Fecha.ToString();
                    this.Total = value.Total.ToString();
                    NotificarCambio("SeleccionarCompra");
                }
            }
        }
        private CompraViewModel _Instancia;

        public CompraViewModel()
        {
            this.Titulo = "Compras:";
            this.Instancia = this;
        }





        public CompraViewModel Instancia
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


        public bool IsReadOnlyNumeroDocumento
        {
            get
            {
                return this._IsReadOnlyNumeroDocumento;
            }
            set
            {
                this._IsReadOnlyNumeroDocumento = value;
                NotificarCambio("IsReadOnlyNumeroDocumento");
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
                NotificarCambio("IsReadOnlyCodigoProveedor");
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

        public bool IsReadOnlyTotal
        {
            get
            {
                return this._IsReadOnlyTotal;
            }
            set
            {
                this._IsReadOnlyTotal = value;
                NotificarCambio("IsReadOnlyTotal");
            }
        }

        public string NumeroDocumento
        {
            get
            {
                return _NumeroDocumento;
            }
            set
            {
                this._NumeroDocumento = value;
                NotificarCambio("NumeroDocumento");
            }
        }
        public string CodigoProveedor
        {
            get
            {
                return _CodigoProveedor;
            }
            set
            {
                this._CodigoProveedor = value;
                NotificarCambio("CodigoProveedor");
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
        public string Total
        {
            get
            {
                return _Total;
            }
            set
            {
                this._Total = value;
                NotificarCambio("Total");
            }
        }



        public ObservableCollection<Compra> Compras
        {
            get
            {
                if (this._Compra == null)
                {
                    this._Compra = new ObservableCollection<Compra>();
                    foreach (Compra elemento in db.Compras.ToList())
                    {
                        this._Compra.Add(elemento);
                    }
                }
                return this._Compra;
            }
            set { this._Compra = value; }
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
                this.IsReadOnlyNumeroDocumento = false;
                this.IsReadOnlyCodigoProveedor = false;
                this.IsReadOnlyFecha = false;
                this.IsReadOnlyTotal = false;
                this.accion = ACCION.NUEVO;
            }
            if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.NUEVO:
                        Compra nuevo = new Compra();
                        nuevo.NumeroDocumento = Convert.ToInt32(this.NumeroDocumento);
                        nuevo.CodigoProveedor = Convert.ToInt32(this.CodigoProveedor);
                        nuevo.Fecha = DateTime.Now;
                        this.Total = this.Total;
                        db.Compras.Add(nuevo);
                        db.SaveChanges();
                        this.Compras.Add(nuevo);
                        MessageBox.Show("Registro Almacenado");
                        break;
                    case ACCION.ACTUALIZAR:
                        try
                        {
                            int posicion = this.Compras.IndexOf(this.SeleccionarCompra);
                            var updateCompra = this.db.Compras.Find(this.SeleccionarCompra.IdCompra);
                            updateCompra.NumeroDocumento = Convert.ToInt16(this.NumeroDocumento);
                            updateCompra.CodigoProveedor = Convert.ToInt16(this.CodigoProveedor);
                            updateCompra.Fecha = Convert.ToDateTime(this.Fecha);
                            updateCompra.Total = Convert.ToInt32(this.Total);                           
                            this.db.Entry(updateCompra).State = EntityState.Modified;
                            this.db.SaveChanges();
                            this.Compras.RemoveAt(posicion);
                            this.Compras.Insert(posicion, updateCompra);
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
                if (this.SeleccionarCompra != null)
                {
                    var respuesta = MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {

                            db.Compras.Remove(this.SeleccionarCompra);
                            db.SaveChanges();
                            this.Compras.Remove(this.SeleccionarCompra);

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
