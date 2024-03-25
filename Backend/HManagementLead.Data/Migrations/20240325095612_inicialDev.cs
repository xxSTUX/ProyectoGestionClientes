using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HManagementLead.Data.Migrations
{
    /// <inheritdoc />
    public partial class inicialDev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Clientes");
        }
    }
}
