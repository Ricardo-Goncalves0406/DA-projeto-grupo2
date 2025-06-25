using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks.models
{
    public class Gestor : Utilizador
    {
        public Gestor()
        {
        }

        public new int Id { get; set; }
        public bool GereUtilizadores { get; set; }
        public int IdUtilizador { get; set; }

        public Gestor(bool GereUtilizadores, string nome, string username, string Password, int idUtilizador = 0)
        {
            this.GereUtilizadores = GereUtilizadores;
            this.Nome = nome;
            this.Username = Username;
            this.Password = Password;
            this.IdUtilizador = idUtilizador;
        }

        public void AddGestor(Gestor gestor)
        {
            try
            {
                // Valida se o gestor já existe pelo IdUtilizador
                using (var context = new AplicationDBContext())
                {
                    if (context.Gestores.Any(g => g.IdUtilizador == gestor.IdUtilizador))
                    {
                        //MessageBox.Show("Já existe um gestor associado a este utilizador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                using (var context = new AplicationDBContext())
                {
                    context.Gestores.Add(gestor);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao adicionar gestor: {ex.Message}");
            }
        }

        public void UpdateGestor(Gestor gestor)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    // Busca pelo IdUtilizador ou pelo Id da base
                    var existingGestor = context.Gestores.FirstOrDefault(g => g.IdUtilizador == gestor.IdUtilizador);
                    if (existingGestor != null)
                    {
                        existingGestor.Nome = gestor.Nome;
                        existingGestor.Username = gestor.Username;
                        existingGestor.Password = gestor.Password;
                        existingGestor.GereUtilizadores = gestor.GereUtilizadores;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao atualizar gestor: {ex.Message}");
            }
        }

        public void DeleteGestor(int id)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    var gestor = context.Gestores.Find(id);
                    if (gestor != null)
                    {
                        context.Gestores.Remove(gestor);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao deletar gestor: {ex.Message}");
            }
        }

        public List<Gestor> GetAllGestores()
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    return context.Gestores.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao obter todos os gestores: {ex.Message}");
                return new List<Gestor>();
            }
        }

        public Gestor GetGestorById(int id)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    return context.Gestores.Find(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao obter gestor por ID: {ex.Message}");
                return null;
            }
        }

        public Gestor GetGestorByUsername(string username)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    return context.Gestores.FirstOrDefault(g => g.Username == username);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao obter gestor por username: {ex.Message}");
                return null;
            }
        }

        public new List<Utilizador> GetAllUtilizadores()
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
                Console.WriteLine($"Error ao obter todos os utilizadores: {ex.Message}");
                return new List<Utilizador>();
            }
        }
    }
}

  
