using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PruebaIngresoNewShore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace PruebaIngresoNewShore.Service
{
    /// <summary>
    /// Clase que se utiliza para consumir una API
    /// </summary>
    public class ConsumeAPI
    {
        private IConfiguration oIConfiguration { get; }

        /// <summary>
        /// Consdtructor de la clase
        /// </summary>
        /// <param name="configuration">Objeto que permite acceder a las variables que estan en el aerchivo de configuracion (appsettings.json)</param>
        public ConsumeAPI(IConfiguration configuration)
        {
            oIConfiguration = configuration;
        }

        /// <summary>
        /// Obtiene la respuesta de la API
        /// </summary>
        /// <param name="valuesAPI">Parametros de entrada y sus respectivos valores que se utilizaran para hacer el llamada de la API</param>
        /// <returns>Retorna la lista de Flight que retorno la API </returns>
        public List<Flight> GetFlights(Dictionary<string, string> valuesAPI)
        {
            try
            {
                var url = oIConfiguration["UrlAPI"];
                var request = (HttpWebRequest)WebRequest.Create(url);
                string data = GetValues(valuesAPI);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.ContentLength = data.Length;
                StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
                requestWriter.Write(data);
                requestWriter.Close();
                HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    return GetValueResponce(webResponse);
                }
                else
                {
                    throw new Exception(webResponse.StatusDescription);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Convierte la respuesta de la API en una lista de Flight
        /// </summary>
        /// <param name="webResponse">respuesta que retorno la API</param>
        /// <returns>Lista de objetos Flight</returns>
        private List<Flight> GetValueResponce(WebResponse webResponse)
        {
            try
            {
                List<Flight> flights = new List<Flight>();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();
                response = response.Replace("\\\"", "'");
                response = response.Replace("\"", "");
                flights = JsonConvert.DeserializeObject<List<Flight>>(response);
                flights.ForEach(p =>
                {
                    p.PK_IdFligth = flights.Max(x => x.PK_IdFligth) + 1;
                    p.Transport = new Transport { FlightNumber = p.FlightNumber };
                });
                responseReader.Close();
                return flights;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Combierte los datos de entrada de la API representados en un Dictionary aun string en formato Json
        /// </summary>
        /// <param name="valuesAPI">Parametros de entrada y sus respectivos valores que se utilizaran para hacer el llamada de la API</param>
        /// <returns>parametros de entrada de la API en formato Json</returns>
        private string GetValues(Dictionary<string, string> valuesAPI)
        {
            try
            {
                List<string> data = new List<string>();
                foreach (string item in oIConfiguration["ValuesAPI"].Split(','))
                {
                    data.Add($"\"{item}\":\"{valuesAPI[item]}\"");
                }
                return "{" + string.Join(",", data) + "}";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
