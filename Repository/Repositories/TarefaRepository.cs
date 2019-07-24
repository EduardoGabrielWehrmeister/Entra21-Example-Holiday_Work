using Model;
using Repository.DataBase;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    /*
    public class TarefaRepository : ITarefaRepository
    {
        public bool Delete(int id)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = "DELETE FROM tarefas WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public int Inserir(Tarefa tarefa)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"INSERT INTO tarefas (
id_usuario, id_projeto, id_categoria, titulo, descricao, duracao) OUTPUT INSERTED.ID VALUES
(@ID_USUARIO, @ID_PROJETO, @ID_CATEGORIA, @TITULO, @DESCRICAO, @DURACAO)";
            command.Parameters.AddWithValue("@ID_USUARIO", tarefa.IdUsuario);
            command.Parameters.AddWithValue("@ID_PROJETO", tarefa.IdProjeto);
            command.Parameters.AddWithValue("@ID_CATEGORIA", tarefa.IdCategoria);
            command.Parameters.AddWithValue("@TITULO", tarefa.Titulo);
            command.Parameters.AddWithValue("@DESCRICAO", tarefa.Descricao);
            command.Parameters.AddWithValue("@DURACAO", tarefa.Duracao);
            int id = Convert.ToInt32(command.ExecuteScalar());
            command.Connection.Close();
            return id;
            

        }

        public Tarefa ObterPeloId(int id)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"SELECT * FROM tarefas WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            command.Connection.Close();

            if(table.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = table.Rows[0];
            Tarefa tarefa = new Tarefa();
            tarefa.Id = Convert.ToInt32(row["id"]);
            tarefa.IdCategoria = Convert.ToInt32(row["id_categoria"]);
            tarefa.IdProjeto = Convert.ToInt32(row["id_projeto"]);
            tarefa.IdUsuario = Convert.ToInt32(row["id_usuario"]);
            tarefa.Titulo = row["titulo"].ToString();
            tarefa.Descricao = row["descricao"].ToString();
            tarefa.Duracao = Convert.ToDateTime(row["duracao"]);
            return tarefa;
        }

        public List<Tarefa> ObterTodos()
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"SELECT
categorias.id AS 'CategoriaId',
categorias.nome AS 'CategoriaNome',

projetos.id AS 'ProjetoId',
projetos.nome AS 'ProjetoNome',

usuarios.id AS 'UsuarioId',
usuarios.nome AS 'UsuarioNome',

tarefas.id AS 'Id',
tarefas.titulo AS 'Titulo',
tarefas.descricao AS 'Descricao',
tarefas.duracao AS 'Duracao'
FROM tarefas
INNER JOIN categorias ON(tarefas.id_categoria = categorias.id)
INNER JOIN projetos ON(tarefas.id_projeto = projetos.id)
INNER JOIN usuarios ON(tarefas.id_usuario =  usuarios.id)";


            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            command.Connection.Close();

            List<Tarefa> tarefas = new List<Tarefa>();

            foreach(DataRow row in table.Rows)
            {
                Tarefa tarefa = new Tarefa();

                tarefa.IdCategoria = Convert.ToInt32(row["CategoriaId"]);
                tarefa.IdProjeto = Convert.ToInt32(row["ProjetoId"]);
                tarefa.IdUsuario = Convert.ToInt32(row["UsuarioId"]);

                tarefa.Id = Convert.ToInt32(row["Id"]);
                tarefa.Titulo = row["Titulo"].ToString();
                tarefa.Descricao = row["Descricao"].ToString();
                tarefa.Duracao = Convert.ToDateTime(row["Duracao"]);

                tarefa.Categoria = new Categoria();
                tarefa.Categoria.Id = Convert.ToInt32(row["CategoriaId"]);
                tarefa.Categoria.Nome = row["CategoriaNome"].ToString();

                tarefa.Projeto = new Projeto();
                tarefa.Projeto.Id = Convert.ToInt32(row["ProjetoId"]);
                tarefa.Projeto.Nome = row["ProjetoNome"].ToString();

                tarefa.Usuario = new Usuario();
                tarefa.Usuario.Id = Convert.ToInt32(row["UsuarioId"]);
                tarefa.Usuario.Nome = row["UsuarioNome"].ToString();
            }
            return tarefas;
        }

        public bool Update(Tarefa tarefa)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"UPDATE tarefas SET
id_categoria = @ID_CATEGORIA,
id_usuario = @ID_USUARIO,
id_projeto = @ID_PROJETO,
titulo = @TITULO,
descicao = @DESCRICAO,
duracao = @DURACAO WHERE id = @ID";

            command.Parameters.AddWithValue("@ID_CATEGORIA", tarefa.IdCategoria);
            command.Parameters.AddWithValue("@ID_USUARIO", tarefa.IdUsuario);
            command.Parameters.AddWithValue("@ID_PROJETO", tarefa.IdProjeto);
            command.Parameters.AddWithValue("@TITULO", tarefa.Titulo);
            command.Parameters.AddWithValue("@DESCRICAO", tarefa.Descricao);
            command.Parameters.AddWithValue("@DURACAO", tarefa.Duracao);
            command.Parameters.AddWithValue("@ID", tarefa.Id);
            int quantidade = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidade == 1;
        }
    }
    */
}
