namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transaccion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transacciones",
                c => new
                    {
                        TransaccionID = c.Int(nullable: false, identity: true),
                        DiseñoID = c.Int(nullable: false),
                        ClienteID = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransaccionID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Diseños", t => t.DiseñoID, cascadeDelete: true)
                .Index(t => t.DiseñoID)
                .Index(t => t.ClienteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transacciones", "DiseñoID", "dbo.Diseños");
            DropForeignKey("dbo.Transacciones", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Transacciones", new[] { "ClienteID" });
            DropIndex("dbo.Transacciones", new[] { "DiseñoID" });
            DropTable("dbo.Transacciones");
        }
    }
}
