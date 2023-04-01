using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class UestebanEmpleadoContext : DbContext
{
    public UestebanEmpleadoContext()
    {
    }

    public UestebanEmpleadoContext(DbContextOptions<UestebanEmpleadoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatEntidadFederativa> CatEntidadFederativas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= UEstebanEmpleado; User ID=sa; TrustServerCertificate=True; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatEntidadFederativa>(entity =>
        {
            entity.HasKey(e => e.IdEntidadFederativa).HasName("PK__CatEntid__26F25BCEA18544DD");

            entity.ToTable("CatEntidadFederativa");

            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpledo).HasName("PK__Empleado__297439FE4E7823E8");

            entity.ToTable("Empleado");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NumeroNomina)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Empleado__IdEsta__1273C1CD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
