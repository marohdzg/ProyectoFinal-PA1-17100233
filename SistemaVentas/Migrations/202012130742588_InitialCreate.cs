namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tipos",
                c => new
                    {
                        TipoID = c.Int(nullable: false, identity: true),
                        NombreTipo = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.TipoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tipos");
        }
    }
}
