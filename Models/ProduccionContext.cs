using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bikes.Models
{
    public partial class ProduccionContext : DbContext
    {
        public ProduccionContext()
        {
        }

        public ProduccionContext(DbContextOptions<ProduccionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<InventarioCalifornia> InventarioCalifornia { get; set; }
        public virtual DbSet<InventarioNewYork> InventarioNewYork { get; set; }
        public virtual DbSet<InventarioTexas> InventarioTexas { get; set; }
        public virtual DbSet<Marcas> Marcas { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                Console.WriteLine("Connnecting to DB");
                string dbUrl = Environment.GetEnvironmentVariable("DATABASE_STRING_P");
                optionsBuilder.UseMySQL(dbUrl);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                Console.WriteLine("Connnecting to Master DB");
                string dbUrl = Environment.GetEnvironmentVariable("DATABASE_STRING_NY_P");
                optionsBuilder.UseMySQL(dbUrl);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PRIMARY");

                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<InventarioCalifornia>(entity =>
            {
                entity.HasKey(e => new { e.IdTienda, e.IdProducto })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("idProducto");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.InventarioCalifornia)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("inventariocalifornia_ibfk_2");
            });

            modelBuilder.Entity<InventarioNewYork>(entity =>
            {
                entity.HasKey(e => new { e.IdTienda, e.IdProducto })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("idProducto");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.InventarioNewYork)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("inventarionewyork_ibfk_2");
            });

            modelBuilder.Entity<InventarioTexas>(entity =>
            {
                entity.HasKey(e => new { e.IdTienda, e.IdProducto })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("idProducto");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.InventarioTexas)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("inventariotexas_ibfk_2");
            });

            modelBuilder.Entity<Marcas>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PRIMARY");

                entity.Property(e => e.NomMarca).IsUnicode(false);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCategoria)
                    .HasName("idCategoria");

                entity.HasIndex(e => e.IdMarca)
                    .HasName("idMarca");

                entity.Property(e => e.NomProducto).IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("productos_ibfk_1");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("productos_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
