using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HManagementLead.Data.Migrations
{
    /// <inheritdoc />
    public partial class NuevosAtributos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Seguimientos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Ganada",
                table: "Licitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Seguimientos");

            migrationBuilder.DropColumn(
                name: "Ganada",
                table: "Licitaciones");
        }
    }
}
