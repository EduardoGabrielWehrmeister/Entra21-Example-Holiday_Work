using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("tarefas")]
    public class Tarefa : Base
    {
        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("duracao")]
        public DateTime Duracao { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }
        [Column("categoria_id")]
        public int CategoriaId { get; set; }

        /*[ForeignKey("ProjetoId")]
        public virtual Projeto Projeto { get; set; }
        [Column("projeto_id")]
        public int ProjetoId { get; set; }

        [ForeignKey("UsuarioResponsavelId")]
        public virtual Usuario Usuario { get; set; } 
        [Column("usuario_responsavel_id")]
        public int UsuarioResponsavelId { get; set; }
        */
    }
}
