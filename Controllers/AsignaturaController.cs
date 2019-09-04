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
        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{id}")]

         public IActionResult Index(string id)
        {        
            if(!string.IsNullOrWhiteSpace(id))  
            {
                var asignatura = from asig in _context.Asignaturas
                                where asig.Id == id
                                select asig;
                return View(asignatura.FirstOrDefault());

            }     
            else{
                return View("MultiAsignatura",_context.Asignaturas);
            }
        }
        public IActionResult MultiAsignatura()        {
             
           
            ViewBag.Fecha=DateTime.Now;
            return View("MultiAsignatura",_context.Asignaturas);
        }

        private EscuelaContext _context;

        public AsignaturaController(EscuelaContext context)
    {

            _context=context;
    }
    }
}