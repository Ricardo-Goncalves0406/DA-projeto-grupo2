using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace iTasks.models
{

    public class AplicationDBContext : DbContext
    {
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Gestor> Gestores { get; set; } // Adicione esta linha
        public DbSet<Programador> Programadores { get; set; } // Adicione esta linha
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<TipoTarefa> TiposTarefa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remova qualquer configuração explícita para Programador e Gestor
            // e configure apenas a entidade base Utilizador com TPT (Table Per Type)
            modelBuilder.Entity<Utilizador>()
                .HasKey(u => u.Id)
                .ToTable("Utilizadores");

            modelBuilder.Entity<Programador>()
                .ToTable("Programadores");

            modelBuilder.Entity<Gestor>()
                .ToTable("Gestores");

            base.OnModelCreating(modelBuilder);
        }
    }
}
