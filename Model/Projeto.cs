using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("projetos")]
    public class Projeto: Base
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("data_criacao_projeto")]
        public DateTime DataCriacaoProjeto { get; set; }

        [Column("data_finalizacao")]
        public DateTime DataFinalizaca { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }

        [Column("id_cliente")]
        public int IdCliente { get; set; }

    }
}
