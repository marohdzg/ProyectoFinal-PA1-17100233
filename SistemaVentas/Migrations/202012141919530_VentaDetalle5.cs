namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VentaDetalle5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Venta", "VentaID", "dbo.VentaDetalle");
            DropPrimaryKey("dbo.VentaDetalle");
            AlterColumn("dbo.VentaDetalle", "VentaID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.VentaDetalle", "VentaID");
            AddForeignKey("dbo.Venta", "VentaID", "dbo.VentaDetalle", "VentaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venta", "VentaID", "dbo.VentaDetalle");
            DropPrimaryKey("dbo.VentaDetalle");
            AlterColumn("dbo.VentaDetalle", "VentaID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.VentaDetalle", "VentaID");
            AddForeignKey("dbo.Venta", "VentaID", "dbo.VentaDetalle", "VentaID");
        }
    }
}
