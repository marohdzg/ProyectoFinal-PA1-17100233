namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VentaDetalle4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VentaDetalle", "PrecioUnitario", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VentaDetalle", "PrecioUnitario", c => c.Int(nullable: false));
        }
    }
}
