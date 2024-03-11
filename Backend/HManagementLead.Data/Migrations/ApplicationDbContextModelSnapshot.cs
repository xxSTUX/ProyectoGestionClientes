﻿// <auto-generated />
using System;
using HManagementLead.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HManagementLead.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HManagementLead.Data.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.Contacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.ContactoCliente", b =>
                {
                    b.Property<int>("ContactoId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.HasKey("ContactoId", "ClienteId");

                    b.HasIndex("ClienteId");

                    b.ToTable("ContactoCliente");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.Facturacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Datos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Facturaciones");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.FacturacionCliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("FacturacionId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "FacturacionId");

                    b.HasIndex("FacturacionId");

                    b.ToTable("FacturacionCliente");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.FacturacionProyecto", b =>
                {
                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<int>("FacturacionId")
                        .HasColumnType("int");

                    b.HasKey("ProyectoId", "FacturacionId");

                    b.HasIndex("FacturacionId");

                    b.ToTable("FacturacionProyecto");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.Licitacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Licitaciones");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.LicitacionCliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("LicitacionId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "LicitacionId");

                    b.HasIndex("LicitacionId");

                    b.ToTable("LicitacionCliente");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.LicitacionProyecto", b =>
                {
                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<int>("LicitacionId")
                        .HasColumnType("int");

                    b.HasKey("ProyectoId", "LicitacionId");

                    b.HasIndex("LicitacionId");

                    b.ToTable("LicitacionProyecto");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.ProyectoContacto", b =>
                {
                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<int>("ContactoId")
                        .HasColumnType("int");

                    b.HasKey("ProyectoId", "ContactoId");

                    b.HasIndex("ContactoId");

                    b.ToTable("ProyectoContacto");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.Puesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Puestos");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.PuestoCliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("PuestoId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "PuestoId");

                    b.HasIndex("PuestoId");

                    b.ToTable("PuestoCliente");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.PuestoProyecto", b =>
                {
                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<int>("PuestoId")
                        .HasColumnType("int");

                    b.HasKey("ProyectoId", "PuestoId");

                    b.HasIndex("PuestoId");

                    b.ToTable("PuestoProyecto");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.Seguimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Seguimientos");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.SeguimientoCliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("SeguimientoId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "SeguimientoId");

                    b.HasIndex("SeguimientoId");

                    b.ToTable("SeguimientoCliente");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.SeguimientoProyecto", b =>
                {
                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<int>("SeguimientoId")
                        .HasColumnType("int");

                    b.HasKey("ProyectoId", "SeguimientoId");

                    b.HasIndex("SeguimientoId");

                    b.ToTable("SeguimientoProyecto");
                });

            modelBuilder.Entity("HManagementLead.Data.Proyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.ContactoCliente", b =>
                {
                    b.HasOne("HManagementLead.Data.Cliente", "Cliente")
                        .WithMany("ContactosClientes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HManagementLead.Data.Enitites.Contacto", "Contacto")
                        .WithMany("ContactosClientes")
                        .HasForeignKey("ContactoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Contacto");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.FacturacionCliente", b =>
                {
                    b.HasOne("HManagementLead.Data.Cliente", "Cliente")
                        .WithMany("FacturacionesClientes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HManagementLead.Data.Enitites.Facturacion", "Facturacion")
                        .WithMany("FacturacionesClientes")
                        .HasForeignKey("FacturacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Facturacion");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.FacturacionProyecto", b =>
                {
                    b.HasOne("HManagementLead.Data.Enitites.Facturacion", "Facturacion")
                        .WithMany("FacturacionesProyectos")
                        .HasForeignKey("FacturacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HManagementLead.Data.Proyecto", "Proyecto")
                        .WithMany("FacturacionesProyectos")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facturacion");

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.LicitacionCliente", b =>
                {
                    b.HasOne("HManagementLead.Data.Cliente", "Cliente")
                        .WithMany("LicitacionesClientes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HManagementLead.Data.Enitites.Licitacion", "Licitacion")
                        .WithMany("LicitacionesClientes")
                        .HasForeignKey("LicitacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Licitacion");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.LicitacionProyecto", b =>
                {
                    b.HasOne("HManagementLead.Data.Enitites.Licitacion", "Licitacion")
                        .WithMany("LicitacionesProyectos")
                        .HasForeignKey("LicitacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HManagementLead.Data.Proyecto", "Proyecto")
                        .WithMany("LicitacionesProyectos")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Licitacion");

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.ProyectoContacto", b =>
                {
                    b.HasOne("HManagementLead.Data.Enitites.Contacto", "Contacto")
                        .WithMany("ProyectosContactos")
                        .HasForeignKey("ContactoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HManagementLead.Data.Proyecto", "Proyecto")
                        .WithMany("ProyectosContactos")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contacto");

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.PuestoCliente", b =>
                {
                    b.HasOne("HManagementLead.Data.Cliente", "Cliente")
                        .WithMany("PuestosClientes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HManagementLead.Data.Enitites.Puesto", "Puesto")
                        .WithMany("PuestosClientes")
                        .HasForeignKey("PuestoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Puesto");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.PuestoProyecto", b =>
                {
                    b.HasOne("HManagementLead.Data.Proyecto", "Proyecto")
                        .WithMany("PuestosProyectos")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HManagementLead.Data.Enitites.Puesto", "Puesto")
                        .WithMany("PuestosProyectos")
                        .HasForeignKey("PuestoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");

                    b.Navigation("Puesto");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.SeguimientoCliente", b =>
                {
                    b.HasOne("HManagementLead.Data.Cliente", "Cliente")
                        .WithMany("SeguimientosClientes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HManagementLead.Data.Enitites.Seguimiento", "Seguimiento")
                        .WithMany("SeguimientosClientes")
                        .HasForeignKey("SeguimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Seguimiento");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.SeguimientoProyecto", b =>
                {
                    b.HasOne("HManagementLead.Data.Proyecto", "Proyecto")
                        .WithMany("SeguimientosProyectos")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HManagementLead.Data.Enitites.Seguimiento", "Seguimiento")
                        .WithMany("SeguimientosProyectos")
                        .HasForeignKey("SeguimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");

                    b.Navigation("Seguimiento");
                });

            modelBuilder.Entity("HManagementLead.Data.Proyecto", b =>
                {
                    b.HasOne("HManagementLead.Data.Cliente", "IdClienteNavigation")
                        .WithMany("Proyectos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdClienteNavigation");
                });

            modelBuilder.Entity("HManagementLead.Data.Cliente", b =>
                {
                    b.Navigation("ContactosClientes");

                    b.Navigation("FacturacionesClientes");

                    b.Navigation("LicitacionesClientes");

                    b.Navigation("Proyectos");

                    b.Navigation("PuestosClientes");

                    b.Navigation("SeguimientosClientes");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.Contacto", b =>
                {
                    b.Navigation("ContactosClientes");

                    b.Navigation("ProyectosContactos");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.Facturacion", b =>
                {
                    b.Navigation("FacturacionesClientes");

                    b.Navigation("FacturacionesProyectos");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.Licitacion", b =>
                {
                    b.Navigation("LicitacionesClientes");

                    b.Navigation("LicitacionesProyectos");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.Puesto", b =>
                {
                    b.Navigation("PuestosClientes");

                    b.Navigation("PuestosProyectos");
                });

            modelBuilder.Entity("HManagementLead.Data.Enitites.Seguimiento", b =>
                {
                    b.Navigation("SeguimientosClientes");

                    b.Navigation("SeguimientosProyectos");
                });

            modelBuilder.Entity("HManagementLead.Data.Proyecto", b =>
                {
                    b.Navigation("FacturacionesProyectos");

                    b.Navigation("LicitacionesProyectos");

                    b.Navigation("ProyectosContactos");

                    b.Navigation("PuestosProyectos");

                    b.Navigation("SeguimientosProyectos");
                });
#pragma warning restore 612, 618
        }
    }
}
