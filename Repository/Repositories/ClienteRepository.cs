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

    public class ClienteRepository : IClienteRepository
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

        public int Inserir(Cliente cliente)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"INSERT INTO clientes (nome, cpf, data_nascimento, numero, complemento,
logradouro, cep, id_cidade) OUTPUT INSERTED.ID VALUES(@NOME, @CPF, @DATA_NASCIMENTO, @NUMERO, @COMPLEMENTO,
@LOGRADOURO, @CEP, @ID_CIDADE)";
            command.Parameters.AddWithValue("@NOME", cliente.Nome);
            command.Parameters.AddWithValue("@CPF", cliente.Cpf);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.DataNascimento);
            command.Parameters.AddWithValue("@NUMERO", cliente.Numero);
            command.Parameters.AddWithValue("@COMPLEMENTO", cliente.Complemento);
            command.Parameters.AddWithValue("@LOGRADOURO", cliente.Logradouro);
            command.Parameters.AddWithValue("@CEP", cliente.Cep);
            command.Parameters.AddWithValue("@ID_CIDADE", cliente.IdCidade);
            int id = Convert.ToInt32(command.ExecuteScalar());
            command.Connection.Close();
            return id;
        }

        public Cliente ObterPeloId(int id)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"SELECT * FROM clientes WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            command.Connection.Close();
            if (table.Rows.Count == 0)
            {
                return null;
            }
            DataRow row = table.Rows[0];
            Cliente cliente = new Cliente();
            cliente.Id = Convert.ToInt32(row["id"]);
            cliente.Nome = row["nome"].ToString();
            cliente.Cpf = row["cpf"].ToString();
            cliente.DataNascimento = Convert.ToDateTime(row["data_nascimento"]);
            cliente.Numero = Convert.ToInt32(row["numero"]);
            cliente.Complemento = row["complemento"].ToString();
            cliente.Logradouro = row["logradouro"].ToString();
            cliente.Cep = row["cep"].ToString();
            cliente.IdCidade = Convert.ToInt32(row["id_cidade"]);
            return cliente;
        }

        public List<Cliente> ObterTodos(string busca)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"SELECT cidades.id AS 'CidadeId', cidades.nome AS 'CidadeNome',
clientes.id AS 'Id',
clientes.nome AS 'Nome',
clientes.cpf AS 'Cpf',
clientes.data_nascimento AS 'DataNascimento',
clientes.numero AS 'Numero',
clientes.complemento AS 'Complemento',
clientes.logradouro AS 'Logradouro',
clientes.cep AS 'Cep' FROM clientes INNER JOIN cidades ON(clientes.id_cidade = cidades.id)";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            List<Cliente> clientes = new List<Cliente>();
            command.Connection.Close();
            foreach (DataRow row in table.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.Id = Convert.ToInt32(row["Id"]);
                cliente.Nome = row["Nome"].ToString();
                cliente.Cpf = row["Cpf"].ToString();
                cliente.DataNascimento = Convert.ToDateTime(row["DataNascimento"]);
                cliente.Numero = Convert.ToInt32(row["Numero"]);
                cliente.Complemento = row["Complemento"].ToString();
                cliente.Logradouro = row["Logradouro"].ToString();
                cliente.Cep = row["Cep"].ToString();
                cliente.IdCidade = Convert.ToInt32(row["CidadeId"]);

                cliente.Cidade = new Cidade();
                cliente.Cidade.Id = Convert.ToInt32(row["CidadeId"]);
                cliente.Cidade.Nome = row["CidadeNome"].ToString();
                clientes.Add(cliente);

            }

            return clientes;
        }

        public bool Update(Cliente cliente)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"UPDATE clientes SET id_cidade = @ID_CIDADE, nome = @NOME, cpf = @CPF,
data_nascimento = @DATA_NASCIMENTO, numero = @NUMERO, complemento = @COMPLEMENTO, logradouro = @LOGRADOURO,
cep = @CEP WHERE id = @ID";
            command.Parameters.AddWithValue("@ID_CIDADE", cliente.IdCidade);
            command.Parameters.AddWithValue("@NOME", cliente.Nome);
            command.Parameters.AddWithValue("@CPF", cliente.Cpf);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.DataNascimento);
            command.Parameters.AddWithValue("@NUMERO", cliente.Numero);
            command.Parameters.AddWithValue("@COMPLEMENTO", cliente.Complemento);
            command.Parameters.AddWithValue("@LOGRADOURO", cliente.Logradouro);
            command.Parameters.AddWithValue("@CEP", cliente.Cep);
            command.Parameters.AddWithValue("@ID", cliente.Id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidadeAfetada == 1;
        }
    }
}
