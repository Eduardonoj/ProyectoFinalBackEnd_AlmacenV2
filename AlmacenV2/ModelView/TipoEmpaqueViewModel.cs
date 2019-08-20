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
    public class TipoEmpaqueViewModel : INotifyPropertyChanged, ICommand
    {
        private InventarioDataContext db = new InventarioDataContext();
        private ObservableCollection<TipoEmpaque> _TipoEmpaque;
        private ACCION accion = ACCION.NINGUNO;
        private bool _IsReadOnlyDescripcion = true;
        private string _Descripcion;
        private TipoEmpaque _SeleccionarTipoEmpaque;

        public TipoEmpaque SeleccionarTipoEmpaque
        {
            get { return this._SeleccionarTipoEmpaque; }
            set
            {
                if (value != null)
                {
                    this._SeleccionarTipoEmpaque = value;
                    this.Descripcion = value.Descripcion;
                    NotificarCambio("SeleccionarTipoEmpaque");
                }
            }
        }


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
                this.accion = ACCION.NUEVO;

            }
            if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.NUEVO:
                        TipoEmpaque nuevo = new TipoEmpaque();
                        nuevo.Descripcion = this.Descripcion;
                        db.TipoEmpaques.Add(nuevo);
                        db.SaveChanges();
                        this.TipoEmpaques.Add(nuevo);
                        MessageBox.Show("Registro Almacenado");
                        break;
                    case ACCION.ACTUALIZAR:
                        try
                        {
                            int posicion = this.TipoEmpaques.IndexOf(this.SeleccionarTipoEmpaque);
                            var updateTipoEmpaque = this.db.TipoEmpaques.Find(this.SeleccionarTipoEmpaque.CodigoEmpaque);
                            updateTipoEmpaque.Descripcion = this.Descripcion;
                            this.db.Entry(updateTipoEmpaque).State = EntityState.Modified;
                            this.db.SaveChanges();
                            this.TipoEmpaques.RemoveAt(posicion);
                            this.TipoEmpaques.Insert(posicion, updateTipoEmpaque);
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
                if (this.SeleccionarTipoEmpaque != null)
                {
                    var respuesta = MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {

                            db.TipoEmpaques.Remove(this.SeleccionarTipoEmpaque);
                            db.SaveChanges();
                            this.TipoEmpaques.Remove(this.SeleccionarTipoEmpaque);

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
