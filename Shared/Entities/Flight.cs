using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaIngresoNewShore.Shared.Entities
{
    /// <summary>
    /// Entidad que representa la tabla Flight
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// Propiedad que representa el campo PK_IdFligth de la tabla Flight
        /// </summary>
        [Key]
        public int PK_IdFligth { get; set; }
        /// <summary>
        /// Propiedad que representa el campo PK_IdFligth de la tabla Flight
        /// </summary>
        public int FK_IdTransport { get; set; }

        /// <summary>
        /// Propiedad que representa el campo PK_IdFligth de la tabla Flight
        /// </summary>
        public string DepartureStation { get; set; }

        /// <summary>
        /// Propiedad que representa el campo PK_IdFligth de la tabla Flight
        /// </summary>
        public string ArrivalStation { get; set; }

        /// <summary>
        /// Propiedad que representa el campo PK_IdFligth de la tabla Flight
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Propiedad que representa el campo PK_IdFligth de la tabla Flight
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Propiedad que representa el campo PK_IdFligth de la tabla Flight
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Propiedad que representa la tabla Transport que tiene una llave foránea hacia la tabla Flight
        /// </summary>
        [ForeignKey("FK_IdTransport")]
        public virtual Transport Transport { get; set; }
        /// <summary>
        /// Propiedad que representa el campo FlightNumber de la tabla Transport la cual no esta mapeada en la tabla Flight
        /// </summary>
        [NotMapped]
        public string FlightNumber { get; set; }

    }
}
