﻿using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
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

    public virtual DbSet<Seguimiento> Seguimientos { get; set; }

    public virtual DbSet<SeguimientoClientes> SeguimientoClientes { get; set; }
    public virtual DbSet<Prueba> Prueba { get; set; }

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
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proyectos_Clientes");
        });

        modelBuilder.Entity<SeguimientoClientes>(entity =>
        {
            entity.HasOne(d => d.IdClienteNavigation)
                .WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeguimientosClientes_Clientes");

            entity.HasOne(d => d.IdSeguimientoNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdSeguimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeguimientosClientes_Seguimientos");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
