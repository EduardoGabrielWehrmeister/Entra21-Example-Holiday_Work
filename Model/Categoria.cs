using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("categorias")]
    public class Categoria : Base
    {
        public Categoria()
        {
            Tarefas = new HashSet<Tarefa>();
        }

        [Column("nome")]
        public string Nome { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
