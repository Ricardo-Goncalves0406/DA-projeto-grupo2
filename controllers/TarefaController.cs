using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using iTasks.models;
using System.Windows.Forms;


namespace iTasks.controllers
{
    /*  
        Esta classe é responsável por efetuar as operações CRUD (Create, Read, Update, Delete) para a entidade Tarefa.  
        */
    public class TarefaController
    {
        // Criar uma nova tarefa  
        public Tarefa CriarTarefa()
        {
            // Abre o prompt dialog para criar uma nova tarefa
            Tarefa tarefa = CriarTarefaPrompt();
            if (tarefa == null)
            {
                // Se o usuário cancelar o prompt, não faz nada
                return null;
            }

            // Adiciona a nova tarefa à base de dados
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
                // Lidar com exceções, como falha na conexão com a base de dados
                MessageBox.Show("Erro ao criar tarefa: " + ex.Message);
            }

            return tarefa;
        }

        // Cria um prompt dialog para criar uma nova tarefa e retorna a tarefa criada
        public Tarefa CriarTarefaPrompt()
        {
            /*
             * Dados nessesarios para criar uma nova tarefa:
             existingTarefa.Descricao = tarefa.Descricao;
            existingTarefa.DataPrevistaInicio = tarefa.DataPrevistaInicio;
            existingTarefa.DataPrevistaFim = tarefa.DataPrevistaFim;
            existingTarefa.IdTipoTarefa = tarefa.IdTipoTarefa;
            existingTarefa.StoryPoints = tarefa.StoryPoints;
            existingTarefa.DataRealInicio = tarefa.DataRealInicio;
            existingTarefa.DataRealFim = tarefa.DataRealFim;
            existingTarefa.DataCriacao = tarefa.DataCriacao;
            existingTarefa.EstadoAtual = tarefa.EstadoAtual;
             */

            Form prompt = new Form()
            {
                Width = 500,
                Height = 300,
                Text = "Criar Nova Tarefa",
                StartPosition = FormStartPosition.CenterScreen
            };

            //Instancia os componentes do formulário
            Label descricaoLabel = new Label() { Left = 50, Top = 20, Text = "Descrição" };
            TextBox descricaoTextBox = new TextBox() { Left = 150, Top = 20, Width = 300 };
            Label dataPrevistaInicioLabel = new Label() { Left = 50, Top = 60, Text = "Data Prevista Início" };
            DateTimePicker dataPrevistaInicioPicker = new DateTimePicker() { Left = 150, Top = 60, Width = 300 };
            Label dataPrevistaFimLabel = new Label() { Left = 50, Top = 100, Text = "Data Prevista Fim" };
            DateTimePicker dataPrevistaFimPicker = new DateTimePicker() { Left = 150, Top = 100, Width = 300 };
            Label idTipoTarefaLabel = new Label() { Left = 50, Top = 140, Text = "ID Tipo Tarefa" };
            TextBox idTipoTarefaTextBox = new TextBox() { Left = 150, Top = 140, Width = 300 };
            Label storyPointsLabel = new Label() { Left = 50, Top = 180, Text = "Story Points" };
            TextBox storyPointsTextBox = new TextBox() { Left = 150, Top = 180, Width = 300 };
            Button confirmButton = new Button() { Text = "Criar", Left = 150, Width = 100, Top = 220 };
            Button cancelButton = new Button() {
                Text = "Cancelar",
                Left = 300,
                Width = 100,
                Top = 220
            };
            Button okButton = new Button() {
                Text = "OK",
                Left = 300,
                Width = 100,
                Top = 220
            };

            Tarefa novaTarefa = null;

            // Cria os eventos para os botões de cancelar e ok
            confirmButton.Click += (sender, e) =>
            {
                // Validar os dados de entrada
                if (string.IsNullOrWhiteSpace(descricaoTextBox.Text) ||
                    string.IsNullOrWhiteSpace(idTipoTarefaTextBox.Text) ||
                    string.IsNullOrWhiteSpace(storyPointsTextBox.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos.");
                    return;
                }
                // Criar a nova tarefa
                novaTarefa = new Tarefa()
                {
                    Descricao = descricaoTextBox.Text,
                    DataPrevistaInicio = dataPrevistaInicioPicker.Value,
                    DataPrevistaFim = dataPrevistaFimPicker.Value,
                    IdTipoTarefa = int.Parse(idTipoTarefaTextBox.Text),
                    StoryPoints = int.Parse(storyPointsTextBox.Text),
                    DataCriacao = DateTime.Now,
                    EstadoAtual = 0 // Definir o estado inicial da tarefa
                };
                prompt.Close();
            };

            // Adiciona os eventos para os botões de cancelar e ok dentro do formulário criado
            cancelButton.Click += (sender, e) => { prompt.Close(); };
            okButton.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(descricaoLabel);
            prompt.Controls.Add(descricaoTextBox);
            prompt.Controls.Add(dataPrevistaInicioLabel);
            prompt.Controls.Add(dataPrevistaInicioPicker);
            prompt.Controls.Add(dataPrevistaFimLabel);
            prompt.Controls.Add(dataPrevistaFimPicker);
            prompt.Controls.Add(idTipoTarefaLabel);
            prompt.Controls.Add(idTipoTarefaTextBox);
            prompt.Controls.Add(storyPointsLabel);
            prompt.Controls.Add(storyPointsTextBox);
            prompt.Controls.Add(confirmButton);
            prompt.Controls.Add(cancelButton);
            prompt.Controls.Add(okButton);
            prompt.AcceptButton = confirmButton;
            prompt.CancelButton = cancelButton;
            prompt.ShowDialog();
            // Retornar a nova tarefa criada
            if (novaTarefa != null)
            {
                return novaTarefa;
            }
            else
            {
                return null;
            }
        }
    }
}
