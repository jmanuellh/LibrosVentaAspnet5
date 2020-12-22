using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrosVentaAspnet5.Migrations
{
    public partial class CambiadasForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Clientes_ClienteId",
                table: "Libros");

            migrationBuilder.AlterColumn<long>(
                name: "ClienteId",
                table: "Libros",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Clientes_ClienteId",
                table: "Libros",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Clientes_ClienteId",
                table: "Libros");

            migrationBuilder.AlterColumn<long>(
                name: "ClienteId",
                table: "Libros",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Clientes_ClienteId",
                table: "Libros",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
