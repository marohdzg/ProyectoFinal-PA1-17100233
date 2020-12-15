namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Disenos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diseños",
                c => new
                    {
                        DiseñoID = c.Int(nullable: false, identity: true),
                        TipoID = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 300, unicode: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DiseñoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Diseños");
        }
    }
}
