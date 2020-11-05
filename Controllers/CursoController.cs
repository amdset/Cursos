using System;
using System.Linq;
using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{
    public class CursoController : Controller
    {
        EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
            this._context = context;
        }

        [Route("Curso")]
        [Route("Curso/{id}")]
        [Route("Curso/Index")]
        [Route("Curso/Index/{id}")]
        public IActionResult Index(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("MultiCurso", _context.Cursos);
            }
            else
            {
                var curso = _context.Cursos.FirstOrDefault(c => c.Id == id);
                return View(curso);
            }
        }

        public IActionResult MultiCurso()
        {
            return View("MultiCurso", _context.Cursos);
        }

        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            ViewBag.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;

                _context.Cursos.Add(curso);
                _context.SaveChanges();
                ViewBag.MsgResult = "Curso creado";
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }
        }

        public IActionResult Update(String id){
            var CursoAEditar = _context.Cursos.FirstOrDefault(c=>c.Id == id);
            return View("Update",CursoAEditar);
        }

         [HttpPost]
        public IActionResult Update(Curso curso){
             if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;
                _context.Entry(curso).State = Microsoft.EntityFrameworkCore.EntityState.Modified;               
                _context.SaveChanges();
                ViewBag.MsgResult = "Curso Modificado";
                return View("Index", curso);
            }
            else
            {
                return View("Update",curso);
            }
        }

    }
}