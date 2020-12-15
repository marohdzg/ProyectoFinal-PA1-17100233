using Maro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models
{
    [Table("Diseños")]
    public class Diseño
    {
        [Display(Name = "# Diseño")]
        public int DiseñoID { get; set; }

        [ForeignKey("TipoID")]
        [Display(Name = "# Tipo")]
        public Tipo TipoDiseno { get; set; }

        [Required(ErrorMessage = "Seleccione la categoría del diseño.")]
        [Display(Name = "# Tipo")]
        public int TipoID { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(300, ErrorMessage = "La discripción puede contener hasta 300 caracteres.")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Capture la descripción del diseño.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Capture el precio del diseño.")]
        [Display(Name = "Precio unitario")]
        [Column(TypeName = "money")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor o igual a $0.0")]
        public decimal PrecioUnitario { get; set; }

        [Display(Name = "Imagen")]
        public byte[] Imagen { get; set; }
    }
}