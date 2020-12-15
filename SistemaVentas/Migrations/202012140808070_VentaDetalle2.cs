namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VentaDetalle2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Venta");
            CreateTable(
                "dbo.VentaDetalle",
                c => new
                    {
                        VentaID = c.Int(nullable: false, identity: true),
                        DiseñoID = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.VentaID)
                .ForeignKey("dbo.Diseños", t => t.DiseñoID, cascadeDelete: true)
                .Index(t => t.DiseñoID);
            
            AlterColumn("dbo.Venta", "VentaID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Venta", "VentaID");
            CreateIndex("dbo.Venta", "VentaID");
            AddForeignKey("dbo.Venta", "VentaID", "dbo.VentaDetalle", "VentaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venta", "VentaID", "dbo.VentaDetalle");
            DropForeignKey("dbo.VentaDetalle", "DiseñoID", "dbo.Diseños");
            DropIndex("dbo.Venta", new[] { "VentaID" });
            DropIndex("dbo.VentaDetalle", new[] { "DiseñoID" });
            DropPrimaryKey("dbo.Venta");
            AlterColumn("dbo.Venta", "VentaID", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.VentaDetalle");
            AddPrimaryKey("dbo.Venta", "VentaID");
        }
    }
}
