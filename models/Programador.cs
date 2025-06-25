using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks.models
{
    public class Programador : Utilizador
    {
        public Programador()
        {
        }

        public new int Id { get; set; }
        public NivelExperiencia NivelExperiencia { get; set; }
        public new int IdGestor { get; set; }
        public int IdUtilizador { get; set; } // O programador tem um idUser associado, que é o id do utilizador

        // Fixing the constructor to correctly handle the parameters  
        public Programador(NivelExperiencia nivelExperiencia, int idGestor, int idUtilizador)
        {
            this.NivelExperiencia = nivelExperiencia;
            this.IdGestor = idGestor;
            this.IdUtilizador = idUtilizador;
        }

        public Programador(int id, string nome, string username, string password, NivelExperiencia nivelExperiencia, int idGestor)
            : base(id, nome, username, password)
        {
            this.NivelExperiencia = nivelExperiencia;
            this.IdGestor = idGestor;
        }

        public void AddProgramador(Programador programador)
        {
            try
            {
                // Verifica se o programador já existe pelo IdUtilizador
                using (var context = new AplicationDBContext())
                {
                    if (context.Programadores.Any(p => p.IdUtilizador == programador.IdUtilizador))
                    {
                        MessageBox.Show("Já existe um programador associado a este utilizador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                using (var context = new AplicationDBContext())
                {
                    context.Programadores.Add(programador);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao adicionar programador: {ex.Message}");
            }
        }

        public void UpdateProgramador(Programador programador)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    var existingProgramador = context.Programadores.Find(programador.Id);
                    if (existingProgramador != null)
                    {
                        existingProgramador.Nome = programador.Nome;
                        existingProgramador.Username = programador.Username;
                        existingProgramador.Password = programador.Password;
                        existingProgramador.NivelExperiencia = programador.NivelExperiencia;
                        existingProgramador.IdGestor = programador.IdGestor;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao atualizar programador: {ex.Message}");
            }
        }

        public void DeleteProgramador(int id)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    var programador = context.Programadores.Find(id);
                    if (programador != null)
                    {
                        context.Programadores.Remove(programador);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao deletar programador: {ex.Message}");
            }
        }

        public List<Programador> GetAllProgramadores()
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    return context.Programadores.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao obter programadores: {ex.Message}");
                return new List<Programador>();
            }
        }

        public Programador GetProgramadorById(int id)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    return context.Programadores.Find(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao obter programador por ID: {ex.Message}");
                return null;
            }
        }
    }
}