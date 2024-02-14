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
 
    public virtual DbSet<Cliente> Clientes { get; set; }
    
    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Seguimientos> Seguimientos { get; set; }
    public virtual DbSet<Licitaciones> Licitaciones { get; set; }
    public virtual DbSet<LicitacionClientes> LicitacionCliente { get; set; }
    public virtual DbSet<SeguimientoClientes> SeguimientoCliente { get; set; }
    public virtual DbSet<SeguimientoProyectos> SeguimientoProyecto { get; set; }

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

        base.OnModelCreating(modelBuilder);
        //Todo lo que viene ahora crea las tablas y relaciones correspondientes en la BBDD. Para crear la BBDD por primera vez haga Add-Migration [nombre]. Para incluir otras posibles migraciones haga update-database
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);            
        });
        
        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.Cliente_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proyectos_Clientes");
        });

        modelBuilder.Entity<SeguimientoClientes>(entity =>
        {
            entity.HasOne(d => d.IdClienteNavigation)
                .WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.Cliente_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeguimientosClientes_Clientes");

            entity.HasOne(d => d.IdSeguimientoNavigation)
                .WithMany()
                .HasForeignKey(d => d.Seguimiento_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeguimientosClientes_Seguimientos");
        });

        modelBuilder.Entity<SeguimientoProyectos>(entity =>
        {
            entity.HasOne(d => d.IdProyectoNavigation)
                .WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.Proyecto_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeguimientosProyectos_Proyectos");

            entity.HasOne(d => d.IdSeguimientoNavigation)
                .WithMany()
                .HasForeignKey(d => d.Seguimiento_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeguimientosProyectos_Seguimientos");
        });

        modelBuilder.Entity<LicitacionClientes>(entity =>
        {
            entity.HasOne(d => d.IdClienteNavigation)
                .WithMany(p => p.Licitaciones)
                .HasForeignKey(d => d.Cliente_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LicitacionClientes_Clientes");

            entity.HasOne(d => d.IdLicitacionNavigation)
                .WithMany()
                .HasForeignKey(d => d.Licitacion_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LicitacionClientes_Seguimientos");
        });

        modelBuilder.Entity<LicitacionProyectos>(entity =>
        {
            entity.HasOne(d => d.IdProyectoNavigation)
                .WithMany(p => p.Licitaciones)
                .HasForeignKey(d => d.Proyecto_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LicitacionProyectos_Proyectos");

            entity.HasOne(d => d.IdLicitacionNavigation)
                .WithMany()
                .HasForeignKey(d => d.Licitacion_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LicitacionProyectos_Seguimientos");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
