namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarritoListo4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiseñoCarritos", "PrecioUnitario", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiseñoCarritos", "PrecioUnitario");
        }
    }
}
