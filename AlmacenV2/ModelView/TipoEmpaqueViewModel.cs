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
    public class TipoEmpaqueViewModel : INotifyPropertyChanged
    {
        private InventarioDataContext db = new InventarioDataContext();
        private bool _IsReadOnlyDescripcion = true;
        
        private ObservableCollection<TipoEmpaque> _TipoEmpaque;

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

        public ObservableCollection<TipoEmpaque> TipoEmpaques
        {
            get
            {
                if (this._TipoEmpaque == null)
                {
                    this._TipoEmpaque = new ObservableCollection<TipoEmpaque>();
                    foreach (TipoEmpaque elemento in db.TipoEmpaques.ToList())
                    {
                        this._TipoEmpaque.Add(elemento);
                    }
                }
                return this._TipoEmpaque;
            }
            set { this._TipoEmpaque = value; }
        }
        public TipoEmpaqueViewModel()
        {
            this.Titulo = "Tipo Empaques:";
        }
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
