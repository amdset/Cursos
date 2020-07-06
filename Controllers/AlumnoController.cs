using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{
    public class AlumnoController : Controller
    {

public IActionResult Index(){
    return View(
        new Alumno{Nombre="Misael JG.",
                       UniqueId = Guid.NewGuid().ToString()});
}

        public IActionResult MultiAlumno()
        {
            var listaAlumnos = GenerarAlumnosAlAzar(100);
            // ViewBag.Datox = "La monja";
            ViewBag.Fecha = DateTime.Now;
            return View("MultiAlumno",listaAlumnos);
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

    }
}