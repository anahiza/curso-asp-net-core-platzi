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
            var escuela = new Escuela();
            escuela.añoFundacion=2005;
            escuela.EscuelaID = Guid.NewGuid().ToString();
            escuela.Nombre =  "Platzi";
            return View(escuela);
        }
    }
}
