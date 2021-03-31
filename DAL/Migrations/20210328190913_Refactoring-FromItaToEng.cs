using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RefactoringFromItaToEng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PraticheEsattori_EsattoreId",
                table: "PraticheEsattori");

            migrationBuilder.CreateIndex(
                name: "IX_PraticheEsattori_EsattoreId_PraticaId",
                table: "PraticheEsattori",
                columns: new[] { "EsattoreId", "PraticaId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PraticheEsattori_EsattoreId_PraticaId",
                table: "PraticheEsattori");

            migrationBuilder.CreateIndex(
                name: "IX_PraticheEsattori_EsattoreId",
                table: "PraticheEsattori",
                column: "EsattoreId");
        }
    }
}
