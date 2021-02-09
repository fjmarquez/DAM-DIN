using ExamenDIN_DAL.ListadosDAL;
using ExamenDIN_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDIN_BL.ListadosBL
{
    public class clsListadoActoresBL
    {
        /// <summary>
        /// Esta funcion de la capa BL accedera a la BD mediante la capa DAL y devolvera al VM un listado de objetos clsActor
        /// </summary>
        /// <returns></returns>
        public List<clsActor> getListadoActoresBL()
        {
            List<clsActor> listActores = new clsListadoActoresDAL().getListadoActoresDAL();

            return listActores;

        }


        public clsActor getActorRamdom(int id)
        {
            clsActor actorRamdom = new clsListadoActoresDAL().getActorRamdomDAL(id);

            return actorRamdom;
        }

    }
}
