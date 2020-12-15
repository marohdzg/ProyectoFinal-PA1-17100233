namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transaccion2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transacciones", "ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.Transacciones", "DiseñoID", "dbo.Diseños");
            DropIndex("dbo.Transacciones", new[] { "DiseñoID" });
            DropIndex("dbo.Transacciones", new[] { "ClienteID" });
            DropTable("dbo.Transacciones");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Transacciones",
                c => new
                    {
                        TransaccionID = c.Int(nullable: false, identity: true),
                        DiseñoID = c.Int(nullable: false),
                        ClienteID = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TransaccionID);
            
            CreateIndex("dbo.Transacciones", "ClienteID");
            CreateIndex("dbo.Transacciones", "DiseñoID");
            AddForeignKey("dbo.Transacciones", "DiseñoID", "dbo.Diseños", "DiseñoID", cascadeDelete: true);
            AddForeignKey("dbo.Transacciones", "ClienteID", "dbo.Clientes", "ClienteID", cascadeDelete: true);
        }
    }
}
