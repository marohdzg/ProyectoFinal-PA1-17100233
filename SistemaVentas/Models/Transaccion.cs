using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models
{
    [Table("Transacciones")]
    public class Transaccion
    {
        [Key]
        [Column(Order = 0)]
        public int TransaccionID { get; set; }

        [Key]
        [ForeignKey("ClienteID")]
        [Display(Name = "Cliente")]
        [Column(Order = 1)]
        public Cliente Cliente { get; set; }
        public int ClienteID { get; set; }

        [Key]
        [ForeignKey("DiseñoID")]
        [Display(Name = "Descripción")]
        [Column(Order = 2)]
        public Diseño Diseño { get; set; }
        public int DiseñoID { get; set; }

        [Display(Name = "Fecha de transacción")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime FechaTransaccion { get; set; }

        public int Cantidad { get; set; } = 1;

        public decimal PrecioUnitario { get; set; } = 0;

        [Column(TypeName = "money")]
        public decimal Total { get; set; } = 0;
    }
}