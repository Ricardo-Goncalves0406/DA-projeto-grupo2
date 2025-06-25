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
        public int Departamento { get; set; } //O utilizador tem um departamento associado


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

        // Fix for CS0162: Código inacessível detectado
        // The issue is caused by an extra closing parenthesis in the conditional statement inside the AddUser method.
        // This makes part of the code unreachable. Removing the extra parenthesis resolves the issue.

        public bool AddUser(Utilizador user)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    if (context.Utilizadores.Any(u => u.Username == user.Username))
                    {
                        return false; // Utilizador já existe
                    }
                    // Se username, password ou nome forem nulos ou vazios, não adiciona o utilizador
                    if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Nome))
                    {
                        return false; // Dados inválidos
                    }
                    context.Utilizadores.Add(user);
                    context.SaveChanges();
                    return true; // Utilizador criado com sucesso
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao adicionar utilizador: {ex.Message}");
                return false; // Erro ao criar utilizador
            }
        }

        //atualizar utilizador
        public void UpdateUser(Utilizador user)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    var existingUser = context.Utilizadores.Find(user.Id);
                    if (existingUser != null)
                    {
                        existingUser.Nome = user.Nome;
                        existingUser.Username = user.Username;
                        existingUser.Password = user.Password;
                        existingUser.Departamento = user.Departamento;
                        existingUser.IdGestor = user.IdGestor;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao atualizar utilizador: {ex.Message}");
            }
        }

        //eliminar utilizador
        public void DeleteUser(int id)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao eliminar utilizador: {ex.Message}");
            }
        }

        //procurar utilizador por id
        public Utilizador GetUserById(int id)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    return context.Utilizadores.Find(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao procurar utilizador por id: {ex.Message}");
                return null;
            }
        }

        // procurar utilizador por username
        public Utilizador GetUserByUsername(string username)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    return context.Utilizadores.FirstOrDefault(u => u.Username == username);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao procurar utilizador por username: {ex.Message}");
                return null;
            }
        }

        // procurar todos os utilizadores
        public List<Utilizador> GetAllUtilizadores()
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    return context.Utilizadores.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao procurar todos os utilizadores: {ex.Message}");
                return new List<Utilizador>();
            }
        }
    }

}
