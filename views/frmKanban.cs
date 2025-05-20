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

        public frmKanban(Utilizador _user)
        {
            user = _user;

            InitializeComponent();

            SetupForm();
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
        }
    }
}
