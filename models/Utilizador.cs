using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.models
{
    public class Utilizador
    {
        // Construtor vazio com o nome da classe
        public Utilizador()
        {

        }


        // Construtor com parâmetros
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        //O programador tem um gestor associado e um idGestor
        public int? IdGestor { get; set; }
        public int Gestores { get; set; }


        public Utilizador(int id, string nome, string username, string password)
        {
            this.Id = id;
            this.Nome = nome;
            this.Username = username;
            this.Password = password;
        }

        //adicionar utilizador
        public void AddUser(Utilizador user)
        {
            using (var context = new AplicationDBContext())
            {
                context.Utilizadores.Add(user);
                context.SaveChanges();
            }

        }

        //atualizar utilizador
        public void UpdateUser(Utilizador user)
        {
            using (var context = new AplicationDBContext())
            {
                var existingUser = context.Utilizadores.Find(user.Id);
                if (existingUser != null)
                {
                    existingUser.Nome = user.Nome;
                    existingUser.Username = user.Username;
                    existingUser.Password = user.Password;
                    context.SaveChanges();
                }
            }
        }

        //eliminar utilizador
        public void DeleteUser(int id)
        {
            using (var context = new AplicationDBContext())
            {
                var user = context.Utilizadores.Find(id);
                if (user != null)
                {
                    context.Utilizadores.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        //procurar utilizador por id
        public Utilizador GetUserById(int id)
        {
            using (var context = new AplicationDBContext())
            {
                return context.Utilizadores.Find(id);
            }
        }
    }   
     
}
