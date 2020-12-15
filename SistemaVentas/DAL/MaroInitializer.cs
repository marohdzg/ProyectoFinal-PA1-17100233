using Maro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVentas.DAL
{
    public class MaroInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MaroContext>
    {
        protected override void Seed(MaroContext context)
        {
            var tipos = new List<Tipo>
            {
                new Tipo{NombreTipo="Flyer"},
                new Tipo{NombreTipo="Tarjeta de presentación"},
                new Tipo{NombreTipo="Banner"},
                new Tipo{NombreTipo="Post publicitario"},
                new Tipo{NombreTipo="Logo"},
                new Tipo{NombreTipo="Editorial"},
                new Tipo{NombreTipo="Modelo 3D"},
                new Tipo{NombreTipo="Etiquetas"},
                new Tipo{NombreTipo="Folleto"},
                new Tipo{NombreTipo="Infografía"}
            };

            tipos.ForEach(t => context.Tipos.Add(t));
            context.SaveChanges();
        }
    }
}