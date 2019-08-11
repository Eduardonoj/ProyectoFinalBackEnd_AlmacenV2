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
    public class ClienteViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private bool _IsReadOnlyDpi = true;
        private bool _IsReadOnlyNombre = true;
        private bool _IsReadOnlyDireccion = true;
        private string _Dpi;
        private string _Nombre;
        private string _Direccion;

        private ClienteViewModel _Instancia;

        public ClienteViewModel()
        {
            this.Titulo = "Clientes:";
            this.Instancia = this;
        }



        private ObservableCollection<Cliente> _Cliente;

        public ClienteViewModel Instancia
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



        public bool IsReadOnlyDpi
        {
            get
            {
                return this._IsReadOnlyDpi;
            }
            set
            {
                this._IsReadOnlyDpi = value;
                NotificarCambio("IsReadOnlyDpi");
            }
        }

        public bool IsReadOnlyNombre
        {
            get
            {
                return this._IsReadOnlyNombre;
            }
            set
            {
                this._IsReadOnlyNombre = value;
                NotificarCambio("IsReadOnlyNombre");
            }
        }

        public bool IsReadOnlyDireccion
        {
            get
            {
                return this._IsReadOnlyDireccion;
            }
            set
            {
                this._IsReadOnlyDireccion = value;
                NotificarCambio("IsReadOnlyDireccion");
            }
        }

        public string Dpi
        {
            get
            {
                return _Dpi;
            }
            set
            {
                this._Dpi = value;
                NotificarCambio("Dpi");
            }
        }
        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                this._Nombre = value;
                NotificarCambio("Nombre");
            }
        }
        public string Direccion
        {
            get
            {
                return _Direccion;
            }
            set
            {
                this._Direccion = value;
                NotificarCambio("Direccion");
            }
        }
        public ObservableCollection<Cliente> Clientes
        {
            get
            {
                if(this._Cliente == null)
                {
                    this._Cliente = new ObservableCollection<Cliente>();
                    foreach (Cliente elemento in db.Clientes.ToList())
                    {
                        this._Cliente.Add(elemento);
                    }
                }
                return this._Cliente;
            }
            set { this._Cliente = value;}
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
                this.IsReadOnlyDpi = false;
                this.IsReadOnlyNombre = false;
                this.IsReadOnlyDireccion = false;
            }
        }
    }
}
