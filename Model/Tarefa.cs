using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    
    public class Tarefa
    {
        public int Id;
        public string Titulo;
        public string Descricao;
        public DateTime Duracao;

        public int IdUsuario;
        public Usuario Usuario;

        public int IdProjeto;
        public Projeto Projeto;

        public int IdCategoria;
        public Categoria Categoria;
    }
}
