namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgurl2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Diseños", "ImagenURL", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Diseños", "ImagenURL", c => c.Binary());
        }
    }
}
