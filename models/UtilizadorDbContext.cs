using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace iTasks.models
{
    
    public class UtilizadorDbContext: DbContext
    {
        public UtilizadorDbContext(DbContextOptions<UtilizadorDbContext> options) : base(options) { }

        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<TipoTarefa> TiposTarefa { get; set; }


    }
}
