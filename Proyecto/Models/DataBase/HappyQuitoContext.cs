using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Models.Database;

public partial class HappyQuitoContext : DbContext
{
    public HappyQuitoContext()
    {
    }

    public HappyQuitoContext(DbContextOptions<HappyQuitoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Establecimiento> Establecimientos { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<IdPaquete> IdPaquetes { get; set; }

    public virtual DbSet<IdServicio> IdServicios { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Propietario> Propietarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=CASAALEX;Database=Happy_Quito;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Establecimiento>(entity =>
        {
            entity.HasKey(e => e.IdEstablecimiento).HasName("Establecimiento_pk");

            entity.ToTable("Establecimiento");

            entity.Property(e => e.IdEstablecimiento).HasColumnName("Id_Establecimiento");
            entity.Property(e => e.Correo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.DireccionEstablecimiento)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Direccion_Establecimiento");
            entity.Property(e => e.IdPropietario).HasColumnName("Id_Propietario");
            entity.Property(e => e.NombreEstablecimiento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Establecimiento");
            entity.Property(e => e.TipoEstablecimiento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Tipo_Establecimiento");

            entity.HasOne(d => d.IdPropietarioNavigation).WithMany(p => p.Establecimientos)
                .HasForeignKey(d => d.IdPropietario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Propietario_Establecimiento_fk");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("Factura_pk");

            entity.ToTable("Factura");

            entity.Property(e => e.IdFactura).HasColumnName("Id_Factura");
            entity.Property(e => e.FechaVenta)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Venta");
            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(2, 0)");
            entity.Property(e => e.Total).HasColumnType("decimal(2, 0)");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Venta_Factura_fk");
        });

        modelBuilder.Entity<IdPaquete>(entity =>
        {
            entity.HasKey(e => e.IdPaquete1).HasName("Id_Paquete_pk");

            entity.ToTable("Id_Paquete");

            entity.Property(e => e.IdPaquete1).HasColumnName("Id_Paquete");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.IdSerivcio).HasColumnName("Id_Serivcio");

            entity.HasOne(d => d.IdSerivcioNavigation).WithMany(p => p.IdPaquetes)
                .HasForeignKey(d => d.IdSerivcio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Id_Servicio_Id_Paquete_fk");
        });

        modelBuilder.Entity<IdServicio>(entity =>
        {
            entity.HasKey(e => e.IdSerivcio).HasName("Id_Servicio_pk");

            entity.ToTable("Id_Servicio");

            entity.Property(e => e.IdSerivcio).HasColumnName("Id_Serivcio");
            entity.Property(e => e.Costo).HasColumnType("numeric(2, 0)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.IdEstablecimiento).HasColumnName("Id_Establecimiento");

            entity.HasOne(d => d.IdEstablecimientoNavigation).WithMany(p => p.IdServicios)
                .HasForeignKey(d => d.IdEstablecimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Establecimiento_Id_Servicio_fk");
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.IdMetodPago).HasName("Metodo_Pago_pk");

            entity.ToTable("Metodo_Pago");

            entity.Property(e => e.IdMetodPago).HasColumnName("Id_MetodPago");
            entity.Property(e => e.Comision).HasColumnType("decimal(2, 0)");
            entity.Property(e => e.Metodo)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Propietario>(entity =>
        {
            entity.HasKey(e => e.IdPropietario).HasName("Propietario_pk");

            entity.ToTable("Propietario");

            entity.Property(e => e.IdPropietario).HasColumnName("Id_Propietario");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cedula).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.Correo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("Usuario_pk");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cedula).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.Correo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("Venta_pk");

            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.IdMetodPago).HasColumnName("Id_MetodPago");
            entity.Property(e => e.IdPaquete).HasColumnName("Id_Paquete");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdMetodPagoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdMetodPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Metodo_Pago_Venta_fk");

            entity.HasOne(d => d.IdPaqueteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdPaquete)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Id_Paquete_Venta_fk");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Usuario_Venta_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
