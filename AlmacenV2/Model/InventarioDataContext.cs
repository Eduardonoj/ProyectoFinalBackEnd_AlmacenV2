using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AlmacenV2.Model
{
    public class InventarioDataContext : DbContext
    {
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<TipoEmpaque> TipoEmpaques { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<TelefonoCliente> TelefonoClientes { get;set;}
        public DbSet<EmailCliente> EmailClientes { get; set; }
        public DbSet<TelefonoProveedor> TelefonoProveedores { get; set; }
        public DbSet<EmailProveedor> EmailProveedores { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Proveedor>()
                .ToTable("Proveedor")
                .HasKey(p => new { p.CodigoProveedor });
            modelBuilder.Entity<Cliente>()
                .ToTable("Cliente")
                .HasKey(c => new { c.Nit });
            modelBuilder.Entity<Categoria>()
                .ToTable("Categoria")
                .HasKey(ca => new { ca.CodigoCategoria });
            modelBuilder.Entity<TipoEmpaque>()
                .ToTable("TipoEmpaque")
                .HasKey(tp => new { tp.CodigoEmpaque });
            modelBuilder.Entity<Producto>()
                .ToTable("Producto")
                .HasKey(p => new { p.CodigoProducto });
            modelBuilder.Entity<TelefonoCliente>()
                .ToTable("TelefonoCliente")
                .HasKey(t => new { t.CodigoTelefono });
            modelBuilder.Entity<EmailCliente>()
                .ToTable("EmailCliente")
                .HasKey(e => new { e.CodigoEmail });
            modelBuilder.Entity<TelefonoProveedor>()
                .ToTable("TelefonoProveedor")
                .HasKey(t => new { t.CodigoTelefono });
            modelBuilder.Entity<EmailProveedor>()
                .ToTable("EmailProveedor")
                .HasKey(e => new { e.CodigoEmail });
            modelBuilder.Entity<Inventario>()
                .ToTable("Inventario")
                .HasKey(i => new { i.CodigoInventario });
            modelBuilder.Entity<Compra>()
                .ToTable("Compra")
                .HasKey(c => new { c.IdCompra });
            modelBuilder.Entity<DetalleCompra>()
                .ToTable("DetalleCompra")
                .HasKey(d => new { d.IdDetalle });
            modelBuilder.Entity<Factura>()
                .ToTable("Factura")
                .HasKey(f => new { f.NumeroFactura});
            modelBuilder.Entity<DetalleFactura>()
                .ToTable("DetalleFactura")
                .HasKey(d => new { d.CodigoDetalle });
        }
    }
}
