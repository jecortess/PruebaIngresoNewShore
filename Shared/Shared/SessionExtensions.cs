using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace PruebaIngresoNewShore.Shared
{
    /// <summary>
    /// Clase que permite almacenar y obtener objetos complejos en la variable de sesión
    /// </summary>
    public static class SessionExtensions
    {
        /// <summary>
        /// Serializa Objeto de entrada aun string con formato Json
        /// </summary>
        /// <typeparam name="T"> tipo de objeto que se va a serializar</typeparam>
        /// <param name="session">Interfas Session</param>
        /// <param name="key">Identificador del valor que se va a almacenar</param>
        /// <param name="value">valor que se va a almacenar</param>
        public static void Set<T>(this ISession session, string key, T value)
        {
            string stringValue = JsonSerializer.Serialize(value);
            session.SetString(key, stringValue);
        }

        /// <summary>
        /// Deserializar el string de entrada al Objeto recibido en el tipo de parámetro T
        /// </summary>
        /// <typeparam name="T">Tipo de objeto al que se desea Deserializar</typeparam>
        /// <param name="session">Interfas Session</param>
        /// <param name="key">Identificador del valor que se va a almacenar</param>
        /// <returns>Objeto complejo que se genero al Deserializar</returns>
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
