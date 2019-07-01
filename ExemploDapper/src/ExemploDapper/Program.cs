using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExemploDapper
{
    class Program
    {
        public static IEnumerable<Estado> obterEstados ()
        {
            var sql = "SELECT E.SiglaEstado, E.NomeEstado, E.NomeCapital, " +
                        "R.NomeRegiao " +
                        "FROM dbo.Estados E " +
                        "INNER JOIN dbo.Regioes R ON R.IdRegiao = E.IdRegiao " +
                        "ORDER BY E.NomeEstado";


            using (SqlConnection conn = new SqlConnection(Settings.ConnectionString))
            {
                //return conn.GetAll<Estado>(); //  limitado

                return conn.Query<Estado>(sql);
            }
        }

        public static Estado obterPorSigla(string siglaEstado)
        {
            var sql = "SELECT E.SiglaEstado, E.NomeEstado, E.NomeCapital, " +
                        "R.NomeRegiao " +
                        "FROM dbo.Estados E " +
                        "INNER JOIN dbo.Regioes R ON R.IdRegiao = E.IdRegiao " +
                        "WHERE E.SiglaEstado = @CodEstado";


            using (SqlConnection conn = new SqlConnection(Settings.ConnectionString))
            {
                //return conn.Get<Estado>(siglaEstado); // Limitado

                return conn.QueryFirstOrDefault<Estado>(sql, new { CodEstado = siglaEstado });
            }
        }

        public static Estado obterPorSiglaProcedure(string siglaEstado)
        {
            using (SqlConnection conn = new SqlConnection(Settings.ConnectionString))
            {
                var result = conn.QueryFirstOrDefault<Estado>(
                    "dbo.PRC_SEL_DETALHES_ESTADO",
                    new { CodEstado = siglaEstado },
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }


        static void Main(string[] args)
        {
            #region Todos
            foreach (var estado in obterEstados())
            {
                Console.WriteLine(estado.ToString());
            }
            Console.WriteLine("----------------------------------------------------");
            #endregion

            #region Por Sigla
            Console.WriteLine(obterPorSigla("PA").ToString());
            Console.WriteLine("----------------------------------------------------");
            #endregion

            #region Por Sigla Procedure
            Console.WriteLine(obterPorSiglaProcedure("RJ").ToString());
            Console.WriteLine("----------------------------------------------------");
            #endregion

            Console.ReadKey();
        }
    }
}
