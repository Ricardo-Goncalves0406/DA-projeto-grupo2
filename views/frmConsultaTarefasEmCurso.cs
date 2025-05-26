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
    public partial class frmConsultaTarefasEmCurso : Form
    {
        List<Tarefa> tarefasEmCurso = new List<Tarefa>();
        TarefaController tarefaController = new TarefaController();

        public frmConsultaTarefasEmCurso()
        {
            InitializeComponent();
            UpdateDataTable();
        }

        private void UpdateDataTable()
        {
            tarefasEmCurso.Clear();
            tarefasEmCurso = tarefaController.GetTarefasByEstado(EstadoAtual.Going);

            // Limpar o DataGridView antes de adicionar novos dados
            gvTarefasEmCurso.Rows.Clear();

            // Definir as colunas do DataGridView
            gvTarefasEmCurso.Columns.Clear();
            gvTarefasEmCurso.Columns.Add("id", "ID");
            gvTarefasEmCurso.Columns.Add("descricao", "Descrição");
            gvTarefasEmCurso.Columns.Add("dataPrevistaInicio", "Data Prevista Início");
            gvTarefasEmCurso.Columns.Add("dataPrevistaFim", "Data Prevista Fim");
            gvTarefasEmCurso.Columns.Add("storyPoints", "Story Points");
            gvTarefasEmCurso.Columns.Add("dataRealInicio", "Data Real Início");
            gvTarefasEmCurso.Columns.Add("dataRealFim", "Data Real Fim");
            gvTarefasEmCurso.Columns.Add("dataCriacao", "Data Criação");

            gvTarefasEmCurso.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvTarefasEmCurso.AllowUserToAddRows = false; // Impedir que o usuário adicione novas linhas manualmente
            gvTarefasEmCurso.AllowUserToDeleteRows = false; // Impedir que o usuário delete linhas manualmente
            gvTarefasEmCurso.ReadOnly = true; // Definir o DataGridView como somente leitura
            gvTarefasEmCurso.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selecionar a linha inteira
            gvTarefasEmCurso.MultiSelect = false; // Impedir a seleção de múltiplas linhas
            gvTarefasEmCurso.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Habilitar quebra de linha nas células
            gvTarefasEmCurso.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centralizar os cabeçalhos das colunas
            gvTarefasEmCurso.RowHeadersVisible = false; // Ocultar os cabeçalhos das linhas

            // Adicionar as tarefas concluídas ao DataGridView
            foreach (var tarefa in tarefasEmCurso)
            {
                gvTarefasEmCurso.Rows.Add(
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

        private void gvTarefasEmCurso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtem a tarefa selecionada e abre o formulário de Gestão de Tarefas
            if (e.RowIndex >= 0 && e.RowIndex < gvTarefasEmCurso.Rows.Count)
            {
                int tarefaId = Convert.ToInt32(gvTarefasEmCurso.Rows[e.RowIndex].Cells["id"].Value);
                Tarefa tarefaSelecionada = tarefasEmCurso.FirstOrDefault(t => t.id == tarefaId);
                if (tarefaSelecionada != null)
                {
                    frmDetalhesTarefa frmDetalhes = new frmDetalhesTarefa(tarefaSelecionada);
                    frmDetalhes.ShowDialog();
                    UpdateDataTable(); // Atualiza a tabela após fechar o formulário de detalhes
                }
            }
        }
    }
}
