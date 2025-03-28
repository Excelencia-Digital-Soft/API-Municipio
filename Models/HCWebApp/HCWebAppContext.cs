using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Models.MomentoApp;

public partial class HCWebAppContext : DbContext
{

    private readonly IConfiguration _configuration;

    public HCWebAppContext()
    {
    }

    public HCWebAppContext(DbContextOptions<HCWebAppContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }


    public virtual DbSet<User> Usuarios { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

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


        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK_User");

            entity.ToTable("Usuarios");

            entity.Property(e => e.Nombre)
                .IsRequired();

            entity.Property(e => e.Apellido)
                .IsRequired();

            entity.Property(e => e.Direccion)
                .IsRequired();

            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsRequired(false); // Esto permite valores NULL en la columna Mail


            entity.Property(e => e.Telefono_Movil)
                .IsRequired();

            entity.Property(e => e.Contrasena)
                .IsRequired();

            entity.Property(e => e.Usuario)
                .IsRequired();

            entity.Property(e => e.Anulado)
                .IsRequired();

            entity.Property(e => e.HCU)
                .IsRequired();

            entity.Property(e => e.FechaHoraCrea)
                .HasColumnType("datetime");

            entity.Property(e => e.FechaHoraActualizaPass)
                .HasColumnType("datetime");

            entity.Property(e => e.UltimaActividad)
                .HasColumnType("datetime");

            entity.Property(e => e.CambioContrasenaRequerido)
                .IsRequired();

            entity.Property(e => e.Cuil)
                .HasColumnType("nvarchar(11)");
        });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
