using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBackEndApi.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoChaveEstrangeiraEmComanda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Comandas_IdUsuario",
                table: "Comandas",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Comandas_Usuarios_IdUsuario",
                table: "Comandas",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comandas_Usuarios_IdUsuario",
                table: "Comandas");

            migrationBuilder.DropIndex(
                name: "IX_Comandas_IdUsuario",
                table: "Comandas");
        }
    }
}
