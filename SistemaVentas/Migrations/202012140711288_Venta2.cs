namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Venta2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Venta",
                c => new
                    {
                        VentaID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.VentaID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .Index(t => t.ClienteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venta", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Venta", new[] { "ClienteID" });
            DropTable("dbo.Venta");
        }
    }
}
