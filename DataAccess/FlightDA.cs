using Microsoft.EntityFrameworkCore.Storage;
using PruebaIngresoNewShore.Shared.Entities;
using PruebaIngresoShore.DataAccess;
using System;

namespace PreuebaIngresoNewShore.DataAccess
{
    /// <summary>
    /// Clase de Acceso a datos de la entidad Flight
    /// </summary>
    public class FlightDA
    {
        private readonly ApplicationDbContext appDbContext;

        /// <summary>
        /// Constrictor de la clase
        /// </summary>
        /// <param name="dbContext">contexto de la base de datos que recibe por inyección de dependencias</param>
        public FlightDA(ApplicationDbContext dbContext)
        {
            appDbContext = dbContext;
        }

        /// <summary>
        /// Inserta la entidad Flight en la Base de datos, si la entidad Flight contiene un objeto Transport este ultimo tambien sera insertado y se le asignara la llave foranea del 
        /// Transport en la entidad Flight
        /// </summary>
        /// <param name="flight">objeto que se va a insertar</param>
        /// <returns>Retorna True si se inserta correctamente o false en caso contrario </returns>
        public bool InsertFligth(Flight flight)
        {
            try
            {
                using IDbContextTransaction appDbContextTransaction = appDbContext.Database.BeginTransaction();
                try
                {
                    appDbContext.Flight.Add(flight);
                    appDbContext.SaveChanges();
                    appDbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    appDbContextTransaction.Rollback();
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
