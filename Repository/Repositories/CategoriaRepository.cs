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
    public class CategoriaRepository : ICategoriaRepository
    {
        public bool Delete(int id)
        {
        }

        public int Inserir(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Categoria ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Categoria> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public bool Update(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
