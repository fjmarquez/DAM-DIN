using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10MVVMBinding03.Models
{
    class clsListado
    {
        /// <summary>
        /// Devuelve una lista de personas
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<clsPersona> listadoDePersonasCompleto()
        {

            ObservableCollection<clsPersona> listadoPersonas = new ObservableCollection<clsPersona>();

            listadoPersonas.Add(new clsPersona("Francisco", "Marquez", 20, "C/ Sor Milagros 4"));
            listadoPersonas.Add(new clsPersona("Jose", "Pulido", 22, "C/ Santa Cecilia 27"));
            listadoPersonas.Add(new clsPersona("Francisco", "Pulido", 21, "C/ Pages del Corro 33"));
            listadoPersonas.Add(new clsPersona("Jose", "Marquez", 24, "C/ San Vicente de Paul 2"));
            listadoPersonas.Add(new clsPersona("Francisco Jose", "Marquez Pulido", 23, "C/ Sor Milagros 2"));


            return listadoPersonas;
        }

    }

}
