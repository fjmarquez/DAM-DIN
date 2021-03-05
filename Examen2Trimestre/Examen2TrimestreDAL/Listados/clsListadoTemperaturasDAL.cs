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
    public class clsListadoTemperaturasDAL
    {
        /// <summary>
        /// Funcion de la capa DAL que obtiene un listado de temperaturas segun el id de aula recibido por parametros
        /// </summary>
        /// <param name="idAula"></param>
        /// <returns></returns>
        public List<temperaturas> getTemperaturasPorAula(int idAula)
        {

            clsConnection con = new clsConnection();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;
            List<temperaturas> list = new List<temperaturas>();
            temperaturas temperaturas;
            //SELECT idAula, fecha, temp1, temp2, temp3 FROM temperaturas WHERE idAula = @idAula
            try
            {
                SqlConnection sqlc = con.getConnection();
                query.CommandText = "SELECT idAula, fecha, temp1, temp2, temp3 FROM temperaturas WHERE idAula = @idAula";
                query.Parameters.AddWithValue("idAula", idAula);
                query.Connection = sqlc;
                reader = query.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        temperaturas = new temperaturas();


                        temperaturas.IdAula = (int)reader["idAula"];
                        temperaturas.Fecha = (DateTime)reader["fecha"];
                        temperaturas.Temp1 = (Double)reader["temp1"];
                        temperaturas.Temp2 = (Double)reader["temp2"];
                        temperaturas.Temp3 = (Double)reader["temp3"];

                        list.Add(temperaturas);

                    }

                }

                reader.Close();
                con.closeConnection(ref sqlc);

            }
            catch (Exception e)
            {

                temperaturas = null;

            }

            return list;

        }

    }
}
