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
        public IActionResult MultiAsignatura()        {
             
           
            ViewBag.Fecha=DateTime.Now;
            return View("MultiAsignatura",_context.Asignaturas);
        }

         public IActionResult Index()
        {
                 
           
            return View(_context.Asignaturas.FirstOrDefault());
        }

        private EscuelaContext _context;

        public AsignaturaController(EscuelaContext context)
    {

            _context=context;
    }
    }
}