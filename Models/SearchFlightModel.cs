using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaIngresoNewShore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaIngresoNewShore.Models
{
    public class SearchFlightModel
    {
        public SearchFlightModel()
        {
            FlightsList = new List<Flight>();
            RoutesList = new List<SelectListItem>();
            TipoError = "alert alert-warning alert-dismissible fade show";
        }
        [Required(ErrorMessage = "El campo \"{0}\" es requerido.")]
        [Display(Name = "Origen")]
        public string Origin { get; set; }

        [Required(ErrorMessage = "El \"{0}\" es requerido.")]
        [Display(Name = "Destino")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "La \"{0}\" es requerido.")]
        [Display(Name = "Fecha")]
        public string From { get; set; }
        public List<SelectListItem> RoutesList { get; set; }

        public List<Flight> FlightsList { get; set; }
        public bool VerError { get; set; }
        public string MensajeError { get; set; }
        public string TipoError { get; set; }
        public int PK_IdFligth { get; set; }
    }
}
