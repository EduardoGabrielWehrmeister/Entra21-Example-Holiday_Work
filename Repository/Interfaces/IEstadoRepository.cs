using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface IEstadoRepository
    {
        List<Estado> ObterTodos(string busca);

        int Inserir(Estado estado);

        bool Update(Estado estado);

        bool Delete(int id);

        Estado ObterPeloId(int id);
    }
}
