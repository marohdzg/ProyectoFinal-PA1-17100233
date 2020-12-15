namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reinicio : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VentaDetalle", "DiseñoID", "dbo.Diseños");
            DropForeignKey("dbo.Venta", "ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.Venta", "VentaID", "dbo.VentaDetalle");
            DropIndex("dbo.VentaDetalle", new[] { "DiseñoID" });
            DropIndex("dbo.Venta", new[] { "VentaID" });
            DropIndex("dbo.Venta", new[] { "ClienteID" });
            AlterColumn("dbo.Diseños", "PrecioUnitario", c => c.Decimal(nullable: false, storeType: "money"));
            DropTable("dbo.VentaDetalle");
            DropTable("dbo.Venta");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Venta",
                c => new
                    {
                        VentaID = c.Int(nullable: false),
                        ClienteID = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.VentaID);
            
            CreateTable(
                "dbo.VentaDetalle",
                c => new
                    {
                        VentaID = c.Int(nullable: false),
                        DiseñoID = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.VentaID);
            
            AlterColumn("dbo.Diseños", "PrecioUnitario", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Venta", "ClienteID");
            CreateIndex("dbo.Venta", "VentaID");
            CreateIndex("dbo.VentaDetalle", "DiseñoID");
            AddForeignKey("dbo.Venta", "VentaID", "dbo.VentaDetalle", "VentaID");
            AddForeignKey("dbo.Venta", "ClienteID", "dbo.Clientes", "ClienteID", cascadeDelete: true);
            AddForeignKey("dbo.VentaDetalle", "DiseñoID", "dbo.Diseños", "DiseñoID", cascadeDelete: true);
        }
    }
}
