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
          [Route("Alumno/Index")]
        [Route("Alumno/Index/{id}")]
 public IActionResult Index(string id)
        {        
            if(!string.IsNullOrWhiteSpace(id))  
            {
                var alumno = from al in _context.Alumnos
                                where al.Id == id
                                select al;
                return View(alumno.FirstOrDefault());

            }     
            else{
                return View("MultiAlumno",_context.Alumnos);
            }
        }
        public IActionResult MultiAlumno()
        {
            
           
            ViewBag.Fecha=DateTime.Now;
            return View(_context.Alumnos);
        }


        
        private EscuelaContext _context;

        public AlumnoController(EscuelaContext context)
    {

            _context=context;
    }
    }
}