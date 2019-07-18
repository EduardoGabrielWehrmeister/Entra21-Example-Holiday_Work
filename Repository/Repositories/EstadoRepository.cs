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
    public class EstadoRepository : IEstadoRepository
    {
        public SistemaContext context;

        public EstadoRepository()
        {
            context = new SistemaContext();
        }

        public bool Delete(int id)
        {
            Estado estado = (from x in context.Estados
                             where x.Id == id
                             select x).FirstOrDefault();
            if (estado == null)
            {
                return false;
            }

            estado.RegistroAtivo = false;
            context.SaveChanges();
            return true;
        }

        public int Inserir(Estado estado)
        {
            estado.DataCriacao = DateTime.Now;
            context.Estados.Add(estado);
            context.SaveChanges();
            return estado.Id;
        }

        public Estado ObterPeloId(int id)
        {
            return (from x in context.Estados where x.Id == id select x).FirstOrDefault();
        }

        public List<Estado> ObterTodos(string busca)
        {
            return (from x in context.Estados
                    where
                    x.RegistroAtivo == true && 
                    (x.Nome.Contains(busca) ||
                     x.Sigla.Contains(busca))
                    orderby x.Nome
                    select x).ToList();
        }

        public bool Update(Estado estado)
        {
            Estado estadoOriginal = (from x in context.Estados
                                     where x.Id == x.Id
                                     select x).FirstOrDefault();
            if (estadoOriginal == null)
            {
                return false;
            }

            estadoOriginal.Nome = estado.Nome;
            estadoOriginal.Sigla = estado.Sigla;
            context.SaveChanges();
            return true;
        }
    }
}
