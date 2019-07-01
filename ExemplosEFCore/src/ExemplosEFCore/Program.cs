using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ExemplosEFCore
{
    class Program
    {
        public static IEnumerable<Estado> obterEstados ()
        {
            using (var ctx = new ExemploEFCoreContext())
            {
                //var estados = ctx.Estados.Include(x => x.Regiao).ToList();

                var estados = from est in ctx.Estados
                              join reg in ctx.Regioes on est.IdRegiao equals reg.IdRegiao
                              select new Estado
                              {
                                  IdRegiao = reg.IdRegiao,
                                  NomeCapital = est.NomeCapital,
                                  NomeEstado = est.NomeEstado,
                                  NomeRegiao = reg.NomeRegiao,
                                  SiglaEstado = est.SiglaEstado
                              };

                return estados.ToList();
            }
        }

        public static Estado obterPorSigla(string siglaEstado)
        {
            using (var ctx = new ExemploEFCoreContext())
            {
                //var estado = ctx.Estados
                //        .Include(x => x.Regiao)
                //        .Where(x => x.SiglaEstado == siglaEstado)
                //        .SingleOrDefault();

                var estado = (from est in ctx.Estados
                              join reg in ctx.Regioes on est.IdRegiao equals reg.IdRegiao
                              where est.SiglaEstado == siglaEstado
                              select new Estado
                              {
                                  IdRegiao = reg.IdRegiao,
                                  NomeCapital = est.NomeCapital,
                                  NomeEstado = est.NomeEstado,
                                  NomeRegiao = reg.NomeRegiao,
                                  SiglaEstado = est.SiglaEstado
                              }).SingleOrDefault();

                return estado;
            }
        }

        public static Estado obterPorSiglaProcedure(string siglaEstado)
        {
            using (var ctx = new ExemploEFCoreContext())
            {
                var result = ctx.Estados.FromSql("[dbo].[PRC_SEL_DETALHES_ESTADO] @CodEstado", new SqlParameter("@CodEstado", siglaEstado)).SingleOrDefault();

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
            Console.ReadKey();
            #endregion
        }
    }
}
