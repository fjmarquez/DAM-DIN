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
    public class clsListadoPersonasDAL
    {
        /// <summary>
        /// Funcion de la capa DAL que obtendra de la API un listado de clsPersona.
        /// </summary>
        /// <returns></returns>
        public async Task<List<clsPersona>> getListadoPersonasDAL()
        {
            String uriAPI = new clsConnectionDAL().getUriAPI();
            Uri miUri = new Uri($"{ uriAPI }/personas");
            List<clsPersona> listado = new List<clsPersona>();
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
                    listado = JsonConvert.DeserializeObject<List<clsPersona>>(jsonRespuesta);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return listado;
        }

        /// <summary>
        /// Funcion de la capa DAL que obtendra de la API que obtendra un objeto clsPersona cuyo id coincida con
        /// el recibido.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<clsPersona> getPersonaPorIDDAL(int id)
        {
            String uriAPI = new clsConnectionDAL().getUriAPI();
            Uri miUri = new Uri($"{ uriAPI }/personas/{id}");
            clsPersona persona = new clsPersona();
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
                    persona = JsonConvert.DeserializeObject<clsPersona>(jsonRespuesta);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return persona;
        }

    }
}
