using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bikes.Models
{
    public partial class Ventas : DbContext
    {
        public Ventas() : base()
        {
        }

        public Ventas(DbContextOptions<Ventas> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<DetalleOrden> DetalleOrden { get; set; }
        public virtual DbSet<EmpleadosCalifornia> EmpleadosCalifornia { get; set; }
        public virtual DbSet<EmpleadosNewYork> EmpleadosNewYork { get; set; }
        public virtual DbSet<EmpleadosTexas> EmpleadosTexas { get; set; }
        public virtual DbSet<Ordenes> Ordenes { get; set; }
        public virtual DbSet<OrdenesCalifornia> OrdenesCalifornia { get; set; }
        public virtual DbSet<OrdenesNewYork> OrdenesNewYork { get; set; }
        public virtual DbSet<OrdenesTexas> OrdenesTexas { get; set; }
        public virtual DbSet<Realorders> Realorders { get; set; }
        public virtual DbSet<TiendaCalifornia> TiendaCalifornia { get; set; }
        public virtual DbSet<TiendaNewYork> TiendaNewYork { get; set; }
        public virtual DbSet<TiendaTexas> TiendaTexas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string dbUrl = Environment.GetEnvironmentVariable("DATABASE_STRING");
                optionsBuilder.UseMySQL(dbUrl);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Calle).IsUnicode(false);

                entity.Property(e => e.Ciudad).IsUnicode(false);

                entity.Property(e => e.CodPostal).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Estado).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);
            });

            modelBuilder.Entity<DetalleOrden>(entity =>
            {
                entity.HasKey(e => new { e.IdOrden, e.IdItem })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("idProducto");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.DetalleOrden)
                    .HasForeignKey(d => d.IdOrden)
                    .HasConstraintName("detalleorden_ibfk_1");
            });

            modelBuilder.Entity<EmpleadosCalifornia>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Email)
                    .HasName("email")
                    .IsUnique();

                entity.HasIndex(e => e.IdTienda)
                    .HasName("idTienda");

                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.EmpleadosCalifornia)
                    .HasForeignKey(d => d.IdTienda)
                    .HasConstraintName("empleadoscalifornia_ibfk_1");
            });

            modelBuilder.Entity<EmpleadosNewYork>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Email)
                    .HasName("email")
                    .IsUnique();

                entity.HasIndex(e => e.IdTienda)
                    .HasName("idTienda");

                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.EmpleadosNewYork)
                    .HasForeignKey(d => d.IdTienda)
                    .HasConstraintName("empleadosnewyork_ibfk_1");
            });

            modelBuilder.Entity<EmpleadosTexas>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Email)
                    .HasName("email")
                    .IsUnique();

                entity.HasIndex(e => e.IdTienda)
                    .HasName("idTienda");

                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.EmpleadosTexas)
                    .HasForeignKey(d => d.IdTienda)
                    .HasConstraintName("empleadostexas_ibfk_1");
            });

            modelBuilder.Entity<Ordenes>(entity =>
            {
                entity.HasKey(e => e.IdOrden)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<OrdenesCalifornia>(entity =>
            {
                entity.HasKey(e => e.IdOrden)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("idCliente");

                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("idEmpleado");

                entity.HasIndex(e => e.IdTienda)
                    .HasName("idTienda");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.OrdenesCalifornia)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ordenescalifornia_ibfk_2");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.OrdenesCalifornia)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ordenescalifornia_ibfk_4");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithOne(p => p.OrdenesCalifornia)
                    .HasForeignKey<OrdenesCalifornia>(d => d.IdOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ordenescalifornia_ibfk_1");

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.OrdenesCalifornia)
                    .HasForeignKey(d => d.IdTienda)
                    .HasConstraintName("ordenescalifornia_ibfk_3");
            });

            modelBuilder.Entity<OrdenesNewYork>(entity =>
            {
                entity.HasKey(e => e.IdOrden)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("idCliente");

                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("idEmpleado");

                entity.HasIndex(e => e.IdTienda)
                    .HasName("idTienda");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.OrdenesNewYork)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ordenesnewyork_ibfk_2");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.OrdenesNewYork)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ordenesnewyork_ibfk_4");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithOne(p => p.OrdenesNewYork)
                    .HasForeignKey<OrdenesNewYork>(d => d.IdOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ordenesnewyork_ibfk_1");

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.OrdenesNewYork)
                    .HasForeignKey(d => d.IdTienda)
                    .HasConstraintName("ordenesnewyork_ibfk_3");
            });

            modelBuilder.Entity<OrdenesTexas>(entity =>
            {
                entity.HasKey(e => e.IdOrden)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("idCliente");

                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("idEmpleado");

                entity.HasIndex(e => e.IdTienda)
                    .HasName("idTienda");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.OrdenesTexas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ordenestexas_ibfk_2");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.OrdenesTexas)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ordenestexas_ibfk_4");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithOne(p => p.OrdenesTexas)
                    .HasForeignKey<OrdenesTexas>(d => d.IdOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ordenestexas_ibfk_1");

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.OrdenesTexas)
                    .HasForeignKey(d => d.IdTienda)
                    .HasConstraintName("ordenestexas_ibfk_3");
            });

            modelBuilder.Entity<Realorders>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("realorders");
            });

            modelBuilder.Entity<TiendaCalifornia>(entity =>
            {
                entity.HasKey(e => e.IdTienda)
                    .HasName("PRIMARY");

                entity.Property(e => e.Calle).IsUnicode(false);

                entity.Property(e => e.Ciudad).IsUnicode(false);

                entity.Property(e => e.CodPostal).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Estado).IsUnicode(false);

                entity.Property(e => e.NomTienda).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);
            });

            modelBuilder.Entity<TiendaNewYork>(entity =>
            {
                entity.HasKey(e => e.IdTienda)
                    .HasName("PRIMARY");

                entity.Property(e => e.Calle).IsUnicode(false);

                entity.Property(e => e.Ciudad).IsUnicode(false);

                entity.Property(e => e.CodPostal).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Estado).IsUnicode(false);

                entity.Property(e => e.NomTienda).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);
            });

            modelBuilder.Entity<TiendaTexas>(entity =>
            {
                entity.HasKey(e => e.IdTienda)
                    .HasName("PRIMARY");

                entity.Property(e => e.Calle).IsUnicode(false);

                entity.Property(e => e.Ciudad).IsUnicode(false);

                entity.Property(e => e.CodPostal).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Estado).IsUnicode(false);

                entity.Property(e => e.NomTienda).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
