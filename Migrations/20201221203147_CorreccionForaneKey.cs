using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrosVentaAspnet5.Migrations
{
    public partial class CorreccionForaneKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Libros_LibroId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_LibroId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "LibroId",
                table: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ClienteId",
                table: "Libros",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_ClienteId",
                table: "Libros",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Clientes_ClienteId",
                table: "Libros",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Clientes_ClienteId",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_ClienteId",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Libros");

            migrationBuilder.AlterColumn<long>(
                name: "Nombre",
                table: "Libros",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Nombre",
                table: "Clientes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LibroId",
                table: "Clientes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_LibroId",
                table: "Clientes",
                column: "LibroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Libros_LibroId",
                table: "Clientes",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
