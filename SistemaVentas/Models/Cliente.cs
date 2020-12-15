using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public int ClienteID { get; set; }

        [MaxLength(70, ErrorMessage = "El nombre puede contener máximo 70 caracteres.")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Captura el nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Capture el teléfono")]
        [Display(Name = "Teléfono")]
        [Phone]
        [Column(TypeName = "varchar")]
        [MaxLength(14, ErrorMessage = "El teléfono puede contener máximo 14 dígitos")]
        public string Telefono { get; set; }

        [EmailAddress]
        [MaxLength(250, ErrorMessage = "El correo electrónico puede contener máximo 250 caracteres")]
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }
    }
}