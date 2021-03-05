using Examen2TrimestreDAL.Listados;
using Examen2TrimestreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2TrimestreBL.Listados
{
    public class clsListadoTemperaturasBL
    {
        /// <summary>
        /// Funcion de la capa BL que obtendra un listado de temperaturas filtrado por el id de aula recibido por parametro
        /// </summary>
        /// <param name="idAula"></param>
        /// <returns></returns>
        public List<temperaturas> getTemperaturasPorAula(int idAula)
        {
            List<temperaturas> list = new List<temperaturas>();

            try
            {

                list = new clsListadoTemperaturasDAL().getTemperaturasPorAula(idAula);

            }catch(Exception e)
            {

                list = null;

            }

            return list;

        }

    }
}
