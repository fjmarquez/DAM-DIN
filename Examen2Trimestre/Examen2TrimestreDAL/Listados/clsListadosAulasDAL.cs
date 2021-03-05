using Examen2TrimestreDAL.Connection;
using Examen2TrimestreEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2TrimestreDAL.Listados
{
    public class clsListadosAulasDAL
    {
        /// <summary>
        /// Funcion de la capa DAL que obtiene un listado de aulas
        /// </summary>
        /// <returns></returns>
        public List<aula> getListadoAulas()
        {

            clsConnection con = new clsConnection();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;
            List<aula> list = new List<aula>();
            aula aula;
            //SELECT id, nombre FROM aulas
            try
            {
                SqlConnection sqlc = con.getConnection();
                query.CommandText = "SELECT id, nombre FROM aulas";
                query.Connection = sqlc;
                reader = query.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        aula = new aula();

                        aula.Id = (int)reader["id"];
                        aula.Nombre = (string)reader["nombre"];

                        list.Add(aula);

                    }

                }

                reader.Close();
                con.closeConnection(ref sqlc);

            }
            catch(Exception e)
            {

                list = null;

            }

            return list;

        }

    }
}
