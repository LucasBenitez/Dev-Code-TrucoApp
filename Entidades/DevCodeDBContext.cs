﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Entidades
{
    public partial class DevCodeDBContext : DbContext
    {
        public DevCodeDBContext()
        {
        }

        public DevCodeDBContext(DbContextOptions<DevCodeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Avatar> Avatars { get; set; }
        public virtual DbSet<Mesa> Mesas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=DevCodeDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Avatar>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Avatar");

                entity.Property(e => e.Ceja).HasMaxLength(50);

                entity.Property(e => e.ColorDeOjos).HasMaxLength(50);

                entity.Property(e => e.ColorDePiel).HasMaxLength(50);

                entity.Property(e => e.Pelo).HasMaxLength(50);

                entity.Property(e => e.Ropa).HasMaxLength(50);
            });

            modelBuilder.Entity<Mesa>(entity =>
            {
                entity.HasKey(e => e.IdMesa);

                entity.ToTable("Mesa");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("IdUsuario");

                entity.ToTable("Usuario");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NombreCompleto).HasMaxLength(256);

                entity.Property(e => e.Password).HasMaxLength(1024);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
