using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.Models;

namespace ASP.Controllers
{
    public class EscuelaController : Controller
       {
        
        public IActionResult Index()
        {
            

            var escuela = _context.Escuelas.FirstOrDefault();
            ViewBag.DatoDinamico="dato dinamico";

            return View(escuela);
        }
        private EscuelaContext _context;

        public EscuelaController(EscuelaContext context)
    {

            _context=context;
    }
    }
}
