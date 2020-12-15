namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarritoListo2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transacciones",
                c => new
                    {
                        TransaccionID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        DiseñoID = c.Int(nullable: false),
                        FechaTransaccion = c.DateTime(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.TransaccionID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Diseños", t => t.DiseñoID, cascadeDelete: true)
                .Index(t => t.ClienteID)
                .Index(t => t.DiseñoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transacciones", "DiseñoID", "dbo.Diseños");
            DropForeignKey("dbo.Transacciones", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Transacciones", new[] { "DiseñoID" });
            DropIndex("dbo.Transacciones", new[] { "ClienteID" });
            DropTable("dbo.Transacciones");
        }
    }
}
