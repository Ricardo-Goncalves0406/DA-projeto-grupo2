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
    public partial class frmKanban : Form
    {
        Utilizador user = new Utilizador();

        List<Tarefa> tarefas = new List<Tarefa>();

        TarefaController tarefaController = new TarefaController();

        public void UpdateLists()
        {
            tarefas.Clear();
            tarefas = tarefaController.GetTarefas();
            tarefaController.UpdateListBox(lstTodo, EstadoAtual.Todo);
            tarefaController.UpdateListBox(lstDoing, EstadoAtual.Going);
            tarefaController.UpdateListBox(lstDone, EstadoAtual.Done);
        }

        public frmKanban(Utilizador _user)
        {
            user = _user;

            InitializeComponent();

            SetupForm();
            UpdateLists();
            CheckPerm(user); // Verifica as permissões do utilizador

        }

        public void CheckPerm(Utilizador utilizador)
        {
            // Verifica se o utilizador é um gestor buscando os gestores associados ao utilizador
            Gestor res = null;
            if (utilizador.IdGestor.HasValue)
            {
                Gestor gestor = new Gestor();
                res = gestor.GetGestorById(utilizador.IdGestor.Value);
            }
            if (res != null && res.GereUtilizadores)
            {
                // Se o utilizador é um gestor, habilita o menu de gestão de utilizadores
                utilizadoresToolStripMenuItem.Visible = true;
            }
            else
            {
                // Caso contrário, desabilita o menu de gestão de utilizadores
                utilizadoresToolStripMenuItem.Visible = false;
            }

        }

        private void SetupForm()
        {
            // Bem vindo: <Nome Utilizador> <- Substituir pelo nome do utilizador
            this.label1.Text = "Bem vindo: " + user.Nome;
        }

        private void btNova_Click(object sender, EventArgs e)
        {
            // Criar uma nova tarefa  
            Tarefa novaTarefa = tarefaController.CriarTarefa();
            if (novaTarefa != null)
            {
                this.tarefas.Add(novaTarefa);
            }
            UpdateLists();
        }

        private void btSetDoing_Click(object sender, EventArgs e)
        {
            // Get lstTodo selected item and change its state to Doing (todo -> doing)
            // Tarefa tarefa = tarefas[selectedIndex]; selecionar utilizando o indice não funciona, pois a lista de tarefas é atualizada
            // ou seja deve-se usar a Descrição da tarefa e o nome da tarefa selecionada na lista para
            // Corresponder com a tarefa selecionada e a lista de tarefas
            int selectedIndex = lstTodo.SelectedIndex;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecione uma tarefa para mover para Doing.");
                return;
            }

            // Obtem o nome do item selecionado
            string selectedItem = lstTodo.SelectedItem.ToString();
            // Procura a tarefa correspondente na lista de tarefas
            Tarefa tarefa = tarefas.FirstOrDefault(t => t.Descricao == selectedItem);
            if (tarefa != null)
            {
                // Atualiza o estado da tarefa para Doing
                tarefa.EstadoAtual = (int)EstadoAtual.Going;
                tarefaController.UpdateTarefaState(tarefa, EstadoAtual.Going);
                UpdateLists();
            }
            else
            {
                MessageBox.Show("Tarefa não encontrada.");
            }
        }

        private void btSetTodo_Click(object sender, EventArgs e)
        {
            // Get lstDoing selected item and change its state to Todo (doing -> todo)
            int selectedIndex = lstDoing.SelectedIndex;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecione uma tarefa para mover para Todo.");
                return;
            }

            // Obtem o nome do item selecionado
            string selectedItem = lstDoing.SelectedItem.ToString();
            // Procura a tarefa correspondente na lista de tarefas
            Tarefa tarefa = tarefas.FirstOrDefault(t => t.Descricao == selectedItem);
            if (tarefa != null && selectedIndex != -1)
            {
                // Atualiza o estado da tarefa para Todo
                tarefa.EstadoAtual = (int)EstadoAtual.Todo;
                tarefaController.UpdateTarefaState(tarefa, EstadoAtual.Todo);
                UpdateLists();
            }
            else
            {
                MessageBox.Show("Tarefa não encontrada.");
            }
        }

        private void btSetDone_Click(object sender, EventArgs e)
        {
            // Get lstDoing selected item and change its state to Done (doing -> done)
            int selectedIndex = lstDoing.SelectedIndex;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecione uma tarefa para mover para Done.");
                return;
            }

            // Obtem o nome do item selecionado
            string selectedItem = lstDoing.SelectedItem.ToString();
            // Procura a tarefa correspondente na lista de tarefas
            Tarefa tarefa = tarefas.FirstOrDefault(t => t.Descricao == selectedItem);
            if (tarefa != null)
            {
                // Atualiza o estado da tarefa para Done
                tarefa.EstadoAtual = (int)EstadoAtual.Done;
                tarefa.DataRealFim = DateTime.Now; // Define a data real de fim como agora
                tarefaController.UpdateTarefaState(tarefa, EstadoAtual.Done);
                UpdateLists();
            }
            else
            {
                MessageBox.Show("Tarefa não encontrada.");
            }
        }

        private void tarefasTerminadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir o formulário de tarefas terminadas
            // frmConsultarTarefasConcluidas
            frmConsultarTarefasConcluidas frm = new frmConsultarTarefasConcluidas();
            frm.ShowDialog();
        }

        private void tarefasEmCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir o formulário de tarefas em curso
            // frmConsultaTarefasEmCurso
            frmConsultaTarefasEmCurso frm = new frmConsultaTarefasEmCurso();
            frm.ShowDialog();
        }

        private void exportarParaCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abre um file dialog para salvar o CSV
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.Title = "Salvar Tarefas como CSV";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                tarefaController.ExportarTarefasParaCSV(filePath);
                MessageBox.Show("Tarefas exportadas com sucesso para " + filePath);
            }
        }

        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // frmGereUtilizadores
            frmGereUtilizadores frm = new frmGereUtilizadores();
            frm.ShowDialog();
        }
    }
}
