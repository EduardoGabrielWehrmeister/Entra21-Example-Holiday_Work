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
    public class UsuarioRepository : IUsuarioRepository
    {
        public bool Delete(int id)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = "DELETE FROM usuarios WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public int Inserir(Usuario usuario)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"INSERT INTO usuarios (nome, login, senha)
OUTPUT INSERTED.ID VALUES (@NOME, @LOGIN, @SENHA)";
            command.Parameters.AddWithValue("@NOME", usuario.Nome);
            command.Parameters.AddWithValue("@LOGIN", usuario.Login);
            command.Parameters.AddWithValue("@SENHA", usuario.Senha);
            int id = Convert.ToInt32(command.ExecuteScalar());
            command.Connection.Close();
            return id;
        }

        public Usuario ObterPeloId(int id)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"SELECT * FROM usuarios WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            command.Connection.Close();

            if(table.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = table.Rows[0];
            Usuario usuario = new Usuario();
            usuario.Id = Convert.ToInt32(row["id"]);
            usuario.Nome = row["nome"].ToString();
            usuario.Login = row["login"].ToString();
            usuario.Senha = row["senha"].ToString();

            return usuario;
        }

        public List<Usuario> ObterTodos()
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"SELECT * FROM usuarios";

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            List<Usuario> usuarios = new List<Usuario>();
            command.Connection.Close();

            foreach(DataRow row in table.Rows)
            {
                Usuario usuario = new Usuario()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nome = row["nome"].ToString(),
                    Login = row["login"].ToString(),
                    Senha = row["senha"].ToString()
                };
                usuarios.Add(usuario);
            }
            return usuarios;
        }

        public bool Update(Usuario usuario)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"UPDATE usuarios SET 
nome = @NOME, 
login = @LOGIN,
senha = @SENHA
WHERE id = @ID";
            command.Parameters.AddWithValue("@NOME", usuario.Nome);
            command.Parameters.AddWithValue("@LOGIN", usuario.Login);
            command.Parameters.AddWithValue("@SENHA", usuario.Senha);
            int quantidadeAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidadeAfetada == 1;
        }
    }
}
