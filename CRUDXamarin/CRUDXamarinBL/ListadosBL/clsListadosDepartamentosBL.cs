using CRUDXamarinDAL.ListadosDAL;
using CRUDXamarinEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUDXamarinBL.ListadosBL
{
    public class clsListadosDepartamentosBL
    {

        /// <summary>
        /// Funcion de la capa BL que accedera a la API mediante la capa DAL y obtendra un listado de todos los
        /// departamentos
        /// </summary>
        /// <returns></returns>
        public async Task<List<clsDepartamento>> getListadoDepartamentosBL()
        {
            List<clsDepartamento> listado;

            try
            {
                listado = await new clsListadoDepartamentosDAL().getListadoDepartamentosDAL();
            }
            catch (Exception e)
            {
                throw e;
            }
            return listado;
        }

        /// <summary>
        /// Funcion de la capa BL que accedera a la API mediante la capa DAL y obtendra un objeto clsDepartamento 
        /// cuyo id coincida con el recibido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<clsDepartamento> getDepartamentoPorIDBL(int id)
        {
            clsDepartamento departamento;

            try
            {
                departamento = await new clsListadoDepartamentosDAL().getDepartamentoPorIDDAL(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return departamento;
        }

    }
}
