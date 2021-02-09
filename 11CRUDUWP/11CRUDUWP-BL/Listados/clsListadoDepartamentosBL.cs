using _11CRUDUWP_DAL.Listados;
using _11CRUDUWP_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11CRUDUWP_BL.Listados
{
    public class clsListadoDepartamentosBL
    {

        /// <summary>
        /// Funcion de la capa BL, la cual accede a la informacion de la BD Azure mediante al capa DAL y obtiene un listado de todos los departamentos
        /// que hay en nuestra BD
        /// </summary>
        /// <returns></returns>
        public List<clsDepartamento> getListadoDepartamentos()
        {
            List<clsDepartamento> list;

            try
            {
                list = new clsListadoDepartamentosDAL().getListadoDepartamentos();
            }
            catch(Exception e)
            {
                throw e;
            }

            return list;
        }

        /// <summary>
        /// Funcion de la capa BL, la cual accede a la informacion de la BD Azure mediante la capa DAL y obtiene un listado de departamentos filtrados por nombre
        /// </summary>
        /// <param name="toFilter"></param>
        /// <returns></returns>
        public List<clsDepartamento> getListadoDepartamentosPorNombre (string toFilter)
        {
            List<clsDepartamento> list;

            try
            {
                list = new clsListadoDepartamentosDAL().getListadoDepartamentosPorNombre(toFilter);
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }




    }
}
