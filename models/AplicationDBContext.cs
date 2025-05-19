using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iTasks.models
{
    
    public class AplicationDBContext: DbContext
    {
        
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<TipoTarefa> TiposTarefa { get; set; }


    }
}
