using System;
using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.UniqueId = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi school";
            escuela.Ciudad="Guadalajara";
            escuela.Pais="México";
            escuela.Dirección="calle 3 hull";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            ViewBag.Datox = "La monja";

            return View(escuela);
        }
    }
}