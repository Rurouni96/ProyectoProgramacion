namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTableRelaciones : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Cliente", "ClasificacionId");
            CreateIndex("dbo.PedidoDetalle", "PedidoId");
            CreateIndex("dbo.PedidoDetalle", "ProductoId");
            CreateIndex("dbo.Pedido", "ClienteId");
            CreateIndex("dbo.Producto", "ClasificacionProductoId");
            CreateIndex("dbo.Producto", "UnidadMedidaId");
            AddForeignKey("dbo.Cliente", "ClasificacionId", "dbo.ClasificacionCliente", "ClasificacionId");
            AddForeignKey("dbo.Pedido", "ClienteId", "dbo.Cliente", "ClienteId");
            AddForeignKey("dbo.PedidoDetalle", "PedidoId", "dbo.Pedido", "PedidoId");
            AddForeignKey("dbo.Producto", "ClasificacionProductoId", "dbo.ClasificacionProducto", "ClasificacionProductoId");
            AddForeignKey("dbo.Producto", "UnidadMedidaId", "dbo.Unidad", "UnidadMedidaId");
            AddForeignKey("dbo.PedidoDetalle", "ProductoId", "dbo.Producto", "ProductoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoDetalle", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.Producto", "UnidadMedidaId", "dbo.Unidad");
            DropForeignKey("dbo.Producto", "ClasificacionProductoId", "dbo.ClasificacionProducto");
            DropForeignKey("dbo.PedidoDetalle", "PedidoId", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Cliente", "ClasificacionId", "dbo.ClasificacionCliente");
            DropIndex("dbo.Producto", new[] { "UnidadMedidaId" });
            DropIndex("dbo.Producto", new[] { "ClasificacionProductoId" });
            DropIndex("dbo.Pedido", new[] { "ClienteId" });
            DropIndex("dbo.PedidoDetalle", new[] { "ProductoId" });
            DropIndex("dbo.PedidoDetalle", new[] { "PedidoId" });
            DropIndex("dbo.Cliente", new[] { "ClasificacionId" });
        }
    }
}
