using _11CRUDUWP_DAL.Connection;
using _11CRUDUWP_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11CRUDUWP_DAL.Listados
{

        public class clsListadoDepartamentosDAL
        {

            /// <summary>
            ///  Funcion de la capa DAL, la cual accede directamente a la informacion de la BD Azure y obtiene un listado de departamentos 
            /// </summary>
            /// <returns></returns>
            public List<clsDepartamento> getListadoDepartamentos()
            {
                clsMyConnectionDAL con = new clsMyConnectionDAL();
                SqlCommand query = new SqlCommand();
                SqlDataReader reader;
                List<clsDepartamento> list = new List<clsDepartamento>();
                clsDepartamento departamento;

                try
                {
                    SqlConnection sqlc = con.getConnection();
                    query.CommandText = "SELECT ID, Nombre FROM Departamentos";
                    query.Connection = sqlc;
                    reader = query.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            departamento = new clsDepartamento();

                            departamento.Id = (int)reader["ID"];
                            departamento.Departamento = (string)reader["Nombre"];

                            list.Add(departamento);
                        }
                    }
                    reader.Close();
                    con.closeConnection(ref sqlc);
                }
                catch (SqlException e)
                {
                    throw e;
                }


                return list;
            }

        /// <summary>
        /// Funcion de la capa DAL, la cual accede directamente a la informacion de la BD Azure y obtiene un listado de departamentos filtrados por nombre
        /// </summary>
        /// <param name="toFilter"></param>
        /// <returns></returns>
        public List<clsDepartamento> getListadoDepartamentosPorNombre (string toFilter)
        {
            clsMyConnectionDAL con = new clsMyConnectionDAL();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;
            List<clsDepartamento> list = new List<clsDepartamento>();
            clsDepartamento departamento;

            try
            {
                SqlConnection sqlc = con.getConnection();
                query.CommandText = "SELECT ID, Nombre FROM Departamentos  WHERE Nombre LIKE '%" + toFilter + "%'";
                query.Connection = sqlc;
                reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        departamento = new clsDepartamento();

                        departamento.Id = (int)reader["ID"];
                        departamento.Departamento = (string)reader["Nombre"];

                        list.Add(departamento);
                    }
                }
                reader.Close();
                con.closeConnection(ref sqlc);
            }
            catch (SqlException e)
            {
                throw e;
            }


            return list;
        }




        }
    }
