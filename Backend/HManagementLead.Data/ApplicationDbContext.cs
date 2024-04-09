using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Diagnostics;

namespace HManagementLead.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
        
    }
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Contacto> Contactos => Set<Contacto>();
    public DbSet<ContactoCliente> ContactoCliente => Set<ContactoCliente>();
    public DbSet<Facturacion> Facturaciones => Set<Facturacion>();
    public DbSet<FacturacionCliente> FacturacionCliente => Set<FacturacionCliente>();
    public DbSet<FacturacionProyecto> FacturacionProyecto => Set<FacturacionProyecto>();
    public DbSet<Licitacion> Licitaciones => Set<Licitacion>();
    public DbSet<LicitacionCliente> LicitacionCliente => Set<LicitacionCliente>();
    public DbSet<LicitacionProyecto> LicitacionProyecto => Set<LicitacionProyecto>();
    public DbSet<Proyecto> Proyectos => Set<Proyecto>();
    public DbSet<ProyectoContacto> ProyectoContacto => Set<ProyectoContacto>();
    public DbSet<Puesto> Puestos => Set<Puesto>();
    public DbSet<PuestoCliente> PuestoCliente => Set<PuestoCliente>();
    public DbSet<PuestoProyecto> PuestoProyecto => Set<PuestoProyecto>();
    public DbSet<Seguimiento> Seguimientos => Set<Seguimiento>();
    public DbSet<SeguimientoCliente> SeguimientoCliente => Set<SeguimientoCliente>();
    public DbSet<SeguimientoProyecto> SeguimientoProyecto => Set<SeguimientoProyecto>();
    public DbSet<EstadoProyecto> EstadoProyecto => Set<EstadoProyecto>();
    public DbSet<EstadoProyectoDetalle> EstadoProyectoDetalle => Set<EstadoProyectoDetalle>();
    public DbSet<Area> Area => Set<Area>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        if (Debugger.IsAttached)
        {
            //optionsBuilder
            //    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddSerilog()))
            //    .EnableSensitiveDataLogging();
                //.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted }, LogLevel.Information);

            Log.Logger.Information("Entity Framework Core Logging Enabled");
        }

        base.OnConfiguring(optionsBuilder); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    //    base.OnModelCreating(modelBuilder);
    //    //Todo lo que viene ahora crea las tablas y relaciones correspondientes en la BBDD. Para crear la BBDD por primera vez haga Add-Migration [nombre]. Para incluir otras posibles migraciones haga update-database
    //    modelBuilder.Entity<Cliente>(entity =>
    //    {
    //        entity.Property(e => e.Nombre)
    //            .HasMaxLength(100)
    //            .IsUnicode(false);            
    //    });

    //    modelBuilder.Entity<Facturacion>(entity =>
    //    {
    //        entity.Property(e => e.Datos)
    //            .HasMaxLength(100)
    //            .IsUnicode(false);
    //    });

    //    modelBuilder.Entity<Proyecto>(entity =>
    //    {
    //        entity.Property(e => e.Nombre)
    //            .HasMaxLength(200)
    //            .IsUnicode(false);

    //        entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Proyectos)
    //            .HasForeignKey(d => d.ClienteId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_Proyectos_Clientes");
    //    });

    //    modelBuilder.Entity<SeguimientoCliente>(entity =>
    //    {
    //        entity.HasOne(d => d.IdClienteNavigation)
    //            .WithMany(p => p.Seguimientos)
    //            .HasForeignKey(d => d.ClienteId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_SeguimientosClientes_Clientes");

    //        entity.HasOne(d => d.IdSeguimientoNavigation)
    //            .WithMany()
    //            .HasForeignKey(d => d.SeguimientoId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_SeguimientosClientes_Seguimientos");
    //    });

    //    modelBuilder.Entity<SeguimientoProyecto>(entity =>
    //    {
    //        entity.HasOne(d => d.IdProyectoNavigation)
    //            .WithMany(p => p.Seguimientos)
    //            .HasForeignKey(d => d.ProyectoId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_SeguimientosProyectos_Proyectos");

    //        entity.HasOne(d => d.IdSeguimientoNavigation)
    //            .WithMany()
    //            .HasForeignKey(d => d.SeguimientoId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_SeguimientosProyectos_Seguimientos");
    //    });

    //    modelBuilder.Entity<LicitacionCliente>(entity =>
    //    {
    //        entity.HasOne(d => d.IdClienteNavigation)
    //            .WithMany(p => p.Licitaciones)
    //            .HasForeignKey(d => d.Cliente_id)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_LicitacionClientes_Clientes");

    //        entity.HasOne(d => d.IdLicitacionNavigation)
    //            .WithMany()
    //            .HasForeignKey(d => d.Licitacion_id)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_LicitacionClientes_Seguimientos");
    //    });

    //    modelBuilder.Entity<LicitacionProyecto>(entity =>
    //    {
    //        entity.HasOne(d => d.IdProyectoNavigation)
    //            .WithMany(p => p.Licitaciones)
    //            .HasForeignKey(d => d.ProyectoId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_LicitacionProyectos_Proyectos");

    //        entity.HasOne(d => d.IdLicitacionNavigation)
    //            .WithMany()
    //            .HasForeignKey(d => d.LicitacionId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_LicitacionProyectos_Seguimientos");
    //    });
    //    OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
