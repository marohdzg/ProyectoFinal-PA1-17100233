using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models
{
    [Table("DiseñoCarritos")]
    public class DiseñoCarrito : IEquatable<DiseñoCarrito>
    {
        [Key]
        public int DiseñoCarritoID { get; set; }

        [Display(Name = "# Diseño")]
        [ForeignKey("DiseñoID")]
        public Diseño diseño { get; set; }

        public int DiseñoID { get; set; }

        public int Cantidad { get; set; } = 1;

        public decimal PrecioUnitario { get; set; } = 0;

        public decimal SubTotal { get; set; } = 0;

        public void CalcularSubtotal()
        {
            SubTotal = Cantidad * diseño.PrecioUnitario;
        }

        public bool Equals(DiseñoCarrito other)
        {
            return DiseñoID.Equals(other.DiseñoID);
        }
    }
}