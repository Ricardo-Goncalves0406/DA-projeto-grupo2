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
                    if(TarefaExists(tarefa.Descricao))
                    {
                        MessageBox.Show("Já existe uma tarefa com essa descrição. Por favor, escolha uma descrição diferente.");
                        return null; // Retorna null se a tarefa já existir
                    }
                    context.Tarefas.Add(tarefa);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Lidar com exceções, como falha na conexão com a base de dados
                var inner = ex.InnerException;
                throw new Exception("Erro ao criar a tarefa: " + ex.Message, inner);
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
            Button cancelButton = new Button()
            {
                Text = "Cancelar",
                Left = 300,
                Width = 100,
                Top = 220
            };
            Button okButton = new Button()
            {
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
                    DataRealInicio = DateTime.Now,
                    DataRealFim = DateTime.Now,
                    idGestor = 0, // Definir o ID do gestor (pode ser alterado posteriormente)
                    idProgramador = 0, // Definir o ID do programador (pode ser alterado posteriormente)
                    OrdemExecucao = 0, // Definir a ordem de execução (pode ser alterado posteriormente)
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

        // Função para popular o ListBox com as tarefas / Tambem deve ser usado para atualizar a lista de tarefas
        // Recebe: 1. ListBox onde as tarefas serão mostradas como parâmetro
        // Enum EstadoTarefa / Vai ser usado para filtrar as tarefas por estado 
        /*
            Existem 3 listbox ToDo, Doing e Done 
            Cada listbox vai receber as tarefas de acordo com o estado da tarefa
            As listbox são identicas, apenas o estado da tarefa é que muda e tambem é o filtro de como a listbox será preenchida/atualizada
         */
        public void UpdateListBox(ListBox listBox, EstadoAtual estadoTarefa)
        {
            listBox.Items.Clear(); // Limpa os itens do ListBox
            try
            {
                using (var context = new AplicationDBContext())
                {
                    // Obtém as tarefas filtradas pelo estado
                    var tarefas = context.Tarefas
                        .Where(t => t.EstadoAtual == (int)estadoTarefa) // Filtra as tarefas pelo estado
                        .ToList(); // Converte para uma lista 
                    // Adiciona as tarefas ao ListBox
                    foreach (var tarefa in tarefas)
                    {
                        listBox.Items.Add(tarefa.Descricao); // Adiciona a descrição da tarefa ao ListBox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar a lista de tarefas: " + ex.Message);
            }
        }

        // Função para atualizar o estado da tarefa
        public void UpdateTarefaState(Tarefa tarefa, EstadoAtual estadoDestino)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    // Busca a tarefa pelo ID
                    var existingTarefa = context.Tarefas.Find(tarefa.id);
                    if (existingTarefa != null)
                    {
                        // Atualiza o estado da tarefa
                        existingTarefa.EstadoAtual = (int)estadoDestino;
                        if (estadoDestino == EstadoAtual.Done) existingTarefa.DataRealFim = DateTime.Now; // Define a data real de fim se o estado for "Done"
                        else if (estadoDestino == EstadoAtual.Going) existingTarefa.DataRealInicio = DateTime.Now; // Define a data real de início se o estado for "Going"
                        context.SaveChanges(); // Salva as alterações no banco de dados
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o estado da tarefa: " + ex.Message);
            }
        }

        // Função para buscar todas as tarefas e retornar uma lista de tarefas
        public List<Tarefa> GetTarefas()
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            try
            {
                using (var context = new AplicationDBContext())
                {
                    // Busca as tarefas do utilizador pelo ID
                    tarefas = context.Tarefas.ToList(); // Converte para uma lista
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar as tarefas: " + ex.Message);
            }
            return tarefas; // Retorna a lista de tarefas
        }

        // Função para buscar uma tarefa por estado
        public List<Tarefa> GetTarefasByEstado(EstadoAtual estado)
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            try
            {
                using (var context = new AplicationDBContext())
                {
                    // Busca as tarefas filtradas pelo estado
                    tarefas = context.Tarefas
                        .Where(t => t.EstadoAtual == (int)estado)
                        .ToList(); // Converte para uma lista
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar as tarefas por estado: " + ex.Message);
            }
            return tarefas; // Retorna a lista de tarefas filtradas
        }

        // Verificar se a tarefa existe
        public bool TarefaExists(string descricao)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    // Verifica se existe uma tarefa com a descrição fornecida
                    return context.Tarefas.Any(t => t.Descricao == descricao);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar a existência da tarefa: " + ex.Message);
                return false; // Retorna falso em caso de erro
            }
        }

        // Exportar tarefas para um arquivo CSV
        public void ExportarTarefasParaCSV(string caminhoArquivo)
        {
            try
            {
                using (var context = new AplicationDBContext())
                {
                    var tarefas = context.Tarefas.ToList(); // Obtém todas as tarefas
                    StringBuilder sb = new StringBuilder(); // Cria um StringBuilder para construir o conteúdo do CSV
                    sb.AppendLine("ID,Descrição,Data Prevista Início,Data Prevista Fim,Story Points,Data Real Início,Data Real Fim,Data Criação,Estado Atual,"); // Cabeçalho do CSV
                    foreach (var tarefa in tarefas) // Itera sobre cada tarefa e adiciona ao StringBuilder
                    {
                        sb.AppendLine($"{tarefa.id},{tarefa.Descricao},{tarefa.DataPrevistaInicio},{tarefa.DataPrevistaFim},{tarefa.StoryPoints},{tarefa.DataRealInicio},{tarefa.DataRealFim},{tarefa.DataCriacao},{tarefa.EstadoAtual}");
                    }
                    System.IO.File.WriteAllText(caminhoArquivo, sb.ToString()); // Escreve o conteúdo no arquivo CSV
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exportar tarefas para CSV: " + ex.Message);
            }
        }
    }
}
