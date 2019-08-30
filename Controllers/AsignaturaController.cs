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
                            UniqueId=Guid.NewGuid().ToString()
                            } ,
                            new Asignatura{Nombre="Educación Física",UniqueId=Guid.NewGuid().ToString()},
                            new Asignatura{Nombre="Castellano",
                            UniqueId=Guid.NewGuid().ToString()},
                            new Asignatura{Nombre="Ciencias Naturales",
                            UniqueId=Guid.NewGuid().ToString()},
                            new Asignatura{Nombre="Programacion",
                            UniqueId=Guid.NewGuid().ToString()}
                };
           
            ViewBag.Fecha=DateTime.Now;
            return View("MultiAsignatura",listaAsignaturas);
        }

         public IActionResult Index()
        {
             var asignatura = new Asignatura{Nombre="Programacion", UniqueId=Guid.NewGuid().ToString()}   ;     
           
            return View(asignatura);
        }
    }
}