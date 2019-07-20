using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("usuarios")]
    public class Usuario : Base
    {
        public Usuario()
        {
            Tarefas = new HashSet<Tarefa>();
        }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
