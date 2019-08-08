using AlmacenV2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenV2.ModelView
{
    public class TelefonoClienteViewModel : INotifyPropertyChanged
    {
        private InventarioDataContext db = new InventarioDataContext();
        private bool _IsReadOnlyNumero = true;
        private bool _IsReadOnlyDescripcion = true;
        private bool _IsReadOnlyNit = true;
        private ObservableCollection<TelefonoCliente> _TelefonoCliente;


        public bool IsReadOnlyNumero
        {
            get
            {
                return this._IsReadOnlyNumero;
            }
            set
            {
                this._IsReadOnlyNumero = value;
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
            }
        }
        public ObservableCollection<TelefonoCliente> TelefonoClientes
        {
            get
            {
                if(this._TelefonoCliente == null)
                {
                    this._TelefonoCliente = new ObservableCollection<TelefonoCliente>();
                    foreach(TelefonoCliente elemento in db.TelefonoClientes.ToList())
                    {
                        this._TelefonoCliente.Add(elemento);
                    }
                }
                return this._TelefonoCliente; 
            }
            set { this._TelefonoCliente = value;}
        }

        public TelefonoClienteViewModel()
        {
            this.Titulo = "Telefono Clientes:";
        }
        public string Titulo { get; set;}
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
