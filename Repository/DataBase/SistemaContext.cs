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
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Estado> Estados { get; set; }     
        public virtual DbSet<Projeto> Projetos { get; set; }       
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
       
    }
}
