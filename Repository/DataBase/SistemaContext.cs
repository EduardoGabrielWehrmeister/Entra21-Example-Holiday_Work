using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataBase
{
    public class SistemaContext : DbContext
    {
        public SistemaContext() : base("DefaultConnection")
        {

        }

        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
    }
}
