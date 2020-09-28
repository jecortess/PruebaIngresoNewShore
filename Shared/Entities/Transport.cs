using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaIngresoNewShore.Shared.Entities
{
    /// <summary>
    /// Entidad que representa la tabla Transport
    /// </summary>
    public class Transport
    {
        /// <summary>
        /// Propiedad que representa el campo PK_IdTransport de la tabla Transport
        /// </summary>
        [Key]
        public int PK_IdTransport { get; set; }

        /// <summary>
        /// Propiedad que representa el campo FlightNumber de la tabla Transport
        /// </summary>
        public string FlightNumber { get; set; }        

    }
}
