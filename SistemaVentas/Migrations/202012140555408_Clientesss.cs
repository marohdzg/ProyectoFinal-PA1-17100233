namespace SistemaVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clientesss : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Nombre", c => c.String(nullable: false, maxLength: 70, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Nombre", c => c.String(nullable: false, maxLength: 20, unicode: false));
        }
    }
}
