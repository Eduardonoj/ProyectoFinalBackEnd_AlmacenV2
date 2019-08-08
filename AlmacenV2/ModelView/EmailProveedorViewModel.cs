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
    public class EmailProveedorViewModel : INotifyPropertyChanged
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<EmailProveedor> _EmailProveedor;
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
    }
}

