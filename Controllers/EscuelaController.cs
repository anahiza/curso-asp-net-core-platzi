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
            escuela.AñoDeCreación=2005;
            escuela.UniqueId = Guid.NewGuid().ToString();
            escuela.Ciudad="Bogotá";
            escuela.Pais="Colombia";
            escuela.Dirección="Av. 232 #32";
            escuela.TipoEscuela=TiposEscuela.Secundaria;

            escuela.Nombre =  "Platzi";
            ViewBag.DatoDinamico="dato dinamico";
            return View(escuela);
        }
    }
}
