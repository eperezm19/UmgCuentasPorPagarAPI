using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Proveedor> Proveedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

        }

        public DbSet<WebAPI.Entities.Almacen> Almacen { get; set; }

        public DbSet<WebAPI.Entities.Banco> Banco { get; set; }

        public DbSet<WebAPI.Entities.EstadoOrdenCompra> EstadoOrdenCompra { get; set; }

        public DbSet<WebAPI.Entities.Factura> Factura { get; set; }

        public DbSet<WebAPI.Entities.FormaPago> FormaPago { get; set; }

        public DbSet<WebAPI.Entities.IngresoCompra> IngresoCompra { get; set; }

        public DbSet<WebAPI.Entities.OrdenCompra> OrdenCompra { get; set; }

        public DbSet<WebAPI.Entities.OrdenCompraDetalle> OrdenCompraDetalle { get; set; }

        public DbSet<WebAPI.Entities.Pago> Pago { get; set; }

        public DbSet<WebAPI.Entities.Producto> Producto { get; set; }

        public DbSet<WebAPI.Entities.ProductoProveedor> ProductoProveedor { get; set; }

        public DbSet<WebAPI.Entities.ProveedorBanco> ProveedorBanco { get; set; }

        public DbSet<WebAPI.Entities.Rol> Rol { get; set; }

        public DbSet<WebAPI.Entities.Usuario> Usuario { get; set; }

    }
}
