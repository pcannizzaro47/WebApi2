using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddingModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Esattori",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esattori", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pratiche",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceCliente = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pratiche", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PraticheEsattori",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PraticaId = table.Column<int>(type: "int", nullable: false),
                    EsattoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PraticheEsattori", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PraticheEsattori_Esattori_EsattoreId",
                        column: x => x.EsattoreId,
                        principalTable: "Esattori",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PraticheEsattori_Pratiche_PraticaId",
                        column: x => x.PraticaId,
                        principalTable: "Pratiche",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PraticheEsattori_EsattoreId",
                table: "PraticheEsattori",
                column: "EsattoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PraticheEsattori_PraticaId",
                table: "PraticheEsattori",
                column: "PraticaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PraticheEsattori");

            migrationBuilder.DropTable(
                name: "Esattori");

            migrationBuilder.DropTable(
                name: "Pratiche");
        }
    }
}
