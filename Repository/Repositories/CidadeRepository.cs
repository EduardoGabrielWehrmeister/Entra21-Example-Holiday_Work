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
    public class CidadeRepository : ICidadeRepository
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

        public List<Cidade> ObterTodos(string busca)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"SELECT estados.id AS 'EstadoId', estados.nome AS 'EstadoNome',
cidades.id AS 'Id',
cidades.nome AS 'Nome',
cidades.numero_habitantes AS 'NumeroHabitantes' FROM cidades INNER JOIN estados ON(cidades.estado_id = estados.id)";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            List<Cidade> cidades = new List<Cidade>();
            foreach(DataRow row in table.Rows)
            {
                Cidade cidade = new Cidade();
                cidade.Id = Convert.ToInt32(row["Id"]);
                cidade.EstadoId = Convert.ToInt32(row["EstadoId"]);
                cidade.Nome = row["Nome"].ToString();
                cidade.NumeroHabitantes = Convert.ToInt32(row["NumeroHabitantes"]);

                cidade.Estado = new Estado();
                cidade.Estado.Id = Convert.ToInt32(row["EstadoId"]);
                cidade.Estado.Nome = row["EstadoNome"].ToString();
                cidades.Add(cidade);
            }
            command.Connection.Close();
            return cidades;

        }

        public int Inserir(Cidade cidade)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"INSERT INTO cidades (nome, numero_habitantes, estado_id)
OUTPUT INSERTED.ID VALUES(@NOME, @NUMERO_HABITANTES, @ESTADO_ID)";
            command.Parameters.AddWithValue("@NOME", cidade.Nome);
            command.Parameters.AddWithValue("@NUMERO_HABITANTES", cidade.NumeroHabitantes);
            command.Parameters.AddWithValue("@ESTADO_ID", cidade.EstadoId);
            int id = Convert.ToInt32(command.ExecuteScalar());
            command.Connection.Close();
            return id;
        }

        public Cidade ObterPeloId(int id)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"SELECT * FROM cidades WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            command.Connection.Close();
            if (table.Rows.Count == 0)
            {
                return null;
            }
            DataRow row = table.Rows[0];
            Cidade cidade = new Cidade();
            cidade.Id = Convert.ToInt32(row["id"]);
            cidade.Nome = row["nome"].ToString();
            cidade.NumeroHabitantes = Convert.ToInt32(row["numero_habitantes"]);
            cidade.EstadoId = Convert.ToInt32(row["estado_id"]);

            return cidade;
        }

        public bool Update(Cidade cidade)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"UPDATE cidades SET estado_id = @ESTADO_ID, nome = @NOME,
numero_habitantes = @NUMERO_HABITANTES WHERE id = @ID";
            command.Parameters.AddWithValue("@ESTADO_ID", cidade.EstadoId);
            command.Parameters.AddWithValue("@NOME", cidade.Nome);
            command.Parameters.AddWithValue("@NUMERO_HABITANTES", cidade.NumeroHabitantes);
            command.Parameters.AddWithValue("@ID", cidade.Id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidadeAfetada == 1;
        }

    }
}
