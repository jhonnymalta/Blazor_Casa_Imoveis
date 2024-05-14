using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor_Casa_Imoveis.Data.Migrations
{
    /// <inheritdoc />
    public partial class createImovelModelsEndImagemsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImovelImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImovelId = table.Column<int>(type: "int", nullable: false),
                    UrlImovelImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImovelImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImovelImages_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImovelImages_ImovelId",
                table: "ImovelImages",
                column: "ImovelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImovelImages");
        }
    }
}
