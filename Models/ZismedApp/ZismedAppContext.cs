using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models.MomentoApp;

public partial class ZismedAppContext : DbContext
{
    public ZismedAppContext()
    {
    }

    public ZismedAppContext(DbContextOptions<ZismedAppContext> options)
        : base(options)
    {
    }


    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=168.226.219.57,2424;Database=DBH_Test;User ID=sa;Password=Excel159753;Connection Timeout=600;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ExceptionLogs>(entity =>
        {
            entity.HasKey(e => e.IdException).HasName("PK__Exceptio__0DDE5C82BFE1839D");

            entity.ToTable("Exception");

            entity.Property(e => e.Action).HasMaxLength(64);
            entity.Property(e => e.Controller).HasMaxLength(64);
            entity.Property(e => e.CreationDate).HasColumnType("smalldatetime");
        });


        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AspNetUsers");

            entity.ToTable("AspNetUsers");

            entity.Property(e => e.Id)
                .HasColumnName("Id")
                .HasMaxLength(450) 
                .IsRequired(true); 

            entity.Property(e => e.Email)
                .HasColumnName("Email")
                .HasMaxLength(256) // Ajusta el tamaño máximo si es necesario
                .IsRequired(false); // No requerido

            entity.Property(e => e.EmailConfirmed)
                .HasColumnName("EmailConfirmed")
                .IsRequired(true); // No requerido

            entity.Property(e => e.PasswordHash)
                .HasColumnName("PasswordHash")
                .IsRequired(false); // No requerido

            entity.Property(e => e.SecurityStamp)
                .HasColumnName("SecurityStamp")
                .IsRequired(false); // No requerido

            entity.Property(e => e.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .IsRequired(false); // No requerido

            entity.Property(e => e.PhoneNumberConfirmed)
                .HasColumnName("PhoneNumberConfirmed")
                .IsRequired(true); // No requerido

            entity.Property(e => e.TwoFactorEnabled)
                .HasColumnName("TwoFactorEnabled")
                .IsRequired(true); // No requerido

            entity.Property(e => e.LockoutEndDateUtc)
                .HasColumnName("LockoutEndDateUtc")
                .HasColumnType("datetime2") // Ajusta el tipo de datos si es necesario
                .IsRequired(false); // No requerido 

            entity.Property(e => e.LockoutEnabled)
                .HasColumnName("LockoutEnabled")
                .IsRequired(true); // No requerido

            entity.Property(e => e.AccessFailedCount)
                .HasColumnName("AccessFailedCount")
                .IsRequired(true); // No requerido

            entity.Property(e => e.UserName)
                .HasColumnName("UserName")
                .HasMaxLength(256) // Ajusta el tamaño máximo si es necesario
                .IsRequired(false); // No requerido

            entity.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired(false); // No requerido

            entity.Property(e => e.UserIDOriginal)
                .HasColumnName("UserIDOriginal")
                .IsRequired(false); // No requerido

            entity.Property(e => e.Token)
                .HasColumnName("Token")
                .IsRequired(false); // No requerido

            entity.Property(e => e.RequiereCambioClave)
                .HasColumnName("RequiereCambioClave")
                .IsRequired(true); // No requerido

            entity.Property(e => e.TokenZismed)
                .HasColumnName("TokenZismed")
                .IsRequired(false); // No requerido

            entity.Property(e => e.CaduceTokenZismed)
                .HasColumnName("CaduceTokenZismed")
                .HasColumnType("datetime2") // Ajusta el tipo de datos si es necesario
                .IsRequired(false); // No requerido
        });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
