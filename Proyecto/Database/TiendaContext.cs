using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Proyecto.Database
{
    public class TiendaContext : DbContext
    {
        public TiendaContext() : base("Proyecto")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
       public DbSet<Cliente> clientes { get; set; }
       public DbSet<Producto> productos { get; set; }
       public  DbSet<ClasificacionCliente> clasificacionClientes { get; set; }
       public DbSet<ClasificacionProducto> clasificacionProductos { get; set; }
       public DbSet<Pedido> pedidos { get; set; }
       public DbSet<PedidoDetalle> pedidoDetalles { get; set; }
      public  DbSet<Unidad> unidads { get; set; }



    }
}