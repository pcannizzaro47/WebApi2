using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ForcingSchemaName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.RenameTable(
                name: "PraticheEsattori",
                newName: "PraticheEsattori",
                newSchema: "user");

            migrationBuilder.RenameTable(
                name: "Pratiche",
                newName: "Pratiche",
                newSchema: "user");

            migrationBuilder.RenameTable(
                name: "Esattori",
                newName: "Esattori",
                newSchema: "user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PraticheEsattori",
                schema: "user",
                newName: "PraticheEsattori");

            migrationBuilder.RenameTable(
                name: "Pratiche",
                schema: "user",
                newName: "Pratiche");

            migrationBuilder.RenameTable(
                name: "Esattori",
                schema: "user",
                newName: "Esattori");
        }
    }
}
