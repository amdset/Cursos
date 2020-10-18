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
        public IActionResult Index()
        {
            return View(_context.Asignaturas.FirstOrDefault());
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