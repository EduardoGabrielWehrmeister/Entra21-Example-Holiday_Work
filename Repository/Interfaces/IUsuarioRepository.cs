using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ObterTodos();

        int Inserir(Usuario usuario);

        bool Update(Usuario usuario);

        Usuario ObterPeloId(int id);

        bool Delete(int id);

    }
}
