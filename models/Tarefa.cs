using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.models
{
    class Tarefa
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


    }
}
