using Model;
using Repository.DataBase;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
        /*
    public class ClienteRepository : IClienteRepository
    {
        public SistemaContext context;

        public ClienteRepository()
        {
            context = new SistemaContext();
        }

        public bool Delete(int id)
        {
            Cliente cliente = (from x in context.Clientes where x.Id == id select x).FirstOrDefault();
            if (cliente == null)
            {
                return false;
            }
            cliente.RegistroAtivo = false;
            context.SaveChanges();
            return true;
        }

        public int Inserir(Cliente cliente)
        {
            cliente.DataCriacao = DateTime.Now;
            context.Clientes.Add(cliente);
            context.SaveChanges();
            return cliente.Id;
        }

        public Cliente ObterPeloId(int id)
        {
            return (from x in context.Clientes where x.Id == id select x).FirstOrDefault();
        }

        public List<Cliente> ObterTodos(int idCidade)
        {
            return context.Clientes.Include("Cidade").Where(x => x.IdCidade == idCidade).ToList();
        }

        public List<Cliente> ObterTodos(string busca)
        {
            return (from x in context.Clientes
                    where x.RegistroAtivo == true &&
                    (x.Nome.Contains(busca) ||
                    x.Cpf.Contains(busca) ||
                    x.Cidade.Nome.Contains(busca))
                    orderby x.Nome
                    select x).ToList();
        }

        public bool Update(Cliente cliente)
        {
            Cliente clienteOriginal = (from x in context.Clientes where x.Id == x.Id select x).FirstOrDefault();
            if (clienteOriginal == null)
            {
                return false;
            }
            clienteOriginal.IdCidade = cliente.IdCidade;
            clienteOriginal.Nome = cliente.Nome;
            clienteOriginal.Cpf = cliente.Cpf;
            clienteOriginal.DataNascimento = cliente.DataNascimento;
            clienteOriginal.Numero = cliente.Numero;
            clienteOriginal.Complemento = cliente.Complemento;
            clienteOriginal.Logradouro = cliente.Logradouro;
            clienteOriginal.Cep = cliente.Cep;
            context.SaveChanges();
            return true;
        }

    }
    */
}
