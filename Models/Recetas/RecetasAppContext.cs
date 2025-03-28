using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Recetas;

namespace Models.MomentoApp;

public partial class RecetasAppContext : DbContext
{

    private readonly IConfiguration _configuration;

    public RecetasAppContext()
    {
    }

    public RecetasAppContext(DbContextOptions<RecetasAppContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }


    public virtual DbSet<Receta> Recetas { get; set; }
    public virtual DbSet<RecetaDetalle> RecetaDetalle { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("Recetas");
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



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
