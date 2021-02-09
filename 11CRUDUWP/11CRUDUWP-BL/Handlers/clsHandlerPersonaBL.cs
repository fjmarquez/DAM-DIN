using _11CRUDUWP_DAL.Handlers;
using _11CRUDUWP_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11CRUDUWP_BL.Handlers
{
    public class clsHandlerPersonaBL
    {
        /// <summary>
        /// Funcion de la capa BL, la cual usa la capa DAL para acceder a la BD Azure y eliminar la persona cuyo id se corresponde
        /// con el id recibido por parametros
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int deletePersonaBL(int id)
        {
            int fieldCount;

            try
            {

            }catch(Exception e)
            {

            }


            fieldCount = new clsHandlerPersonaDAL().deletePersonaDAL(id);

            return fieldCount;
        }

        /// <summary>
        /// Funcion de la capa BL, la cual usa la capa DAL para acceder a la BD Azure y actualiza los registros de la persona 
        /// recibida por parametros
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int updatePersonaBL(clsPersona persona)
        {

            int fieldCount;

            try
            {
                fieldCount = new clsHandlerPersonaDAL().updatePersonaDAL(persona);
            }
            catch (Exception e)
            {
                throw e;
            }

            return fieldCount;
        }

        /// <summary>
        /// Funcion de la capa BL, la cual usa la capa DAL para acceder a la BD azure y insertar los datos de una nueva persona,
        /// los cuales seran recibidos en un objeto clsPersona recibido por parametros
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int createPersonaBL(clsPersona persona)
        {

            int fieldCount;

            try
            {
                fieldCount = new clsHandlerPersonaDAL().createPersonaDAL(persona);
            }
            catch (Exception e)
            {
                throw e;
            }


            return fieldCount;
        }

    }
}