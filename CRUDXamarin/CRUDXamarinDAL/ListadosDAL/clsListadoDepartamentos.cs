using CRUDXamarinDAL.Connection;
using CRUDXamarinEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CRUDXamarinDAL.ListadosDAL
{
    public class clsListadoDepartamentosDAL
    {

        /// <summary>
        /// Funcion de la capa DAL que obtendra de la API un listado de todos los departamento existentes.
        /// </summary>
        /// <returns></returns>
        public async Task<List<clsDepartamento>> getListadoDepartamentosDAL()
        {
            String uriAPI = new clsConnectionDAL().getUriAPI();
            Uri miUri = new Uri($"{ uriAPI }/departamentos");
            List<clsDepartamento> listado = new List<clsDepartamento>();
            HttpClient miHttpClient;
            HttpResponseMessage miCodigoRespuesta;
            String jsonRespuesta;

            //Instanciamos el cliente HTTP
            miHttpClient = new HttpClient();

            try
            {
                miCodigoRespuesta = await miHttpClient.GetAsync(miUri);

                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    jsonRespuesta = await miHttpClient.GetStringAsync(miUri);
                    miHttpClient.Dispose();
                    listado = JsonConvert.DeserializeObject<List<clsDepartamento>>(jsonRespuesta);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return listado;
        }

        /// <summary>
        /// Funcion de la capa DAL que obtendra de la API que obtendra un objeto clsDepartamento cuyo id coincida con
        /// el recibido.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<clsDepartamento> getDepartamentoPorIDDAL(int id)
        {
            String uriAPI = new clsConnectionDAL().getUriAPI();
            Uri miUri = new Uri($"{ uriAPI }/departamentos/{id}");
            clsDepartamento departamento = new clsDepartamento();
            HttpClient miHttpClient;
            HttpResponseMessage miCodigoRespuesta;
            String jsonRespuesta;

            //Instanciamos el cliente HTTP
            miHttpClient = new HttpClient();

            try
            {
                miCodigoRespuesta = await miHttpClient.GetAsync(miUri);

                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    jsonRespuesta = await miHttpClient.GetStringAsync(miUri);
                    miHttpClient.Dispose();
                    departamento = JsonConvert.DeserializeObject<clsDepartamento>(jsonRespuesta);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return departamento;
        }

    }
}
