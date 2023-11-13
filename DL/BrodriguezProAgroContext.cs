using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class BrodriguezProAgroContext : DbContext
{
    public BrodriguezProAgroContext()
    {
    }

    public BrodriguezProAgroContext(DbContextOptions<BrodriguezProAgroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Georreferencium> Georreferencia { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-6OBJBAUI; Database= BRodriguezProAgro; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__FBB0EDC1CFE3ADB6");

            entity.ToTable("Estado");

            entity.Property(e => e.NombreEstado)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Georreferencium>(entity =>
        {
            entity.HasKey(e => e.IdGeorreferencia).HasName("PK__Georrefe__A624DB49F3C2CAC2");

            entity.Property(e => e.Latitud)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Longitud)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Georreferencia)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Georrefer__IdEst__182C9B23");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK__Permisos__0D626EC88407CFCC");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Permisos__IdEsta__15502E78");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Permisos__IdUsua__145C0A3F");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97F947B470");

            entity.ToTable("Usuario");

            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena).HasMaxLength(30);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Rfc)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("RFC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
