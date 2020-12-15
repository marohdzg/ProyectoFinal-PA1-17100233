using Maro.Models;
using SistemaVentas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SistemaVentas.DAL
{
    public class MaroContext : DbContext
    {
        public MaroContext() : base("MaroContext")
        {

        }
        public DbSet<Tipo> Tipos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Diseño> Diseño { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<SistemaVentas.Models.DiseñoCarrito> DiseñoCarrito { get; set; }

        public System.Data.Entity.DbSet<SistemaVentas.Models.Transaccion> Transaccions { get; set; }
    }
}