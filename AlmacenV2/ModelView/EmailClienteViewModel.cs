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
    public class EmailClienteViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();

        private bool _IsReadOnlyEmail = true;
        private bool _IsReadOnlyNit = true;
        private string _Email;
        private string _Nit;

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

        private ObservableCollection<EmailCliente> _EmailCliente;

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
            }
           
        }
    }
}
