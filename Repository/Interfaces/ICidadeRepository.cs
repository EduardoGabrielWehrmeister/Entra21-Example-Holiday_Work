using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface ICidadeRepository
    {
        int Inserir(Cidade cidade);

        List<Cidade> ObterTodos(string busca);

        Cidade ObterPeloId(int id);

        bool Delete(int id);

        bool Update(Cidade cidade);
    }
}
