using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaIngresoNewShore.Shared.Entities;

namespace PruebaIngresoShore.DataAccess
{
    /// <summary>
    /// Clase que crea el contexto de la base de datos 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ApplicationDbContext()
        {
        }

        /// <summary>
        /// Constructor de la clase que recibe las opciones de conexión
        /// </summary>
        /// <param name="options">Opciones que se utilizaran para hacer la conexión con la base de datos</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Representa la tabla Transport
        /// </summary>
        public virtual DbSet<Transport> Transport { get; set; }

        /// <summary>
        /// Representa la tabla Flight
        /// </summary>
        public virtual DbSet<Flight> Flight { get; set; }

        /// <summary>
        /// Representa la tabla Route
        /// </summary>
        public virtual DbSet<Route> Route { get; set; }
    }
}
