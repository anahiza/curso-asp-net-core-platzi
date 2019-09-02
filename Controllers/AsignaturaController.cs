using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.Models;

namespace ASP.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult MultiAsignatura()
        {
             var listaAsignaturas = new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas",
                            Id=Guid.NewGuid().ToString()
                            } ,
                            new Asignatura{Nombre="Educación Física",Id=Guid.NewGuid().ToString()},
                            new Asignatura{Nombre="Castellano",
                            Id=Guid.NewGuid().ToString()},
                            new Asignatura{Nombre="Ciencias Naturales",
                            Id=Guid.NewGuid().ToString()},
                            new Asignatura{Nombre="Programacion",
                            Id=Guid.NewGuid().ToString()}
                };
           
            ViewBag.Fecha=DateTime.Now;
            return View("MultiAsignatura",listaAsignaturas);
        }

         public IActionResult Index()
        {
             var asignatura = new Asignatura{Nombre="Programacion", Id=Guid.NewGuid().ToString()}   ;     
           
            return View(asignatura);
        }
    }
}