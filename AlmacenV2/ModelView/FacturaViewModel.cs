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
    public class FacturaViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<Factura> _Factura;
        private ACCION accion = ACCION.NINGUNO;
        private bool _IsReadOnlyNit = true;
        private bool _IsReadOnlyFecha = true;
        private bool _IsReadOnlyTotal = true;
        private string _Nit;
        private string _Fecha;
        private string _Total;
        private Factura _SeleccionarFactura;

        public Factura SeleccionarFactura
        {
            get { return this._SeleccionarFactura; }
            set
            {
                if (value != null)
                {
                    this._SeleccionarFactura = value;
                    this.Nit = value.Nit;
                    this.Fecha = value.Fecha.ToString();
                    this.Total = value.Total.ToString();
                    NotificarCambio("SeleccionarFactura");
                }
            }
        }

        private FacturaViewModel _Instancia;

        public FacturaViewModel()
        {
            this.Titulo = "Facturas:";
            this.Instancia = this;
        }


        public FacturaViewModel Instancia
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
        public bool IsReadOnlyNit
        {
            get
            {
                return this._IsReadOnlyNit;
            }
            set
            {
                this._IsReadOnlyNit = value;
                NotificarCambio("IsReadOnlyNit");
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
        public string Nit
        {
            get
            {
                return _Nit;
            }
            set
            {
                this._Nit = value;
                NotificarCambio("Nit");
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
                this._Nit = value;
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
        public ObservableCollection<Factura> Facturas
        {
            get
            {
                if (this._Factura == null)
                {
                    this._Factura = new ObservableCollection<Factura>();
                    foreach (Factura elemento in db.Facturas.ToList())
                    {
                        this._Factura.Add(elemento);
                    }
                }
                return this._Factura;
            }
            set { this._Factura = value; }
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
                this.IsReadOnlyNit = false;
                this.IsReadOnlyFecha = false;
                this.IsReadOnlyTotal = false;
                this.accion = ACCION.NUEVO;
            }
            if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.NUEVO:
                        Factura nuevo = new Factura();
                        nuevo.Nit = this.Nit;
                        nuevo.Fecha = DateTime.Now;
                        nuevo.Total = Convert.ToDecimal(this.Total);
                        db.Facturas.Add(nuevo);
                        db.SaveChanges();
                        this.Facturas.Add(nuevo);
                        MessageBox.Show("Registro Almacenado");
                        break;
                    case ACCION.ACTUALIZAR:
                        try
                        {
                            int posicion = this.Facturas.IndexOf(this.SeleccionarFactura);
                            var updateFactura = this.db.Facturas.Find(this.SeleccionarFactura.NumeroFactura);
                            updateFactura.Nit = this.Nit;
                            updateFactura.Fecha = DateTime.Now;
                            updateFactura.Total = Convert.ToDecimal(this.Total);
                            this.db.Entry(updateFactura).State = EntityState.Modified;
                            this.db.SaveChanges();
                            this.Facturas.RemoveAt(posicion);
                            this.Facturas.Insert(posicion, updateFactura);
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
                if (this.SeleccionarFactura != null)
                {
                    var respuesta = MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {

                            db.Facturas.Remove(this.SeleccionarFactura);
                            db.SaveChanges();
                            this.Facturas.Remove(this.SeleccionarFactura);

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
