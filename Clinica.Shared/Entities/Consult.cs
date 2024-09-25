using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Shared.Entities
{
    public class Consult
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Nombre del paciente")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Nombre del doctor")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string DoctorsName { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Fecha")]
        public string ConsultDate { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Sintomas")]
        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Symptoms { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Diagnostico")]
        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Diagnosis { get; set; } = null!;
        public ICollection<Diagnosis>? Diagnoses { get; set; }
    }
}
