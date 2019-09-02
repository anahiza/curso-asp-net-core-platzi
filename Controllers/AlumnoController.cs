using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.Models;

namespace ASP.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult MultiAlumno()
        {
            
           
            ViewBag.Fecha=DateTime.Now;
            return View(_context.Alumnos);
        }

         public IActionResult Index()
        {
                 
           
            return View(_context.Alumnos.FirstOrDefault());
        }

        
        private EscuelaContext _context;

        public AlumnoController(EscuelaContext context)
    {

            _context=context;
    }
    }
}