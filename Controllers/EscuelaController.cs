using System;
using System.Linq;
using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{
    public class EscuelaController : Controller
    {
        private EscuelaContext _context;
        public EscuelaController(EscuelaContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Datox = "La monja";
            var escuela = _context.Escuelas.FirstOrDefault();
            return View(escuela);
        }        
    }
}