using CRUDXamarinDAL.HandlersDAL;
using CRUDXamarinEntities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRUDXamarinBL.HandlersBL
{
    public class clsHandlersPersonasBL
    {

        /// <summary>
        /// Funcion de la capa BL que accedera a la API mediante la capa DAL y eliminara la persona
        /// cuyo id coincida con el recibido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> borrarPersonaBL(int id)
        {
            HttpStatusCode statusCode;

            try
            {
                statusCode = await new clsHandlersPersonasDAL().borrarPersonaDAL(id);
            }
            catch (Exception e)
            {
                throw e;
            }

            return statusCode;
        }

        /// <summary>
        /// Funcion de la capa BL que accedera a la API mediante la capa DAL y actualizara la persona cuyo id 
        /// coincida con el de la persona recibida
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> actualizarPersonaBL(clsPersona persona)
        {
            HttpStatusCode statusCode;

            try
            {
                statusCode = await new clsHandlersPersonasDAL().actualizarPersonaDAL(persona);
            }
            catch (Exception e)
            {
                throw e;
            }
            return statusCode;
        }

        /// <summary>
        /// Funcion de la capa BL que accedera a la API mediante la capa DAL e insertara la persona recibida
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> insertarPersonaBL(clsPersona persona)
        {
            HttpStatusCode statusCode;

            try
            {
                statusCode = await new clsHandlersPersonasDAL().insertarPersonaDAL(persona);
            }
            catch (Exception e)
            {
                throw e;
            }
            return statusCode;
        }

    }
}
