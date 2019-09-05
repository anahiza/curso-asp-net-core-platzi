using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.Models;

namespace ASP.Controllers
{
    public class CursoController : Controller
    {
/*           [Route("Curso/Index")]
        [Route("Curso/Index/{id}")]
            [Route("Curso/Create")]  */


 public IActionResult Index(string id)
        {        
            if(!string.IsNullOrWhiteSpace(id))  
            {
                var curso = from cu in _context.Cursos
                                where cu.Id == id
                                select cu;
                return View(curso.FirstOrDefault());

            }     
            else{
                return View("MultiCurso",_context.Cursos);
            }
        }


        public IActionResult MultiCurso()
        {
            
           
            ViewBag.Fecha=DateTime.Now;
            return View(_context.Cursos);
        }


        
        private EscuelaContext _context;

        public CursoController(EscuelaContext context)
    {

            _context=context;
    }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]

        public IActionResult Create(Curso curso)
        {
            if(ModelState.IsValid){
                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId=escuela.Id;
                curso.Id=Guid.NewGuid().ToString();
                _context.Cursos.Add(curso);
                _context.SaveChanges();
                return View("Index",curso);

            }
            else
            {
                return View(curso);
            }

        }

        public IActionResult Edit(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var curso = _context.Cursos.Find(id);
                return View(curso);
            }
            else
            {
                return View("MultiCurso");
            }


        }

        [HttpPost]

        public IActionResult Edit(Curso curso)
        {
            if(ModelState.IsValid){
                
                _context.Cursos.Update(curso);
                _context.SaveChanges();
                return RedirectToAction("MultiCurso",_context.Cursos.ToArray());

            }
            else
            {
                return View(curso);
            }

        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            if(!string.IsNullOrEmpty(id)){
                
               var curso= _context.Cursos.Find(id);
               _context.Cursos.Remove(curso);
                _context.SaveChanges();

            }
            
            return RedirectToAction("MultiCurso",_context.Cursos.ToArray());

        }



    }
}