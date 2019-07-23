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

        bool Delete(int id);

        bool Update(Categoria categoria);

        List<Categoria> ObterTodos();

        Categoria ObterPeloId(int id);
    }
}
