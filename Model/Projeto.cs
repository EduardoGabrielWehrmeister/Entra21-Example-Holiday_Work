using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    
    public class Projeto
    {
        public int Id;

        public string Nome;

        public DateTime DataCriacaoProjeto;

        public DateTime DataFinalizacao;

        public int IdCliente;

        public Cliente Cliente;



    }
}
