using Examen2TrimestreBL.Listados;
using Examen2TrimestreEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Examen2TrimestreUI.Models
{
    public class VMGeneral : INotifyPropertyChanged
    {

        #region Propiedades publicas

        private List<aula> listadoAulas;
        private aula aulaSeleccionada;
        private List<temperaturas> temperaturasAula;
        private temperaturas temperaturaSolicitada;

        #endregion

        #region Atributos privados

        public List<aula> ListadoAulas
        {

            get
            {

                return listadoAulas;

            }

            set
            {

                this.listadoAulas = value;

            }

        }

        public aula AulaSeleccionada
        {

            get
            {

                return aulaSeleccionada;

            }

            set
            {

                this.aulaSeleccionada = value;
                //Obtenemos el listado de temperaturas correspondiente al aula seleccionada
                temperaturasAula = new clsListadoTemperaturasBL().getTemperaturasPorAula(aulaSeleccionada.Id);
                NotifyPropertyChanged("TemperaturasAula");


            }

        }


        public List<temperaturas> TemperaturasAula
        {

            get
            {

                return this.temperaturasAula;

            }

        }

        public temperaturas TemperaturaSolicitada
        {

            get
            {

                return this.temperaturaSolicitada;

            }

            set
            {

                this.temperaturaSolicitada = value;
                NotifyPropertyChanged("TemperaturaSolicitada");

            }

        }

        #endregion

        #region Constructor

        public VMGeneral()
        {

            try
            {
                //Obtenemos el listado de aulas que mostraremos al iniciar la aplicacion
                listadoAulas = new clsListadosAulasBL().getListadoAulas();
                temperaturasAula = new List<temperaturas>();
                aulaSeleccionada = new aula();

            }catch(Exception e)
            {



            }

        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Eventos



        #endregion

    }
}
