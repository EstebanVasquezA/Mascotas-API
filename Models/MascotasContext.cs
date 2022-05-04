using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mascotas_API.Models
{
    public partial class MascotasContext : DbContext
    {
        public MascotasContext()
        {
        }

        public MascotasContext(DbContextOptions<MascotasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mascotum> Mascota { get; set; } = null!;
        public virtual DbSet<Medicamento> Medicamentos { get; set; } = null!;
        public virtual DbSet<Raza> Razas { get; set; } = null!;
        public virtual DbSet<RegistroMedicamento> RegistroMedicamentos { get; set; } = null!;
        public virtual DbSet<TipoMascotum> TipoMascota { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Veterinario> Veterinarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SERVER=.;DATABASE=Mascotas; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mascotum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Color)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.RazaNavigation)
                    .WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.Raza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mascota__Raza__29572725");

                entity.HasOne(d => d.TipoMascotaNavigation)
                    .WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.TipoMascota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mascota__TipoMas__286302EC");
            });

            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.ToTable("Medicamento");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Raza>(entity =>
            {
                entity.ToTable("Raza");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegistroMedicamento>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.MascotaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Mascota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RegistroM__Masco__300424B4");

                entity.HasOne(d => d.MedicamentoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Medicamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RegistroM__Medic__2F10007B");

                entity.HasOne(d => d.VeterinarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Veterinario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RegistroM__Veter__30F848ED");
            });

            modelBuilder.Entity<TipoMascotum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contrasenna)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Veterinario>(entity =>
            {
                entity.ToTable("Veterinario");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
