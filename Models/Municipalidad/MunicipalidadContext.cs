using Microsoft.EntityFrameworkCore;

namespace Models.Municipalidad;

public partial class MunicipalidadContext : DbContext
{
    public MunicipalidadContext()
    {
    }

    public MunicipalidadContext(DbContextOptions<MunicipalidadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<TipoInmueble> TipoInmuebles { get; set; }
    public virtual DbSet<Barrio> Barrios { get; set; }
    public virtual DbSet<Municipio> Municipios { get; set; }
    public virtual DbSet<TipoImpuesto> TipoImpuestos { get; set; }
    public virtual DbSet<Departamento> Departamentos { get; set; }
    public virtual DbSet<Factura> Facturas { get; set; }
    
    public virtual DbSet<Contribuyente> Contribuyentes { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Inmueble> Inmuebles { get; set; }

    public virtual DbSet<RelacionImpuesto> RelacionImpuestos { get; set; }
    public virtual DbSet<TipoImpuestoDetalle> TipoImpuestoDetalles { get; set; }





    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.0.108;Database=Municipalidad;User ID=Salud;Password=ColMed*9122018;Connection Timeout=600;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pago>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("pagos");

             
        });
        //modelBuilder.Entity<TipoImpuestoDetalle>(entity =>
        //{
        //    entity.HasKey(e => e.id_tipoimpuesto);
        //    entity.ToTable("tipoimpuestodetalles");
        //});
        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.id_pago);
            entity.ToTable("pagos");
        });
        modelBuilder.Entity<TipoImpuestoDetalle>(entity =>
        {
            entity.HasKey(e => e.id_tipo_impuesto);
            entity.ToTable("TipoImpuestoDetalles");
        });
        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.id_factura); // Definir clave primaria

            entity.Property(e => e.id_factura)
                .HasColumnName("id_factura"); // Asegurar nombre correcto
            

            entity.Property(e => e.fecha_emision)
                .HasColumnType("datetime"); // Asegurar tipo correcto

            entity.Property(e => e.fecha_vencimiento)
                .HasColumnType("datetime");
        });
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D1FCFB93F0");

            entity.Property(e => e.RolId)
                .ValueGeneratedNever()
                .HasColumnName("RolID");
            entity.Property(e => e.RolName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC7800D41E");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaEliminacion).HasColumnName("fecha_eliminacion");
            entity.Property(e => e.Institucionid).HasColumnName("institucionid");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleID__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
