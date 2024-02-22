using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HManagementLead.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreacionNuevaBBDD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicitacionClientes_Clientes",
                table: "LicitacionCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_LicitacionClientes_Seguimientos",
                table: "LicitacionCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Clientes",
                table: "Proyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_SeguimientosClientes_Clientes",
                table: "SeguimientoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_SeguimientosClientes_Seguimientos",
                table: "SeguimientoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_SeguimientosProyectos_Proyectos",
                table: "SeguimientoProyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_SeguimientosProyectos_Seguimientos",
                table: "SeguimientoProyecto");

            migrationBuilder.DropTable(
                name: "LicitacionProyectos");

            migrationBuilder.RenameColumn(
                name: "telefono",
                table: "Contactos",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Contactos",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "cargo",
                table: "Contactos",
                newName: "Cargo");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Seguimientos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Seguimientos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Licitaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "ContactoCliente",
                columns: table => new
                {
                    ContactoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactoCliente", x => new { x.ContactoId, x.ClienteId });
                    table.ForeignKey(
                        name: "FK_ContactoCliente_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactoCliente_Contactos_ContactoId",
                        column: x => x.ContactoId,
                        principalTable: "Contactos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturacionCliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FacturacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturacionCliente", x => new { x.ClienteId, x.FacturacionId });
                    table.ForeignKey(
                        name: "FK_FacturacionCliente_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturacionCliente_Facturacion_FacturacionId",
                        column: x => x.FacturacionId,
                        principalTable: "Facturacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturacionProyecto",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    FacturacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturacionProyecto", x => new { x.ProyectoId, x.FacturacionId });
                    table.ForeignKey(
                        name: "FK_FacturacionProyecto_Facturacion_FacturacionId",
                        column: x => x.FacturacionId,
                        principalTable: "Facturacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturacionProyecto_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LicitacionProyecto",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    LicitacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicitacionProyecto", x => new { x.ProyectoId, x.LicitacionId });
                    table.ForeignKey(
                        name: "FK_LicitacionProyecto_Licitaciones_LicitacionId",
                        column: x => x.LicitacionId,
                        principalTable: "Licitaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicitacionProyecto_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoContacto",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    ContactoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoContacto", x => new { x.ProyectoId, x.ContactoId });
                    table.ForeignKey(
                        name: "FK_ProyectoContacto_Contactos_ContactoId",
                        column: x => x.ContactoId,
                        principalTable: "Contactos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProyectoContacto_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Puesto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puesto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PuestoCliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    PuestoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuestoCliente", x => new { x.ClienteId, x.PuestoId });
                    table.ForeignKey(
                        name: "FK_PuestoCliente_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PuestoCliente_Puesto_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puesto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PuestoProyecto",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    PuestoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuestoProyecto", x => new { x.ProyectoId, x.PuestoId });
                    table.ForeignKey(
                        name: "FK_PuestoProyecto_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PuestoProyecto_Puesto_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puesto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactoCliente_ClienteId",
                table: "ContactoCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturacionCliente_FacturacionId",
                table: "FacturacionCliente",
                column: "FacturacionId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturacionProyecto_FacturacionId",
                table: "FacturacionProyecto",
                column: "FacturacionId");

            migrationBuilder.CreateIndex(
                name: "IX_LicitacionProyecto_LicitacionId",
                table: "LicitacionProyecto",
                column: "LicitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoContacto_ContactoId",
                table: "ProyectoContacto",
                column: "ContactoId");

            migrationBuilder.CreateIndex(
                name: "IX_PuestoCliente_PuestoId",
                table: "PuestoCliente",
                column: "PuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_PuestoProyecto_PuestoId",
                table: "PuestoProyecto",
                column: "PuestoId");

            migrationBuilder.AddForeignKey(
                name: "FK_LicitacionCliente_Clientes_ClienteId",
                table: "LicitacionCliente",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LicitacionCliente_Licitaciones_LicitacionId",
                table: "LicitacionCliente",
                column: "LicitacionId",
                principalTable: "Licitaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Clientes_ClienteId",
                table: "Proyectos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeguimientoCliente_Clientes_ClienteId",
                table: "SeguimientoCliente",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeguimientoCliente_Seguimientos_SeguimientoId",
                table: "SeguimientoCliente",
                column: "SeguimientoId",
                principalTable: "Seguimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeguimientoProyecto_Proyectos_ProyectoId",
                table: "SeguimientoProyecto",
                column: "ProyectoId",
                principalTable: "Proyectos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeguimientoProyecto_Seguimientos_SeguimientoId",
                table: "SeguimientoProyecto",
                column: "SeguimientoId",
                principalTable: "Seguimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicitacionCliente_Clientes_ClienteId",
                table: "LicitacionCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_LicitacionCliente_Licitaciones_LicitacionId",
                table: "LicitacionCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Clientes_ClienteId",
                table: "Proyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_SeguimientoCliente_Clientes_ClienteId",
                table: "SeguimientoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_SeguimientoCliente_Seguimientos_SeguimientoId",
                table: "SeguimientoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_SeguimientoProyecto_Proyectos_ProyectoId",
                table: "SeguimientoProyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_SeguimientoProyecto_Seguimientos_SeguimientoId",
                table: "SeguimientoProyecto");

            migrationBuilder.DropTable(
                name: "ContactoCliente");

            migrationBuilder.DropTable(
                name: "FacturacionCliente");

            migrationBuilder.DropTable(
                name: "FacturacionProyecto");

            migrationBuilder.DropTable(
                name: "LicitacionProyecto");

            migrationBuilder.DropTable(
                name: "ProyectoContacto");

            migrationBuilder.DropTable(
                name: "PuestoCliente");

            migrationBuilder.DropTable(
                name: "PuestoProyecto");

            migrationBuilder.DropTable(
                name: "Puesto");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Seguimientos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Seguimientos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Licitaciones");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Contactos",
                newName: "telefono");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Contactos",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Cargo",
                table: "Contactos",
                newName: "cargo");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Proyectos",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clientes",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "LicitacionProyectos",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    LicitacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicitacionProyectos", x => new { x.ProyectoId, x.LicitacionId });
                    table.ForeignKey(
                        name: "FK_LicitacionProyectos_Proyectos",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LicitacionProyectos_Seguimientos",
                        column: x => x.LicitacionId,
                        principalTable: "Licitaciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LicitacionProyectos_LicitacionId",
                table: "LicitacionProyectos",
                column: "LicitacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_LicitacionClientes_Clientes",
                table: "LicitacionCliente",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LicitacionClientes_Seguimientos",
                table: "LicitacionCliente",
                column: "LicitacionId",
                principalTable: "Licitaciones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Clientes",
                table: "Proyectos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeguimientosClientes_Clientes",
                table: "SeguimientoCliente",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeguimientosClientes_Seguimientos",
                table: "SeguimientoCliente",
                column: "SeguimientoId",
                principalTable: "Seguimientos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeguimientosProyectos_Proyectos",
                table: "SeguimientoProyecto",
                column: "ProyectoId",
                principalTable: "Proyectos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeguimientosProyectos_Seguimientos",
                table: "SeguimientoProyecto",
                column: "SeguimientoId",
                principalTable: "Seguimientos",
                principalColumn: "Id");
        }
    }
}
