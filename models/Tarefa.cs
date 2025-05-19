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

        public int id { get; set; }
        public int idGestor { get; set; }
        public int idProgramador { get; set; }
        public int OrdemExecucao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPrevistaInicio { get; set; }
        public DateTime DataPrevistaFim { get; set; }
        public int IdTipoTarefa { get; set; }
        public int StoryPoints { get; set; }
        public int DataRealInicio { get; set; }
        public int DataRealFim { get; set; }
        public int DataCriacao { get; set; }
        public int EstadoAtual { get; set; }



        public void AddTarefa(Tarefa tarefa)
        {
            using (var context = new AplicationDBContext())
            {
                context.Tarefas.Add(tarefa);
                context.SaveChanges();
            }
        }

        public void UpdateTarefa(Tarefa tarefa)
        {
            using (var context = new AplicationDBContext())
            {
                var existingTarefa = context.Tarefas.Find(tarefa.id);
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
                    context.SaveChanges();
                }
            }
        }

        public void DeleteTarefa(int id)
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

        public void GetTarefaById(int id)
        {
            using (var context = new AplicationDBContext())
            {
                var tarefa = context.Tarefas.Find(id);
                if (tarefa != null)
                {
                    // Do something with the tarefa
                }
            }
        }


    }
}
