using Examen2TrimestreDAL.Listados;
using Examen2TrimestreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2TrimestreBL.Listados
{
    public class clsListadosAulasBL
    {
        /// <summary>
        /// Funcion de la capa BL que obtendra un listado de aulas a traves de la capa BL
        /// </summary>
        /// <returns></returns>
        public List<aula> getListadoAulas()
        {

            List<aula> list;

            try
            {

                list = new clsListadosAulasDAL().getListadoAulas();

            }catch(Exception e)
            {

                list = null;

            }

            return list;

        }

    }
}
