using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface ICategoriaRepository
    {
        int Inserir(Categoria categoria);

        bool Apagar(int id);

        bool Alterar(Categoria categoria);

        List<Categoria> ObterTodos(string busca);

        Categoria ObterPeloId(int id);
    }
}
