using System;
using System.Linq;
using System.Collections.Generic;
using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{
    public class AsignaturaController : Controller
    {
        private EscuelaContext _context;

        public AsignaturaController(EscuelaContext context)
        {
            this._context = context;
        }

        //public IActionResult Index(string id)
        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{asignaturaId}/{apiKey}")]
        public IActionResult Index(string asignaturaId, string apiKey)
        {
            var asignatura = string.IsNullOrEmpty(asignaturaId)
                ? _context.Asignaturas.FirstOrDefault()
                : _context.Asignaturas.FirstOrDefault(a => a.Id.Equals(asignaturaId));
            return View(asignatura);
        }

        public IActionResult MultiAsignatura()
        {
            var listaAsignaturas = _context.Asignaturas;
            ViewBag.Datox = "La monja";
            ViewBag.Fecha = DateTime.Now;
            return View("MultiAsignatura", listaAsignaturas);
        }
    }
}