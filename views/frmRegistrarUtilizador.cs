using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTasks.models;

namespace iTasks.views
{
    public partial class frmRegistrarUtilizador : Form
    {
        public frmRegistrarUtilizador()
        {
            InitializeComponent();

            
        }

        public void LoadTipos()
        {
            this.lb_TipoUser.Items.Clear();
            this.lb_TipoUser.Items.Add("Gestor");
            this.lb_TipoUser.Items.Add("Programador");
            this.lb_TipoUser.Items.Add("Utilizador Comum");

            /*
             IT,
        Marketing,
        Admistração
             */
            this.lb_Departamento.Items.Clear();
            this.lb_Departamento.Items.Add("IT");
            this.lb_Departamento.Items.Add("Marketing");
            this.lb_Departamento.Items.Add("Admistração");
            this.lb_TipoUser.SelectedIndex = 0; // Seleciona o primeiro item por padrão
            this.lb_Departamento.SelectedIndex = 0; // Seleciona o primeiro item por padrão
        }

        public bool CriarUser()
        {
            if (this.tb_Password.Text == "" || this.tb_Username.Text == "")
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return false;
            }
            if (this.lb_TipoUser.SelectedItem == null)
            {
                MessageBox.Show("Selecione um tipo de utilizador.");
                return false;
            }
            string tipo = this.lb_TipoUser.SelectedItem.ToString();

            // Verifica se já existe um utilizador com este username ANTES de tentar criar
            Utilizador verificaUsuario = new Utilizador();
            Utilizador usuarioExistente = verificaUsuario.GetUserByUsername(this.tb_Username.Text);
            if (usuarioExistente != null)
            {
                MessageBox.Show("Já existe um utilizador com este username. Escolha outro username.");
                return false;
            }

            // Cria um novo utilizador com os dados fornecidos
            models.Utilizador novoUtilizador = new models.Utilizador
            {
                Nome = this.tb_Nome.Text,
                Username = this.tb_Username.Text,
                Password = this.tb_Password.Text,
                Departamento = (int)Enum.Parse(typeof(models.Departamento), this.lb_Departamento.SelectedItem.ToString())
            };
            
            // Cria o utilizador na base de dados
            bool sucesso = novoUtilizador.AddUser(novoUtilizador);
            if (!sucesso)
            {
                MessageBox.Show("Erro ao criar utilizador. O username pode já existir.");
                return false;
            }

            // Busca o utilizador recém-criado para obter o ID gerado
            Utilizador _user = novoUtilizador.GetUserByUsername(novoUtilizador.Username);
            if (_user == null)
            {
                MessageBox.Show("Erro ao criar utilizador. Verifique os dados e tente novamente.");
                return false;
            }

            // Cria as tabelas relacionadas ao utilizador (Gestor, Programador) Utilizador Comun é apenas um utilizador comum, não tem tabela associada
            if ( tipo == "Gestor")
            {
                models.Gestor novoGestor = new models.Gestor
                {
                    IdUtilizador = _user.Id,
                    GereUtilizadores = false // Valor padrão
                };
                novoGestor.AddGestor(novoGestor);
            }
            else if (tipo == "Programador")
            {
                models.Programador novoProgramador = new models.Programador
                {
                    Departamento = novoUtilizador.Departamento,
                    IdUtilizador = _user.Id,
                    NivelExperiencia = models.NivelExperiencia.Junior // Valor padrão
                };
                novoProgramador.AddProgramador(novoProgramador);
            }
            
            return true; // Sucesso
        }

        private void btn_CreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                bool sucesso = CriarUser();
                if (sucesso)
                {
                    MessageBox.Show("Utilizador criado com sucesso!");
                    this.Close(); // Fecha o formulário após a criação do utilizador
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar utilizador: {ex.Message}");
            }
        }
    }
}
