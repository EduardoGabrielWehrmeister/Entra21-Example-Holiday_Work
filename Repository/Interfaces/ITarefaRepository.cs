using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface ITarefaRepository
    {
        int Inserir(Tarefa tarefa);

        bool Delete(int id);

        bool Update(Tarefa tarefa);

        Tarefa ObterPeloId(int id);

        List<Tarefa> ObterTodos();
    }
}
