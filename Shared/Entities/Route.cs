using System.ComponentModel.DataAnnotations;

namespace PruebaIngresoNewShore.Shared.Entities
{
    /// <summary>
    /// Entidad que representa la tabla Route
    /// </summary>
    public class Route
    {
        /// <summary>
        /// Propiedad que representa el campo IATACode de la tabla Route
        /// </summary>
        [Key]
        public string IATACode { get; set; }

        /// <summary>
        /// Propiedad que representa el campo Description de la tabla Route
        /// </summary>
        public string Description { get; set; }        

    }
}
