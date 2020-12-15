namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgurl3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diseños", "Imagen", c => c.Binary());
            DropColumn("dbo.Diseños", "ImagenURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Diseños", "ImagenURL", c => c.String(maxLength: 8000, unicode: false));
            DropColumn("dbo.Diseños", "Imagen");
        }
    }
}
