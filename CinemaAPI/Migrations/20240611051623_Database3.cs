using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Database3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Ingresso_IngressoID",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_IngressoID",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IngressoID",
                table: "Produtos");

            migrationBuilder.CreateTable(
                name: "IngressoProdutoBomboniere",
                columns: table => new
                {
                    CarrinhoBomboniereID = table.Column<int>(type: "int", nullable: false),
                    IngressosID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngressoProdutoBomboniere", x => new { x.CarrinhoBomboniereID, x.IngressosID });
                    table.ForeignKey(
                        name: "FK_IngressoProdutoBomboniere_Ingresso_IngressosID",
                        column: x => x.IngressosID,
                        principalTable: "Ingresso",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngressoProdutoBomboniere_Produtos_CarrinhoBomboniereID",
                        column: x => x.CarrinhoBomboniereID,
                        principalTable: "Produtos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_IngressoProdutoBomboniere_IngressosID",
                table: "IngressoProdutoBomboniere",
                column: "IngressosID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngressoProdutoBomboniere");

            migrationBuilder.AddColumn<int>(
                name: "IngressoID",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IngressoID",
                table: "Produtos",
                column: "IngressoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Ingresso_IngressoID",
                table: "Produtos",
                column: "IngressoID",
                principalTable: "Ingresso",
                principalColumn: "ID");
        }
    }
}
