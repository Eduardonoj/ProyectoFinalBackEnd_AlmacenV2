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
    public class EmailClienteViewModel : INotifyPropertyChanged
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<EmailCliente> _EmailCliente;
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
    }
}
