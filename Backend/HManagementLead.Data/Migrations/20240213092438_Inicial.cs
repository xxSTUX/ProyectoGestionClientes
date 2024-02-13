using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HManagementLead.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Licitaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licitaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seguimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguimientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente_id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyectos_Clientes",
                        column: x => x.Cliente_id,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LicitacionCliente",
                columns: table => new
                {
                    Cliente_id = table.Column<int>(type: "int", nullable: false),
                    Licitacion_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicitacionCliente", x => new { x.Cliente_id, x.Licitacion_id });
                    table.ForeignKey(
                        name: "FK_LicitacionClientes_Clientes",
                        column: x => x.Cliente_id,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LicitacionClientes_Seguimientos",
                        column: x => x.Licitacion_id,
                        principalTable: "Licitaciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SeguimientoCliente",
                columns: table => new
                {
                    Cliente_id = table.Column<int>(type: "int", nullable: false),
                    Seguimiento_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguimientoCliente", x => new { x.Cliente_id, x.Seguimiento_id });
                    table.ForeignKey(
                        name: "FK_SeguimientosClientes_Clientes",
                        column: x => x.Cliente_id,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SeguimientosClientes_Seguimientos",
                        column: x => x.Seguimiento_id,
                        principalTable: "Seguimientos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LicitacionProyectos",
                columns: table => new
                {
                    Proyecto_id = table.Column<int>(type: "int", nullable: false),
                    Licitacion_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicitacionProyectos", x => new { x.Proyecto_id, x.Licitacion_id });
                    table.ForeignKey(
                        name: "FK_LicitacionProyectos_Proyectos",
                        column: x => x.Proyecto_id,
                        principalTable: "Proyectos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LicitacionProyectos_Seguimientos",
                        column: x => x.Licitacion_id,
                        principalTable: "Licitaciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SeguimientoProyecto",
                columns: table => new
                {
                    Proyecto_id = table.Column<int>(type: "int", nullable: false),
                    Seguimiento_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguimientoProyecto", x => new { x.Proyecto_id, x.Seguimiento_id });
                    table.ForeignKey(
                        name: "FK_SeguimientosProyectos_Proyectos",
                        column: x => x.Proyecto_id,
                        principalTable: "Proyectos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SeguimientosProyectos_Seguimientos",
                        column: x => x.Seguimiento_id,
                        principalTable: "Seguimientos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LicitacionCliente_Licitacion_id",
                table: "LicitacionCliente",
                column: "Licitacion_id");

            migrationBuilder.CreateIndex(
                name: "IX_LicitacionProyectos_Licitacion_id",
                table: "LicitacionProyectos",
                column: "Licitacion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_Cliente_id",
                table: "Proyectos",
                column: "Cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_SeguimientoCliente_Seguimiento_id",
                table: "SeguimientoCliente",
                column: "Seguimiento_id");

            migrationBuilder.CreateIndex(
                name: "IX_SeguimientoProyecto_Seguimiento_id",
                table: "SeguimientoProyecto",
                column: "Seguimiento_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicitacionCliente");

            migrationBuilder.DropTable(
                name: "LicitacionProyectos");

            migrationBuilder.DropTable(
                name: "SeguimientoCliente");

            migrationBuilder.DropTable(
                name: "SeguimientoProyecto");

            migrationBuilder.DropTable(
                name: "Licitaciones");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Seguimientos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
