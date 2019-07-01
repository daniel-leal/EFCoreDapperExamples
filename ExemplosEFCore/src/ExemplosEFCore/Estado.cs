using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExemplosEFCore
{
    [Table("Estados")]
    public partial class Estado
    {
        [Key]
        public string SiglaEstado { get; set; }
        public string NomeEstado { get; set; }
        public string NomeCapital { get; set; }

        public string NomeRegiao { get; set; }

        public int IdRegiao { get; set; }

        public virtual Regiao Regiao { get; set; }

        public override string ToString()
        {
            return $"{SiglaEstado}|{NomeEstado} - {NomeCapital} - {NomeRegiao}";
        }
    }
}
