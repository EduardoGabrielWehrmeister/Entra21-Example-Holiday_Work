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
    
    public class ProjetoRepository : IProjetoRepository
    {
                
        public bool Delete(int id)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = "DELETE FROM cidades WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public int Inserir(Projeto projeto)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"INSERT INTO projetos (nome, data_criacao_projeto, data_finalizacao, id_cliente)
OUTPUT INSERTED.ID VALUES(@NOME, @DATA_CRIACAO_PROJETO, @DATA_FINALIZACAO, @ID_CLIENTE)";
            command.Parameters.AddWithValue("@NOME", projeto.Nome);
            command.Parameters.AddWithValue("@DATA_CRIACAO_PROJETO", projeto.DataCriacaoProjeto);
            command.Parameters.AddWithValue("@DATA_FINALIZACAO", projeto.DataFinalizacao);
            command.Parameters.AddWithValue("@ID_CLIENTE", projeto.IdCliente);
            int id = Convert.ToInt32(command.ExecuteScalar());
            command.Connection.Close();
            return id;
        }

        public Projeto ObterPeloId(int id)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"SELECT * FROM projetos WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            command.Connection.Close();
            if (table.Rows.Count == 0)
            {
                return null;
            }
            DataRow row = table.Rows[0];
            Projeto projeto = new Projeto();
            projeto.Id = Convert.ToInt32(row["id"]);
            projeto.Nome = row["nome"].ToString();
            projeto.DataCriacaoProjeto = Convert.ToDateTime(row["data_criacao_projeto"]);
            projeto.DataFinalizacao = Convert.ToDateTime(row["data_finalizacao"]);
            projeto.IdCliente = Convert.ToInt32(row["id_cliente"]);
            return projeto;

        }

        public List<Projeto> ObterTodos(string busca)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"SELECT clientes.id AS 'ClienteId', clientes.nome AS 'ClienteNome',
projetos.id AS 'Id',
projetos.nome AS 'Nome',
projetos.data_finalizacao AS 'DataFinalizacao',
projetos.data_criacao_projeto AS 'DataCriacaoProjeto' FROM projetos INNER JOIN clientes ON(projetos.id_cliente = clientes.id)";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            List<Projeto> projetos = new List<Projeto>();
            command.Connection.Close();
            foreach(DataRow row in table.Rows)
            {
                Projeto projeto = new Projeto();
                projeto.Id = Convert.ToInt32(row["Id"]);
                projeto.Nome = row["Nome"].ToString();
                projeto.DataCriacaoProjeto = Convert.ToDateTime(row["DataCriacaoProjeto"]);
                projeto.DataFinalizacao = Convert.ToDateTime(row["DataFinalizacao"]);
                projeto.IdCliente = Convert.ToInt32(row["ClienteId"]);

                projeto.Cliente = new Cliente();
                projeto.Cliente.Id = Convert.ToInt32(row["ClienteId"]);
                projeto.Cliente.Nome = row["ClienteNome"].ToString();
                projetos.Add(projeto);
            }

            return projetos;
        }

        public bool Update(Projeto projeto)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"UPDATE projetos SET id_cliente = @ID_CLIENTE, nome = @NOME, data_criacao_projeto = @DATA_CRIACAO_PROJETO,
data_finalizacao = @DATA_FINALIZACAO WHERE id = @ID";
            command.Parameters.AddWithValue("@NOME", projeto.Nome);
            command.Parameters.AddWithValue("@DATA_CRIACAO_PROJETO", projeto.DataCriacaoProjeto);
            command.Parameters.AddWithValue("@DATA_FINALIZACAO", projeto.DataFinalizacao);
            command.Parameters.AddWithValue("@ID_CLIENTE", projeto.IdCliente);
            command.Parameters.AddWithValue("@ID", projeto.Id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidadeAfetada == 1;
        }
    }
    
}
