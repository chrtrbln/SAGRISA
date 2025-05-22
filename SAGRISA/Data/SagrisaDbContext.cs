using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SAGRISA.Models;

namespace SAGRISA.Data;

public partial class SagrisaDbContext : DbContext
{
    public SagrisaDbContext()
    {
    }

    public SagrisaDbContext(DbContextOptions<SagrisaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<CotizacionDetalle> CotizacionDetalles { get; set; }

    public virtual DbSet<Cotizacione> Cotizaciones { get; set; }

    public virtual DbSet<SagpreciosEnLinea> SagpreciosEnLineas { get; set; }

    public virtual DbSet<SagusuariosMovil> SagusuariosMovils { get; set; }

    public virtual DbSet<SagvpedidoDetalle> SagvpedidoDetalles { get; set; }

    public virtual DbSet<SagvpedidoEncabezado> SagvpedidoEncabezados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TAKK;Database=SAGRISA_DB;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CodCliente).HasName("PK__Clientes__DF8324D731A31185");

            entity.Property(e => e.CodCliente).ValueGeneratedNever();

            entity.HasOne(d => d.VendedorNavigation).WithMany(p => p.Clientes).HasConstraintName("FK__Clientes__Vended__398D8EEE");
        });

        modelBuilder.Entity<CotizacionDetalle>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__Cotizaci__E43646A58B6A4851");

            entity.HasOne(d => d.CodCotizacionNavigation).WithMany(p => p.CotizacionDetalles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cotizacio__CodCo__4BAC3F29");

            entity.HasOne(d => d.CodProductoNavigation).WithMany(p => p.CotizacionDetalles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cotizacio__CodPr__4CA06362");
        });

        modelBuilder.Entity<Cotizacione>(entity =>
        {
            entity.HasKey(e => e.CodCotizacion).HasName("PK__Cotizaci__79BA079E7BFF028F");

            entity.Property(e => e.FechaHora).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CodClienteNavigation).WithMany(p => p.Cotizaciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cotizacio__CodCl__46E78A0C");

            entity.HasOne(d => d.CodVendedorNavigation).WithMany(p => p.Cotizaciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cotizacio__CodVe__47DBAE45");
        });

        modelBuilder.Entity<SagpreciosEnLinea>(entity =>
        {
            entity.HasKey(e => e.CodProducto).HasName("PK__SAGPreci__0D06FDF3ACAA8CAE");

            entity.Property(e => e.CodProducto).ValueGeneratedNever();
        });

        modelBuilder.Entity<SagusuariosMovil>(entity =>
        {
            entity.HasKey(e => e.CodVendedor).HasName("PK__SAGUsuar__25F4FC1B6412344B");

            entity.Property(e => e.CodVendedor).ValueGeneratedNever();
        });

        modelBuilder.Entity<SagvpedidoDetalle>(entity =>
        {
            entity.HasOne(d => d.CodClienteNavigation).WithMany().HasConstraintName("FK__SAGVPedid__CodCl__4222D4EF");

            entity.HasOne(d => d.CodProductoNavigation).WithMany().HasConstraintName("FK__SAGVPedid__CodPr__4316F928");

            entity.HasOne(d => d.CodVendedorNavigation).WithMany().HasConstraintName("FK__SAGVPedid__CodVe__440B1D61");

            entity.HasOne(d => d.NumPedidoNavigation).WithMany().HasConstraintName("FK__SAGVPedid__NumPe__412EB0B6");
        });

        modelBuilder.Entity<SagvpedidoEncabezado>(entity =>
        {
            entity.HasKey(e => e.NumPedido).HasName("PK__SAGVPedi__CC16BA14E6F4C445");

            entity.Property(e => e.NumPedido).ValueGeneratedNever();

            entity.HasOne(d => d.CodClienteNavigation).WithMany(p => p.SagvpedidoEncabezados).HasConstraintName("FK__SAGVPedid__CodCl__3E52440B");

            entity.HasOne(d => d.CodVendedorNavigation).WithMany(p => p.SagvpedidoEncabezados).HasConstraintName("FK__SAGVPedid__CodVe__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
