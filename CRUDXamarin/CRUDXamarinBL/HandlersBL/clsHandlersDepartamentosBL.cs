using CRUDXamarinDAL.HandlersDAL;
using CRUDXamarinEntities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRUDXamarinBL.HandlersBL
{
    public class clsHandlersDepartamentosBL
    {

        /// <summary>
        /// Funcion de la capa BL que accedera a la API mediante la capa DAL y borrara el departamento cuyo id coincida
        /// con el recibido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> borrarDepartamentoBL(int id)
        {
            HttpStatusCode statusCode;

            try
            {
                statusCode = await new clsHandlersDepartamentosDAL().borrarDepartamentoDAL(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return statusCode;
        }

        /// <summary>
        /// Funcion de la capa BL que accedera a la API mediante la capa DAL y actualizara el departamento cuyo id
        /// coincida con el del departamento recibido
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> actualizarDepartamentoBL(clsDepartamento departamento)
        {
            HttpStatusCode statusCode;

            try
            {
                statusCode = await new clsHandlersDepartamentosDAL().actualizarDepartamentoDAL(departamento);
            }
            catch (Exception e)
            {
                throw e;
            }
            return statusCode;
        }

        /// <summary>
        /// Funcion de la capa BL que accedera a la API mediante la capa DAL y creara el departamento recibido
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> insertarDepartamentoBL(clsDepartamento departamento)
        {
            HttpStatusCode statusCode;

            try
            {
                statusCode = await new clsHandlersDepartamentosDAL().insertarDepartamentoDAL(departamento);
            }
            catch (Exception e)
            {
                throw e;
            }
            return statusCode;
        }

    }
}
