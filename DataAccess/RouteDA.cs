using Microsoft.EntityFrameworkCore.Storage;
using PruebaIngresoNewShore.Shared.Entities;
using PruebaIngresoShore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PreuebaIngresoNewShore.DataAccess
{
    /// <summary>
    /// Clase de Acceso a datos de la entidad Route
    /// </summary>
    public class RouteDA
    {
        private readonly ApplicationDbContext appDbContext;

        /// <summary>
        /// Constrictor de la clase
        /// </summary>
        /// <param name="dbContext">contexto de la base de datos que recibe por inyección de dependencias</param>
        public RouteDA(ApplicationDbContext dbContext)
        {
            appDbContext = dbContext;
        }

        /// <summary>
        /// Obtiene todos los datos de la tabla Route ordenando por el campo IATACode
        /// </summary>
        /// <returns>Listado de Route </returns>
        public List<Route> GetListRoutes()
        {
            try
            {
                return appDbContext.Route.OrderBy(p => p.IATACode).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
