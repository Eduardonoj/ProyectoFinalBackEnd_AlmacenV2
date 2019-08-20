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
    public class TelefonoProveedorViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        public ObservableCollection<TelefonoProveedor> _TelefonoProveedor;
        private ACCION accion = ACCION.NINGUNO;

        private bool _IsReadOnlyNumero = true;
        private bool _IsReadOnlyDescripcion = true;
        private bool _IsReadOnlyCodigoProveedor = true;
        private string _Numero;
        private string _Descripcion;
        private string _CodigoProveedor;
        private TelefonoProveedor _SeleccionarTelefonoProveedor;

        public TelefonoProveedor SeleccionarTelefonoProveedor
        {
            get { return this._SeleccionarTelefonoProveedor; }
            set
            {
                if (value != null)
                {
                    this._SeleccionarTelefonoProveedor = value;
                    this.Numero = value.Numero;
                    this.Descripcion = value.Descripcion;
                    this.CodigoProveedor = value.CodigoProveedor.ToString();
                    NotificarCambio("SeleccionarTelefonProveedor");
                }
            }
        }



        private TelefonoProveedorViewModel _Instancia;

        public TelefonoProveedorViewModel()
        {
            this.Titulo = "Telefono Proveedores:";
            this.Instancia = this;
        }


        public TelefonoProveedorViewModel Instancia
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

        public bool IsReadOnlyNumero
        {
            get
            {
                return this._IsReadOnlyNumero;
            }
            set
            {
                this._IsReadOnlyNumero = value;
                NotificarCambio("IsReadOnlyNumero");
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
        public string Numero
        {
            get
            {
                return _Numero;
            }
            set
            {
                this._Numero = value;
                NotificarCambio("Numero");
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



        public ObservableCollection<TelefonoProveedor> TelefonoProveedores
        {
            get
            {
                if (this._TelefonoProveedor == null)
                {
                    this._TelefonoProveedor = new ObservableCollection<TelefonoProveedor>();
                    foreach (TelefonoProveedor elemento in db.TelefonoProveedores.ToList())
                    {
                        this._TelefonoProveedor.Add(elemento);
                    }
                }
                return this._TelefonoProveedor;
            }
            set { this._TelefonoProveedor = value; }
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
                this.IsReadOnlyNumero = false;
                this.IsReadOnlyDescripcion = false;
                this.IsReadOnlyCodigoProveedor = false;
                this.accion = ACCION.NUEVO;

            }
            if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.NUEVO:
                        TelefonoProveedor nuevo = new TelefonoProveedor();
                        nuevo.Numero = this.Numero;
                        nuevo.Descripcion = this.Descripcion;
                        nuevo.CodigoProveedor = Convert.ToInt16(this.CodigoProveedor);
                        db.TelefonoProveedores.Add(nuevo);
                        db.SaveChanges();
                        this.TelefonoProveedores.Add(nuevo);
                        MessageBox.Show("Registro Almacenado");
                        break;
                    case ACCION.ACTUALIZAR:
                        try
                        {
                            int posicion = this.TelefonoProveedores.IndexOf(this.SeleccionarTelefonoProveedor);
                            var updateTelefonoProveedor = this.db.TelefonoProveedores.Find(this.SeleccionarTelefonoProveedor.CodigoTelefono);
                            updateTelefonoProveedor.Numero = this.Numero;
                            updateTelefonoProveedor.Descripcion = this.Descripcion;
                            updateTelefonoProveedor.CodigoProveedor = Convert.ToInt16(this.CodigoProveedor);
                            this.db.Entry(updateTelefonoProveedor).State = EntityState.Modified;
                            this.db.SaveChanges();
                            this.TelefonoProveedores.RemoveAt(posicion);
                            this.TelefonoProveedores.Insert(posicion, updateTelefonoProveedor);
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
                if (this.SeleccionarTelefonoProveedor != null)
                {
                    var respuesta = MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {

                            db.TelefonoProveedores.Remove(this.SeleccionarTelefonoProveedor);
                            db.SaveChanges();
                            this.TelefonoProveedores.Remove(this.SeleccionarTelefonoProveedor);

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
