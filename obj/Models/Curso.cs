using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.Models
{
    public class Curso:ObjetoEscuelaBase
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }
        [Required]
        [Display(Prompt="Direccion correspondencia", Name="Address")]
        [MinLength(5)]
        public string Dirección { get; set; }
        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }
        
        [Required(ErrorMessage="El nombre es requerido")]
        [StringLength(5)]
        public override string Nombre { get; set; }

    }
}