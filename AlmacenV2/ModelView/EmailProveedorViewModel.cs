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
    public class EmailProveedorViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<EmailProveedor> _EmailProveedor;
        private ACCION accion = ACCION.NINGUNO;
        private bool _IsReadOnlyEmail = true;
        private bool _IsReadOnlyCodigoProveedor = true;
        private string _Email;
        private string _CodigoProveedor;

        private EmailProveedor _SeleccionarEmailProveedor;

        public EmailProveedor SeleccionarEmailProveedor
        {
            get { return this._SeleccionarEmailProveedor; }
            set
            {
                if (value != null)
                {
                    this._SeleccionarEmailProveedor = value;
                    this.Email = value.Email;
                    this.CodigoProveedor = value.CodigoProveedor.ToString();
                    NotificarCambio("SeleccionarEmailProveedor");
                }
            }
        }

        private EmailProveedorViewModel _Instancia;

        public EmailProveedorViewModel()
        {
            this.Titulo = "Email Proveedores:";
            this.Instancia = this;
        }


        public EmailProveedorViewModel Instancia
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
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                this._CodigoProveedor = value;
                NotificarCambio("Email");
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
        public ObservableCollection<EmailProveedor> EmailProveedores
        {
            get
            {
                if (this._EmailProveedor == null)
                {
                    this._EmailProveedor = new ObservableCollection<EmailProveedor>();
                    foreach (EmailProveedor elemento in db.EmailProveedores.ToList())
                    {
                        this._EmailProveedor.Add(elemento);
                    }
                }
                return this._EmailProveedor;
            }
            set { this._EmailProveedor = value; }
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
                this.IsReadOnlyCodigoProveedor = false;
                this.accion = ACCION.NUEVO;
            }
            if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.NUEVO:
                        EmailProveedor nuevo = new EmailProveedor();
                        nuevo.Email = this.Email;
                        nuevo.CodigoProveedor = Convert.ToInt16(this.CodigoProveedor);
                        db.EmailProveedores.Add(nuevo);
                        db.SaveChanges();
                        this.EmailProveedores.Add(nuevo);
                        MessageBox.Show("Registro Almacenado");
                        break;
                    case ACCION.ACTUALIZAR:
                        try
                        {
                            int posicion = this.EmailProveedores.IndexOf(this.SeleccionarEmailProveedor);
                            var updateEmailProveedor = this.db.EmailProveedores.Find(this.SeleccionarEmailProveedor.CodigoEmail);
                            updateEmailProveedor.Email = this.Email;
                            updateEmailProveedor.CodigoProveedor = Convert.ToInt16(this.CodigoProveedor);
                            this.db.Entry(updateEmailProveedor).State = EntityState.Modified;
                            this.db.SaveChanges();
                            this.EmailProveedores.RemoveAt(posicion);
                            this.EmailProveedores.Insert(posicion, updateEmailProveedor);
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
                if (this.SeleccionarEmailProveedor != null)
                {
                    var respuesta = MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {

                            db.EmailProveedores.Remove(this.SeleccionarEmailProveedor);
                            db.SaveChanges();
                            this.EmailProveedores.Remove(this.SeleccionarEmailProveedor);

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

