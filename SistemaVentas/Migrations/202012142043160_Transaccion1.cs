namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transaccion1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transacciones", "PrecioUnitario", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transacciones", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transacciones", "Total");
            DropColumn("dbo.Transacciones", "PrecioUnitario");
        }
    }
}
