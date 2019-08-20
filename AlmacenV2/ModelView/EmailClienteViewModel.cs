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
    public class EmailClienteViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<EmailCliente> _EmailCliente;
        private ACCION accion = ACCION.NINGUNO;
        private bool _IsReadOnlyEmail = true;
        private bool _IsReadOnlyNit = true;
        private string _Email;
        private string _Nit;
        private EmailCliente _SeleccionarEmailCliente;

        public EmailCliente SeleccionarEmailCliente
        {
            get { return this._SeleccionarEmailCliente; }
            set
            {
                if (value != null)
                {
                    this._SeleccionarEmailCliente = value;
                    this.Email = value.Email;
                    this.Nit = value.Nit;
                    NotificarCambio("SeleccionarEmailCliente");
                }
            }
        }

        private EmailClienteViewModel _Instancia;

        public EmailClienteViewModel()
        {
            this.Titulo = "Email Clientes:";
            this.Instancia = this;
        }

        public EmailClienteViewModel Instancia
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



        public bool IsReadOnlyEmail
        {
            get
            {
                return this._IsReadOnlyEmail;
            }
            set
            {
                this._IsReadOnlyEmail = value;
                NotificarCambio("IsReadOnlyEmail");
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
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                this._Email = value;
                NotificarCambio("Email");
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
        public ObservableCollection<EmailCliente> EmailClientes
        {
            get
            {
                if (this._EmailCliente == null)
                {
                    this._EmailCliente = new ObservableCollection<EmailCliente>();
                    foreach (EmailCliente elemento in db.EmailClientes.ToList())
                    {
                        this._EmailCliente.Add(elemento);
                    }

                }
                return this._EmailCliente;
            }
            set { this._EmailCliente = value; }
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
                this.IsReadOnlyEmail = false;
                this.IsReadOnlyNit = false;
                this.accion = ACCION.NUEVO;
            }
            if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.NUEVO:
                        EmailCliente nuevo = new EmailCliente();
                        nuevo.Email = this.Email;
                        nuevo.Nit = this.Nit;
                        db.EmailClientes.Add(nuevo);
                        db.SaveChanges();
                        this.EmailClientes.Add(nuevo);
                        MessageBox.Show("Registro Almcenado");
                        break;
                    case ACCION.ACTUALIZAR:
                        try
                        {
                            int posicion = this.EmailClientes.IndexOf(this.SeleccionarEmailCliente);
                            var updateEmailCliente = this.db.EmailClientes.Find(this.SeleccionarEmailCliente.CodigoEmail);
                            updateEmailCliente.Email = this.Email;
                            updateEmailCliente.Nit = this.Nit;
                            this.db.Entry(updateEmailCliente).State = EntityState.Modified;
                            this.db.SaveChanges();
                            this.EmailClientes.RemoveAt(posicion);
                            this.EmailClientes.Insert(posicion, updateEmailCliente);
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
                if (this.SeleccionarEmailCliente != null)
                {
                    var respuesta = MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {

                            db.EmailClientes.Remove(this.SeleccionarEmailCliente);
                            db.SaveChanges();
                            this.EmailClientes.Remove(this.SeleccionarEmailCliente);

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
