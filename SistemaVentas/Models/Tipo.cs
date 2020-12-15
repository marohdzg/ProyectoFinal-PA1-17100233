using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Maro.Models
{
    [Table("Tipos")]
    public class Tipo
    {
        [Display(Name = "# Tipo")]
        public int TipoID { get; set; }

        [Required(ErrorMessage = "Capture el nombre del tipo de diseño.")]
        [MaxLength(30, ErrorMessage = "Sólo puede medir 30 caracteres de largo.")]
        [Display(Name = "Tipo")]
        [Column(TypeName = "varchar")]
        public string NombreTipo { get; set; }
    }
}