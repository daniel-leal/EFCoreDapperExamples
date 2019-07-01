using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemplosEFCore
{
    [Table("Regioes")]
    public class Regiao
    {
        public Regiao()
        {
            Estados = new List<Estado>();
        }

        public int IdRegiao { get; set; }
        public string NomeRegiao { get; set; }

        public ICollection<Estado> Estados { get; set; }
    }
}