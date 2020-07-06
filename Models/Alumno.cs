using System;
using System.Collections.Generic;
namespace AspNetCore.Models
{
    public class Alumno: ObjetoEscuelaBase
    {
        public List<Evaluación> Evaluaciones { get; set; } = new List<Evaluación>();
    }
}