using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.models
{
    public class TipoTarefa
    {
        public TipoTarefa()
        {

        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public void AddTipoTarefa(TipoTarefa tipoTarefa)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    context.TiposTarefa.Add(tipoTarefa);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao adicionar tipo de tarefa: {ex.Message}");
            }
        }


        public void UpdateTipoTarefa(TipoTarefa tipoTarefa)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    var existingTipoTarefa = context.TiposTarefa.Find(tipoTarefa.Id);
                    if (existingTipoTarefa != null)
                    {
                        existingTipoTarefa.Nome = tipoTarefa.Nome;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao atualizar tipo de tarefa: {ex.Message}");
            }
        }

        public void DeleteTipoTarefa(int id)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    var tipoTarefa = context.TiposTarefa.Find(id);
                    if (tipoTarefa != null)
                    {
                        context.TiposTarefa.Remove(tipoTarefa);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao deletar tipo de tarefa: {ex.Message}");
            }
        }
    }
}
