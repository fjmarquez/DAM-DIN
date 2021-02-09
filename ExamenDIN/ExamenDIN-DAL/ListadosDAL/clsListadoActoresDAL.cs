
using ExamenDIN_DAL.Connection;
using ExamenDIN_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDIN_DAL.ListadosDAL
{
    public class clsListadoActoresDAL
    {


        /// <summary>
        /// Esta funcion de la capa DAL accedera a la BD y nos devolvera un listado de objetos clsActor con todos los actores que 
        /// haya en la tabla Actores
        /// </summary>
        /// <returns></returns>
        public List<clsActor> getListadoActoresDAL()
        {
            clsConnection con = new clsConnection();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;
            clsActor actor = new clsActor();
            List<clsActor> listActores = new List<clsActor>();

            try
            {

                SqlConnection sqlc = con.getConnection();
                query.CommandText = "SELECT id, nombre from Actores";
                query.Connection = sqlc;
                reader = query.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        actor = new clsActor();

                        actor.Id = (int)reader["id"];
                        actor.Nombre = (string)reader["nombre"];

                        listActores.Add(actor);

                    }

                }

                reader.Close();
                con.closeConnection(ref sqlc);

            }
            catch (SqlException e)
            {

                throw e;

            }

            return listActores;
        }


        public clsActor getActorRamdomDAL(int id)
        {
            clsConnection con = new clsConnection();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;
            clsActor actor = new clsActor();

            try
            {

                SqlConnection sqlc = con.getConnection();
                query.CommandText = "SELECT id, nombre from Actores WHERE id="+id;
                query.Connection = sqlc;
                reader = query.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        actor = new clsActor();

                        actor.Id = (int)reader["id"];
                        actor.Nombre = (string)reader["nombre"];


                    }

                }

                reader.Close();
                con.closeConnection(ref sqlc);

            }
            catch (SqlException e)
            {

                throw e;

            }

            return actor;
        }

    }

}
