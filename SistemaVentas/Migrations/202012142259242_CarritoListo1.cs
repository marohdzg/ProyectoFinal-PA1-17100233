namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarritoListo1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiseñoCarritos",
                c => new
                    {
                        DiseñoCarritoID = c.Int(nullable: false, identity: true),
                        DiseñoID = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DiseñoCarritoID)
                .ForeignKey("dbo.Diseños", t => t.DiseñoID, cascadeDelete: true)
                .Index(t => t.DiseñoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiseñoCarritos", "DiseñoID", "dbo.Diseños");
            DropIndex("dbo.DiseñoCarritos", new[] { "DiseñoID" });
            DropTable("dbo.DiseñoCarritos");
        }
    }
}
