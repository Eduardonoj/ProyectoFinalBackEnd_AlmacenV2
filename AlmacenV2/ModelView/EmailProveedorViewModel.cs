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
    public class EmailProveedorViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private bool _IsReadOnlyEmail = true;
        private bool _IsReadOnlyCodigoProveedor = true;
        private string _Email;
        private string _CodigoProveedor;

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

        private ObservableCollection<EmailProveedor> _EmailProveedor;

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

        public string CodigoProveedor{
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
                if(this._EmailProveedor == null)
                {
                    this._EmailProveedor = new ObservableCollection<EmailProveedor>();
                    foreach(EmailProveedor elemento in db.EmailProveedores.ToList())
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
            }
            
        }
    }
}

