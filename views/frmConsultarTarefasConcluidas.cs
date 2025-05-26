using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTasks.controllers;
using iTasks.models;

namespace iTasks
{
    public partial class frmConsultarTarefasConcluidas : Form
    {
        List<Tarefa> tarefasConcluidas = new List<Tarefa>();
        TarefaController tarefaController = new TarefaController();
        public frmConsultarTarefasConcluidas()
        {
            InitializeComponent();

            UpdateDataTable();
        }

        public void UpdateDataTable()
        {
            tarefasConcluidas.Clear();
            tarefasConcluidas = tarefaController.GetTarefasByEstado(EstadoAtual.Done);

            // Limpar o DataGridView antes de adicionar novos dados
            gvTarefasConcluidas.Rows.Clear();

            // Definir as colunas do DataGridView
            gvTarefasConcluidas.Columns.Clear();
            gvTarefasConcluidas.Columns.Add("id", "ID");
            gvTarefasConcluidas.Columns.Add("descricao", "Descrição");
            gvTarefasConcluidas.Columns.Add("dataPrevistaInicio", "Data Prevista Início");
            gvTarefasConcluidas.Columns.Add("dataPrevistaFim", "Data Prevista Fim");
            gvTarefasConcluidas.Columns.Add("storyPoints", "Story Points");
            gvTarefasConcluidas.Columns.Add("dataRealInicio", "Data Real Início");
            gvTarefasConcluidas.Columns.Add("dataRealFim", "Data Real Fim");
            gvTarefasConcluidas.Columns.Add("dataCriacao", "Data Criação");

            gvTarefasConcluidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvTarefasConcluidas.AllowUserToAddRows = false; // Impedir que o usuário adicione novas linhas manualmente
            gvTarefasConcluidas.AllowUserToDeleteRows = false; // Impedir que o usuário delete linhas manualmente
            gvTarefasConcluidas.ReadOnly = true; // Definir o DataGridView como somente leitura
            gvTarefasConcluidas.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selecionar a linha inteira
            gvTarefasConcluidas.MultiSelect = false; // Impedir a seleção de múltiplas linhas
            gvTarefasConcluidas.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Habilitar quebra de linha nas células
            gvTarefasConcluidas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centralizar os cabeçalhos das colunas
            gvTarefasConcluidas.RowHeadersVisible = false; // Ocultar os cabeçalhos das linhas

            // Adicionar as tarefas concluídas ao DataGridView
            foreach (var tarefa in tarefasConcluidas)
            {
                gvTarefasConcluidas.Rows.Add(
                    tarefa.id,
                    tarefa.Descricao,
                    tarefa.DataPrevistaInicio.ToShortDateString(),
                    tarefa.DataPrevistaFim.ToShortDateString(),
                    tarefa.StoryPoints,
                    tarefa.DataRealInicio.ToString("dd/MM/yyyy HH:mm:ss"),
                    tarefa.DataRealFim.ToString("dd/MM/yyyy HH:mm:ss"),
                    tarefa.DataCriacao.ToString("dd/MM/yyyy HH:mm:ss")
                );
            }

        }
    }
}
