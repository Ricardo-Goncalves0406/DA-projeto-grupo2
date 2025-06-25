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
    public partial class frmDetalhesTarefa : Form
    {
        private Tarefa tarefa;
        private TarefaController tarefaController = new TarefaController();

        public frmDetalhesTarefa(Tarefa _tarefa)
        {
            InitializeComponent();
            LoadTarefaDetails(_tarefa);
        }

        // Método para carregar os detalhes da tarefa no formulário
        public void LoadTarefaDetails(Tarefa _tarefa)
        {
            if (_tarefa != null)
            {
                this.txtId.Text = _tarefa.Id.ToString();
                this.txtEstado.Text = _tarefa.EstadoAtual.ToString();
                this.txtDataRealini.Text = _tarefa.DataRealInicio.ToString("dd/MM/yyyy HH:mm:ss");
                this.txtdataRealFim.Text = _tarefa.DataRealFim.ToString("dd/MM/yyyy HH:mm:ss");
                this.txtDesc.Text = _tarefa.Descricao;
                this.cbTipoTarefa.Text = _tarefa.IdTipoTarefa.ToString();
                this.cbProgramador.Text = _tarefa.idProgramador.ToString();
                this.txtOrdem.Text = _tarefa.OrdemExecucao.ToString();
                this.txtStoryPoints.Text = _tarefa.StoryPoints.ToString();
                this.dtInicio.Text = _tarefa.DataPrevistaInicio.ToString("dd/MM/yyyy");
                this.dtFim.Text = _tarefa.DataPrevistaFim.ToString("dd/MM/yyyy");

                tarefa = _tarefa; // Armazenar a tarefa para atualizações futuras
            }
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            // Atualizar os detalhes da tarefa
            if (this.tarefa != null)
            {
                Tarefa newTarefa = new Tarefa();

                newTarefa.Descricao = txtDesc.Text;
                newTarefa.IdTipoTarefa = int.Parse(cbTipoTarefa.Text);
                newTarefa.idProgramador = int.Parse(cbProgramador.Text);
                newTarefa.OrdemExecucao = int.Parse(txtOrdem.Text);
                newTarefa.StoryPoints = int.Parse(txtStoryPoints.Text);
                newTarefa.DataPrevistaInicio = DateTime.Parse(dtInicio.Text);
                newTarefa.DataPrevistaFim = DateTime.Parse(dtFim.Text);
                newTarefa.Id = tarefa.Id; // Manter o ID da tarefa existente para atualização
                newTarefa.DataRealInicio = tarefa.DataRealInicio; // Manter os dados reais de início e fim
                newTarefa.DataRealFim = tarefa.DataRealFim;
                newTarefa.DataCriacao = tarefa.DataCriacao; // Manter a data de criação
                newTarefa.EstadoAtual = tarefa.EstadoAtual; // Manter o estado atual da tarefa
                newTarefa.idGestor = tarefa.idGestor; // Manter o ID do gestor

                // Chamar o método de atualização do controlador
                //tarefaController.UpdateTarefa(tarefa);
                newTarefa.UpdateTarefa(newTarefa);

                MessageBox.Show("Tarefa atualizada com sucesso!");
            }
            else
            {
                MessageBox.Show("Nenhuma tarefa selecionada para atualizar.");
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            // Fechar o formulário
            this.Close();
        }
    }
}
