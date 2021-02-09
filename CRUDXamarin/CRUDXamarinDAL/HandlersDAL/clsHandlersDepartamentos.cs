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
    public class clsHandlersDepartamentosDAL
    {

        /// <summary>
        /// Funcion de la capa DAL que eliminara mediante la API el departamento cuyo id coincida con el recibido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> borrarDepartamentoDAL(int id)
        {

            HttpClient miHttpClient = new HttpClient();
            String uriAPI = new clsConnectionDAL().getUriAPI();
            Uri miUri = new Uri($"{uriAPI}/departamentos/{id}");

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
        /// Funcion de la capa DAL que actualizara mediante la API el departamento cuyo id coincida con el
        /// del departamento recibido.
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> actualizarDepartamentoDAL(clsDepartamento departamento)
        {

            HttpClient miHttpClient = new HttpClient();
            String datos;
            HttpContent contenido;
            String uriAPI = new clsConnectionDAL().getUriAPI();
            Uri miUri = new Uri($"{uriAPI}/personas/{departamento.Id}");

            HttpResponseMessage miRespuesta = new HttpResponseMessage();

            try
            {
                datos = JsonConvert.SerializeObject(departamento);

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
        /// Funcion de la capa que insertara mediante la API el nuevo departamento recibido
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> insertarDepartamentoDAL(clsDepartamento departamento)
        {

            HttpClient miHttpClient = new HttpClient();
            String datos;
            HttpContent contenido;
            String uriAPI = new clsConnectionDAL().getUriAPI();
            Uri miUri = new Uri($"{uriAPI}/departamentos");

            HttpResponseMessage miRespuesta = new HttpResponseMessage();

            try
            {
                datos = JsonConvert.SerializeObject(departamento);

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
