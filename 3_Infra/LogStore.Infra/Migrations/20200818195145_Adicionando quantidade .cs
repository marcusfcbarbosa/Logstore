using Microsoft.EntityFrameworkCore.Migrations;

namespace Logstore.Infra.Migrations
{
    public partial class Adicionandoquantidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantidadeProduto",
                table: "ProdutoPedido",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeProduto",
                table: "ProdutoPedido");
        }
    }
}
