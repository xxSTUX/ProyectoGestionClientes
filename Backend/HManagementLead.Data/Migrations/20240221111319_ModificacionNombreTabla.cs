using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HManagementLead.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionNombreTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacturacionCliente_Facturacion_FacturacionId",
                table: "FacturacionCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturacionProyecto_Facturacion_FacturacionId",
                table: "FacturacionProyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_PuestoCliente_Puesto_PuestoId",
                table: "PuestoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_PuestoProyecto_Puesto_PuestoId",
                table: "PuestoProyecto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Puesto",
                table: "Puesto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facturacion",
                table: "Facturacion");

            migrationBuilder.RenameTable(
                name: "Puesto",
                newName: "Puestos");

            migrationBuilder.RenameTable(
                name: "Facturacion",
                newName: "Facturaciones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Puestos",
                table: "Puestos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facturaciones",
                table: "Facturaciones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FacturacionCliente_Facturaciones_FacturacionId",
                table: "FacturacionCliente",
                column: "FacturacionId",
                principalTable: "Facturaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacturacionProyecto_Facturaciones_FacturacionId",
                table: "FacturacionProyecto",
                column: "FacturacionId",
                principalTable: "Facturaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PuestoCliente_Puestos_PuestoId",
                table: "PuestoCliente",
                column: "PuestoId",
                principalTable: "Puestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PuestoProyecto_Puestos_PuestoId",
                table: "PuestoProyecto",
                column: "PuestoId",
                principalTable: "Puestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacturacionCliente_Facturaciones_FacturacionId",
                table: "FacturacionCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturacionProyecto_Facturaciones_FacturacionId",
                table: "FacturacionProyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_PuestoCliente_Puestos_PuestoId",
                table: "PuestoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_PuestoProyecto_Puestos_PuestoId",
                table: "PuestoProyecto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Puestos",
                table: "Puestos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facturaciones",
                table: "Facturaciones");

            migrationBuilder.RenameTable(
                name: "Puestos",
                newName: "Puesto");

            migrationBuilder.RenameTable(
                name: "Facturaciones",
                newName: "Facturacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Puesto",
                table: "Puesto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facturacion",
                table: "Facturacion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FacturacionCliente_Facturacion_FacturacionId",
                table: "FacturacionCliente",
                column: "FacturacionId",
                principalTable: "Facturacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacturacionProyecto_Facturacion_FacturacionId",
                table: "FacturacionProyecto",
                column: "FacturacionId",
                principalTable: "Facturacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PuestoCliente_Puesto_PuestoId",
                table: "PuestoCliente",
                column: "PuestoId",
                principalTable: "Puesto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PuestoProyecto_Puesto_PuestoId",
                table: "PuestoProyecto",
                column: "PuestoId",
                principalTable: "Puesto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
