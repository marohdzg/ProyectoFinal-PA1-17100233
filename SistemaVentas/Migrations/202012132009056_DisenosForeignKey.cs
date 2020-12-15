namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisenosForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diseños", "ImagenURL", c => c.String(maxLength: 8000, unicode: false));
            CreateIndex("dbo.Diseños", "TipoID");
            AddForeignKey("dbo.Diseños", "TipoID", "dbo.Tipos", "TipoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Diseños", "TipoID", "dbo.Tipos");
            DropIndex("dbo.Diseños", new[] { "TipoID" });
            DropColumn("dbo.Diseños", "ImagenURL");
        }
    }
}
