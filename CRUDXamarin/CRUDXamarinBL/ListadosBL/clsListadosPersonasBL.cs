using CRUDXamarinDAL.ListadosDAL;
using CRUDXamarinEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUDXamarinBL.ListadosBL
{
    public class clsListadosPersonasBL
    {

        /// <summary>
        /// Funcion de la capa BL que accedera a la API mediante la capa DAL y obtendra un listado de todas las personas
        /// </summary>
        /// <returns></returns>
        public async Task<List<clsPersona>> getListadoPersonasBL()
        {
            List<clsPersona> listado;

            try
            {
                listado = await new clsListadoPersonasDAL().getListadoPersonasDAL();
            }
            catch (Exception e)
            {
                throw e;
            }
            return listado;
        }

        /// <summary>
        /// Funcion de la capa BL que accedera a la API mediante la capa DAL y obtendra un objeto clsPersona 
        /// cuyo id coincida con el recibido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<clsPersona> getPersonaPorIDBL(int id)
        {
            clsPersona persona;

            try
            {
                persona = await new clsListadoPersonasDAL().getPersonaPorIDDAL(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return persona;
        }

    }
}
