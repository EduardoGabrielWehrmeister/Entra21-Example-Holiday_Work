using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface IClienteRepository
    {
        int Inserir(Cliente cliente);

        bool Delete(int id);

        bool Update(Cliente cliente);

        Cliente ObterPeloId(int id);

        List<Cliente> ObterTodos(string busca);
    }
}
