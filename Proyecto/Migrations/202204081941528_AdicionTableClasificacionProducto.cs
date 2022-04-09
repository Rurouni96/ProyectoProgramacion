namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTableClasificacionProducto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClasificacionProducto",
                c => new
                    {
                        ClasificacionProductoId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClasificacionProductoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClasificacionProducto");
        }
    }
}
