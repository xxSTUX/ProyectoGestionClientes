using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HManagementLead.Data.Migrations
{
    /// <inheritdoc />
    public partial class TablasCargaTreeMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteBasic",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteBasic", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "LicitacionBasic",
                columns: table => new
                {
                    LicitacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicitacionBasic", x => x.LicitacionId);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoBasic",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoBasic", x => x.ProyectoId);
                });

            migrationBuilder.CreateTable(
                name: "SeguimientoBasic",
                columns: table => new
                {
                    SeguimientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguimientoBasic", x => x.SeguimientoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteBasic");

            migrationBuilder.DropTable(
                name: "LicitacionBasic");

            migrationBuilder.DropTable(
                name: "ProyectoBasic");

            migrationBuilder.DropTable(
                name: "SeguimientoBasic");
        }
    }
}
