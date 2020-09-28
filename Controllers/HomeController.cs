using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PreuebaIngresoNewShore.DataAccess;
using PruebaIngresoNewShore.Models;
using PruebaIngresoNewShore.Service;
using PruebaIngresoNewShore.Shared.Entities;
using PruebaIngresoNewShore.Shared;
using Microsoft.AspNetCore.Http;

namespace PruebaIngresoNewShore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> oLogger;
        private readonly RouteDA oRouteDA;
        private readonly FlightDA oFlightDA;
        private readonly ConsumeAPI oConsumeAPI;
        private readonly IConfiguration oIConfiguration;

        public HomeController(ILogger<HomeController> logger, RouteDA routeDA, FlightDA flightDA, ConsumeAPI consumeAPI, IConfiguration configuration)
        {
            oLogger = logger;
            oRouteDA = routeDA;
            oFlightDA = flightDA;
            oConsumeAPI = consumeAPI;
            oIConfiguration = configuration;
        }

        public IActionResult Index()
        {
            SearchFlightModel model = new SearchFlightModel();
            model.RoutesList = GetListRoutes();
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(SearchFlightModel model)
        {
            model.RoutesList = GetListRoutes();
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Origin == model.Destination)
                    {
                        model.VerError = true;
                        model.MensajeError = "El destino el igual al origen, por favor seleccione un destino diferente.";
                        return View(model);
                    }

                    model.FlightsList = oConsumeAPI.GetFlights(GetValuerModel(model));
                    HttpContext.Session.Set<SearchFlightModel>("Model", model);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                model.VerError = true;
                model.MensajeError = "Se presentó un error, por favor comuníquese con el administrador del sistema.";
                oLogger.LogError(ex, "Error al consultar los vuelos disponibles.");
                return View(model);
            }
        }

        public IActionResult Insert(int idFligth)
        {
            SearchFlightModel model = HttpContext.Session.Get<SearchFlightModel>("Model");
            try
            {
                Flight flight = model.FlightsList.Where(p => p.PK_IdFligth == idFligth).FirstOrDefault();
                flight.PK_IdFligth = 0;
                if (oFlightDA.InsertFligth(flight))
                {
                    model.TipoError = "alert alert-success alert-dismissible fade show";
                    model.VerError = true;
                    model.MensajeError = "El registro se insertó correctamente.";
                    HttpContext.Session.Set("Model", model);
                }
                else
                {
                    model.TipoError = "alert alert-warning alert-dismissible fade show";
                    model.VerError = true;
                    model.MensajeError = "Ocurrió un error al insertar el registro, por favor intente nuevamente.";
                }

                return View("Index", model);
            }
            catch (Exception ex)
            {
                model.VerError = true;
                model.MensajeError = $"Se presentó un error, por favor comuníquese con el administrador del sistema.";
                oLogger.LogError(ex, "Error al insertar el registro");
                return View("Index", model);
            }
        }

        private List<SelectListItem> GetListRoutes()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem> { new SelectListItem { Text = "Seleccionar", Value = string.Empty } };
            try
            {
                List<Route> listRoute = oRouteDA.GetListRoutes();
                listRoute.ForEach(p =>
                {
                    selectListItems.Add(new SelectListItem { Text = $"{p.IATACode} - {p.Description}", Value = p.IATACode });
                });
                return selectListItems;
            }
            catch (Exception ex)
            {
                oLogger.LogError(ex, "Error al cargar la lista de Route");
                return selectListItems;
            }
        }

        private Dictionary<string, string> GetValuerModel(SearchFlightModel model)
        {
            try
            {
                Dictionary<string, string> ValuesAPI = new Dictionary<string, string>();
                foreach (string item in oIConfiguration["ValuesAPI"].Split(','))
                {
                    PropertyInfo propertyInfo = model.GetType().GetProperty(item);
                    ValuesAPI.Add(item, (string)propertyInfo.GetValue(model));
                }
                return ValuesAPI;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
