using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploDapper
{
    [Table("dbo.Estados")]
    public class Estado
    {
        [ExplicitKey]
        public string SiglaEstado { get; set; }
        public string NomeEstado { get; set; }
        public string NomeCapital { get; set; }
        public string NomeRegiao { get; set; }

        public override string ToString()
        {
            return $"{SiglaEstado}|{NomeEstado} - {NomeCapital} - {NomeRegiao}";
        }
    }
}
