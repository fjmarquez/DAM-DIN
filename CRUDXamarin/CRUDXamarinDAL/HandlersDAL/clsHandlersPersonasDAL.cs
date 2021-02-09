using CRUDXamarinDAL.Connection;
using CRUDXamarinEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CRUDXamarinDAL.HandlersDAL
{
    public class clsHandlersPersonasDAL
    {
        /// <summary>
        /// Funcion de la capa DAL que eliminara mediante la API a la persona cuyo id coincida con el recibido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> borrarPersonaDAL(int id)
        {

            HttpClient miHttpClient = new HttpClient();
            String uriAPI = new clsConnectionDAL().getUriAPI();
            Uri miUri = new Uri($"{uriAPI}/personas/{id}");

            HttpResponseMessage miRespuesta = new HttpResponseMessage();

            try
            {
                miRespuesta = await miHttpClient.DeleteAsync(miUri);
            }
            catch (Exception e)
            {
                throw e;
            }
            return miRespuesta.StatusCode;
        }

        /// <summary>
        /// Funcion de la capa DAL que actualizara mediante la API a la persona cuyo id coincida con el
        /// de la persona recibida
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> actualizarPersonaDAL(clsPersona persona)
        {

            HttpClient miHttpClient = new HttpClient();
            String datos;
            HttpContent contenido;
            String uriAPI = new clsConnectionDAL().getUriAPI();
            Uri miUri = new Uri($"{uriAPI}/personas/{persona.Id}");

            HttpResponseMessage miRespuesta = new HttpResponseMessage();

            try
            {
                datos = JsonConvert.SerializeObject(persona);

                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");

                miRespuesta = await miHttpClient.PutAsync(miUri, contenido);
            }
            catch (Exception e)
            {
                throw e;
            }
            return miRespuesta.StatusCode;

        }

        /// <summary>
        /// Funcion de la capa que insertara mediante la API a la nueva persona recibida
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> insertarPersonaDAL(clsPersona persona)
        {

            HttpClient miHttpClient = new HttpClient();
            String datos;
            HttpContent contenido;
            String uriAPI = new clsConnectionDAL().getUriAPI();
            Uri miUri = new Uri($"{uriAPI}/personas");

            HttpResponseMessage miRespuesta = new HttpResponseMessage();

            try
            {
                datos = JsonConvert.SerializeObject(persona);

                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");

                miRespuesta = await miHttpClient.PostAsync(miUri, contenido);
            }
            catch (Exception e)
            {
                throw e;
            }
            return miRespuesta.StatusCode;

        }

    }
}
