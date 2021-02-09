using _11CRUDUWP_DAL.Listados;
using _11CRUDUWP_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11CRUDUWP_BL.Listados
{
    public class clsListadoPersonasBL
    {
        /// <summary>
        ///Funcion de la capa BL, la cual accede a la informacion de la BD Azure mediante la capa DAL y obtiene un listado de todas las personas
        /// que tenemos en nuestra BD
        /// </summary>
        /// <returns></returns>
        public List<clsPersona> getListadoPersonas()
        {

            List<clsPersona> list;

            try
            {
                list = new clsListadoPersonasDAL().getListadoPersonas();
            }
            catch(Exception e)
            {
                throw e;
            }

            return list;
        }

        /// <summary>
        ///Funcion de la capa BL, la cual accede a la informacion de la BD Azure mediante la capa DAL y obtiene un listado de todas las personas
        /// que tenemos en nuestra BD filtrado por nombre y apellidos
        /// </summary>
        /// <returns></returns>
        public List<clsPersona> getListadoPersonasFiltradasPorNombreYApellidos(string toFilter)
        {

            List<clsPersona> list;

            try
            {
                list = new clsListadoPersonasDAL().getListadoPersonasFiltradasPorNombreYApellidos(toFilter);
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }

        /// <summary>
        /// Funcion de la capa BL, la cual accede a la informacion de la BD Azure mediante la capa DAL y obtiene el numero de personas que forman un departamento
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public int getPersonasPorDepartamento(int idDepartamento)
        {
            int fieldCount;

            try
            {
                fieldCount = new clsListadoPersonasDAL().getPersonasPorDepartamento(idDepartamento);
            }catch(Exception e)
            {
                throw e;
            }

            return fieldCount;

        }

        /// <summary>
        /// Funcion de la capa BL, la cual accede a la informacion de la BD Azure mediante la capa DAL y obtiene una persona cuyo id coincida con el recibido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersona getPersonaPorID(int id)
        {

            clsPersona persona;

            try
            {
                persona = new clsListadoPersonasDAL().getPersonaPorID(id);
            }
            catch (Exception e)
            {
                throw e;
            }


            return persona;
        }

    }
}
