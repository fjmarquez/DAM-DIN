using CRUDXamarinBL.ListadosBL;
using CRUDXamarinEntities;
using CRUDXamarinUI.Utils;
using CRUDXamarinUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace CRUDXamarinUI.Models
{
    public class DepartamentosListadoVM : INotifyPropertyChanged
    {

        #region Atributos privados

        private ObservableCollection<clsDepartamento> listadoDepartamentos;
        private clsDepartamento departamentoSeleccionado;

        #endregion

        #region Propiedades publicas

        //Propiedad publica de listadoDepartamentos
        public ObservableCollection<clsDepartamento> ListadoDepartamentos
        {
            get
            {
                return listadoDepartamentos;
            }
        }

        //Propiedad publica de departamentoSeleccionado
        public clsDepartamento DepartamentoSeleccionado
        {
            get
            {
                return departamentoSeleccionado;
            }
            set
            {
                if (this.departamentoSeleccionado != value && value != null)
                {
                    this.departamentoSeleccionado = value;
                }
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase DepartamentosListadoVM
        /// </summary>
        public DepartamentosListadoVM()
        {

        }

        /// <summary>
        /// Funcion asincrona donde inicializamos listadoDepartamentos, a traves de la capa BL
        /// </summary>
        public async void onInit()
        {

            this.listadoDepartamentos = new ObservableCollection<clsDepartamento>(await new clsListadosDepartamentosBL().getListadoDepartamentosBL());
            NotifyPropertyChanged("ListadoDepartamentos");

        }

        #endregion


        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        #region DelegateCommands


        #endregion


    }
}
