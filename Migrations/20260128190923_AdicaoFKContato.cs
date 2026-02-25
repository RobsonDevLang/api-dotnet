using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fundamentosApi.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoFKContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Contatos",
                type: "int",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AceitaComunicado = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_ClienteId",
                table: "Contatos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Clientes_ClienteId",
                table: "Contatos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Clientes_ClienteId",
                table: "Contatos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_ClienteId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Contatos");
        }
    }
}
