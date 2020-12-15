using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models
{
    public abstract class Carrito
    {
        public static List<DiseñoCarrito> lstDisenos = new List<DiseñoCarrito>();
        public static string Cliente = "";
    }
}