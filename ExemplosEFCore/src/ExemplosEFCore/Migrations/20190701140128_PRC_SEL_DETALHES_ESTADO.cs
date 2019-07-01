using Microsoft.EntityFrameworkCore.Migrations;

namespace ExemplosEFCore.Migrations
{
    public partial class PRC_SEL_DETALHES_ESTADO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[PRC_SEL_DETALHES_ESTADO]
                        (
	                        @CodEstado char(2)
                        )
                        AS
                        BEGIN

	                        SELECT E.SiglaEstado, E.NomeEstado, E.NomeCapital, E.IdRegiao,
	                               R.NomeRegiao
	                        FROM dbo.Estados E
	                        INNER JOIN dbo.Regioes R ON R.IdRegiao = E.IdRegiao
	                        WHERE E.SiglaEstado = @CodEstado

                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
