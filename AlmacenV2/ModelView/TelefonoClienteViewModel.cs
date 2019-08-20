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
    public class TelefonoClienteViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<TelefonoCliente> _TelefonoCliente;
        private ACCION accion = ACCION.NINGUNO;
        private bool _IsReadOnlyNumero = true;
        private bool _IsReadOnlyDescripcion = true;
        private bool _IsReadOnlyNit = true;
        private string _Numero;
        private string _Descripcion;
        private string _Nit;
        private TelefonoCliente _SeleccionarTelefonoCliente;

        public TelefonoCliente SeleccionarTelefonoCliente
        {
            get { return this._SeleccionarTelefonoCliente; }
            set
            {
                if (value != null)
                {
                    this._SeleccionarTelefonoCliente = value;
                    this.Numero = value.Numero;
                    this.Descripcion = value.Descripcion;
                    this.Nit = value.Nit;
                    NotificarCambio("SeleccionarTelefonCliente");
                }
            }
        }


        private TelefonoClienteViewModel _Instancia;

        public TelefonoClienteViewModel()
        {
            this.Titulo = "Telefono Clientes:";
            this.Instancia = this;
        }

        public TelefonoClienteViewModel Instancia
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
        public ObservableCollection<TelefonoCliente> TelefonoClientes
        {
            get
            {
                if (this._TelefonoCliente == null)
                {
                    this._TelefonoCliente = new ObservableCollection<TelefonoCliente>();
                    foreach (TelefonoCliente elemento in db.TelefonoClientes.ToList())
                    {
                        this._TelefonoCliente.Add(elemento);
                    }
                }
                return this._TelefonoCliente;
            }
            set { this._TelefonoCliente = value; }
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
                this.IsReadOnlyNit = false;
                this.accion = ACCION.NUEVO;

            }
            if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.NUEVO:
                        TelefonoCliente nuevo = new TelefonoCliente();
                        nuevo.Numero = this.Numero;
                        nuevo.Descripcion = this.Descripcion;
                        nuevo.Nit = this.Nit;
                        db.TelefonoClientes.Add(nuevo);
                        db.SaveChanges();
                        this.TelefonoClientes.Add(nuevo);
                        MessageBox.Show("Registro Almacenado");
                        break;
                    case ACCION.ACTUALIZAR:
                        try
                        {
                            int posicion = this.TelefonoClientes.IndexOf(this.SeleccionarTelefonoCliente);
                            var updateTelefonoCliente = this.db.TelefonoClientes.Find(this.SeleccionarTelefonoCliente.CodigoTelefono);
                            updateTelefonoCliente.Numero = this.Numero;
                            updateTelefonoCliente.Descripcion = this.Descripcion;
                            updateTelefonoCliente.Nit = this.Nit;
                            this.db.Entry(updateTelefonoCliente).State = EntityState.Modified;
                            this.db.SaveChanges();
                            this.TelefonoClientes.RemoveAt(posicion);
                            this.TelefonoClientes.Insert(posicion, updateTelefonoCliente);
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
                if (this.SeleccionarTelefonoCliente != null)
                {
                    var respuesta = MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {

                            db.TelefonoClientes.Remove(this.SeleccionarTelefonoCliente);
                            db.SaveChanges();
                            this.TelefonoClientes.Remove(this.SeleccionarTelefonoCliente);

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
