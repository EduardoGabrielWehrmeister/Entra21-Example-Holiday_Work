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
    public class ProjetoRepository : IProjetoRepository
    {

        private SistemaContext context;
        public ProjetoRepository()
        {
            context = new SistemaContext();
        }
        public bool Delete(int id)
        {
            Projeto projeto = (from x in context.Projetos where x.Id == id select x).FirstOrDefault();
            if(projeto == null)
            {
                return false;
            }
            projeto.RegistroAtivo = false;
            context.SaveChanges();
            return true;
        }

        public int Inserir(Projeto projeto)
        {
            projeto.DataCriacao = DateTime.Now;
            context.Projetos.Add(projeto);
            context.SaveChanges();
            return projeto.Id;
        }

        public Projeto ObterPeloId(int id)
        {
            return (from x in context.Projetos where x.Id == id select x).FirstOrDefault();

        }

        public List<Projeto> ObterTodos(int idCliente)
        {
            return context.Projetos.Include("Cliente").Where(x => x.IdCliente == idCliente).ToList();

        }
        public List<Projeto> ObterTodos(string busca)
        {

            return (from x in context.Projetos
                    where x.RegistroAtivo == true &&
(x.Nome.Contains(busca) ||
x.Cliente.Nome.Contains(busca))
                    orderby x.Nome
                    select x).ToList();
        }

        public bool Update(Projeto projeto)
        {
            Projeto projetoOriginal = (from x in context.Projetos where x.Id == x.Id select x).FirstOrDefault();
            if (projetoOriginal == null)
            {
                return false;
            }
            projetoOriginal.Nome = projeto.Nome;
            projetoOriginal.DataCriacaoProjeto = projeto.DataCriacaoProjeto;
            projetoOriginal.DataFinalizaca = projeto.DataFinalizaca;
            projetoOriginal.IdCliente = projeto.IdCliente;
            context.SaveChanges();
            return true;
        }
    }
    */
}
