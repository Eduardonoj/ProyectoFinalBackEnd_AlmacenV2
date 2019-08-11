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
    public class TipoEmpaqueViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private bool _IsReadOnlyDescripcion = true;
        private string _Descripcion;
        private ObservableCollection<TipoEmpaque> _TipoEmpaque;

        private TipoEmpaqueViewModel _Instancia;

        public TipoEmpaqueViewModel()
        {
            this.Titulo = "Tipo Empaques:";
            this.Instancia = this;
        }


        public TipoEmpaqueViewModel Instancia
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
                this.IsReadOnlyDescripcion = false;
               
            }
        }
    }
}
