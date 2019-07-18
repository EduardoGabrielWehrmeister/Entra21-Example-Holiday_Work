using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("cidades")]
    public class Cidade: Base
    {
        public Cidade()
        {
            Clientes = new  HashSet<Cliente>();
        }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("numero_habitantes")]
        public int NumeroHabitantes { get; set; }

        [ForeignKey("EstadoId")]
        public virtual Estado Estado { get; set; }
        [Column("estado_id")]
        public int EstadoId { get; set; }


        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
