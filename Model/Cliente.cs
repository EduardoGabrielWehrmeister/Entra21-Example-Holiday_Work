using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  
    public class Cliente: Base
    {

        public string Nome;


        public string Cpf;


        public DateTime DataNascimento;


        public int Numero;


        public string Complemento;


        public string Logradouro;


        public string Cep;


        public int IdCidade;
        public Cidade Cidade;
   
 
    }
}
