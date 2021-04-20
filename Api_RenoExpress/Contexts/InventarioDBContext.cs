using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Api_RenoExpress.Entities;



namespace Api_RenoExpress.Contexts
{
    public class InventarioDBContext : DbContext
    {

        public DbSet<Compra> Compra { get; set; }
        public DbSet<DetalleCompra> DetalleCompra { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        
        public InventarioDBContext(DbContextOptions<InventarioDBContext> options)
             : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compra>().ToTable("Compra")
                .HasKey(key => key.IdCompra);
            modelBuilder.Entity<DetalleCompra>().ToTable("DetalleCompra")
                .HasKey(key => key.IdDetalleCompra);
            modelBuilder.Entity<Venta>().ToTable("Venta")
               .HasKey(key => key.IdVenta);
            modelBuilder.Entity<DetalleVenta>().ToTable("DetalleVenta")
                .HasKey(key => key.IdDetalleVenta);
            modelBuilder.Entity<Inventario>().ToTable("Inventario")
                .HasKey(Key => Key.IdInventario);
            modelBuilder.Entity<Producto>().ToTable("Producto")
                .HasKey(key => key.IdProducto);
            modelBuilder.Entity<Sucursal>().ToTable("Sucursal")
                .HasKey(Key => Key.IdSucursal);
           


            base.OnModelCreating(modelBuilder);
        }



    }
}
