﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Shared.Entities
{
    public class Agenda
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Nombre Completo")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Fecha")]
        public DateTime ConsultDate { get; set; } 
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Hora")]
        public int ConsultHour { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Fecha")]
        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Symptoms { get; set; } = null!;
        public Patient? Patient { get; set; }
    }
}
