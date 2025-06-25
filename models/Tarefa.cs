using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.models
{
    public class Tarefa
    {
        public Tarefa()
        {
        }

        public int Id { get; set; }
        public int idGestor { get; set; }
        public int idProgramador { get; set; }
        public int OrdemExecucao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPrevistaInicio { get; set; }
        public DateTime DataPrevistaFim { get; set; }
        public int IdTipoTarefa { get; set; }
        public int StoryPoints { get; set; }
        public DateTime DataRealInicio { get; set; }
        public DateTime DataRealFim { get; set; }
        public DateTime DataCriacao { get; set; }
        public int EstadoAtual { get; set; }

        public void AddTarefa(Tarefa tarefa)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    context.Tarefas.Add(tarefa);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao adicionar tarefa: {ex.Message}");
            }
        }

        public void UpdateTarefa(Tarefa tarefa)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    var existingTarefa = context.Tarefas.Find(tarefa.Id);
                    if (existingTarefa != null)
                    {
                        existingTarefa.Descricao = tarefa.Descricao;
                        existingTarefa.DataPrevistaInicio = tarefa.DataPrevistaInicio;
                        existingTarefa.DataPrevistaFim = tarefa.DataPrevistaFim;
                        existingTarefa.IdTipoTarefa = tarefa.IdTipoTarefa;
                        existingTarefa.StoryPoints = tarefa.StoryPoints;
                        existingTarefa.DataRealInicio = tarefa.DataRealInicio;
                        existingTarefa.DataRealFim = tarefa.DataRealFim;
                        existingTarefa.DataCriacao = tarefa.DataCriacao;
                        existingTarefa.EstadoAtual = tarefa.EstadoAtual;
                        existingTarefa.idGestor = tarefa.idGestor;
                        existingTarefa.idProgramador = tarefa.idProgramador;
                        existingTarefa.OrdemExecucao = tarefa.OrdemExecucao;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao atualizar tarefa: {ex.Message}");
            }
        }

        public void DeleteTarefa(int id)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    var tarefa = context.Tarefas.Find(id);
                    if (tarefa != null)
                    {
                        context.Tarefas.Remove(tarefa);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao deletar tarefa: {ex.Message}");
            }
        }

        public void GetTarefaById(int id)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    var tarefa = context.Tarefas.Find(id);
                    if (tarefa != null)
                    {
                        this.Id = tarefa.Id;
                        this.Descricao = tarefa.Descricao;
                        this.DataPrevistaInicio = tarefa.DataPrevistaInicio;
                        this.DataPrevistaFim = tarefa.DataPrevistaFim;
                        this.IdTipoTarefa = tarefa.IdTipoTarefa;
                        this.StoryPoints = tarefa.StoryPoints;
                        this.DataRealInicio = tarefa.DataRealInicio;
                        this.DataRealFim = tarefa.DataRealFim;
                        this.DataCriacao = tarefa.DataCriacao;
                        this.EstadoAtual = tarefa.EstadoAtual;
                        this.idGestor = tarefa.idGestor;
                        this.idProgramador = tarefa.idProgramador;
                        this.OrdemExecucao = tarefa.OrdemExecucao;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao obter tarefa por ID: {ex.Message}");
            }
        }
    }
}
