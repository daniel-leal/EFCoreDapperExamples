using Microsoft.EntityFrameworkCore.Migrations;

namespace ExemplosEFCore.Migrations
{
    public partial class InitialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regioes",
                columns: table => new
                {
                    IdRegiao = table.Column<int>(nullable: false),
                    NomeRegiao = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regioes", x => x.IdRegiao);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    SiglaEstado = table.Column<string>(unicode: false, maxLength: 2, nullable: false),
                    NomeEstado = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    NomeCapital = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    IdRegiao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.SiglaEstado);
                    table.ForeignKey(
                        name: "FK_Estado_Regiao",
                        column: x => x.IdRegiao,
                        principalTable: "Regioes",
                        principalColumn: "IdRegiao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estados_IdRegiao",
                table: "Estados",
                column: "IdRegiao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Regioes");
        }
    }
}
