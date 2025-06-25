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
using iTasks.views;

namespace iTasks
{
    public partial class frmGereUtilizadores : Form
    {
        List<Utilizador> utilizadores = new List<Utilizador>();
        List<Gestor> gestores = new List<Gestor>();
        List<Programador> programadores = new List<Programador>();
        Dictionary<int, Tuple<Utilizador, Gestor>> dictUtilizadoresGestores;
        Dictionary<int, Tuple<Utilizador, Programador>> dictUtilizadoresProgramadores;

        public frmGereUtilizadores()
        {
            InitializeComponent();

            this.loadData();
        }

        public void loadData()
        {
            Utilizador utilizador = new Utilizador();
            Gestor gestor = new Gestor();
            Programador programador = new Programador();


            // Carrega os utilizadores do banco de dados
            utilizadores = utilizador.GetAllUtilizadores();
            gestores = gestor.GetAllGestores();
            programadores = programador.GetAllProgramadores();

            // Cria um merge entre users gestores e programadores
            // gestores e programadores possui o atributo idUtilizador que é o id do utilizador
            // Então cria dois dicionários para mapear os utilizadores e os gestores/programadores
            // Cria um dicionário que mapeia o id do utilizador para um par (Utilizador, Gestor)
            dictUtilizadoresGestores = gestores
                .Select(g => new { Gestor = g, Utilizador = utilizadores.FirstOrDefault(u => u.Id == g.IdUtilizador) })
                .Where(x => x.Utilizador != null)
                .ToDictionary(
                    x => x.Gestor.IdUtilizador,
                    x => Tuple.Create(x.Utilizador, x.Gestor)
                );

            // Cria um dicionário que mapeia o id do utilizador para um par (Utilizador, Programador)
            dictUtilizadoresProgramadores = programadores
                .Select(p => new { Programador = p, Utilizador = utilizadores.FirstOrDefault(u => u.Id == p.IdUtilizador) })
                .Where(x => x.Utilizador != null)
                .ToDictionary(
                    x => x.Programador.IdUtilizador,
                    x => Tuple.Create(x.Utilizador, x.Programador)
                );

            // Limpa a lista de gestores e adiciona os gestores com os utilizadores correspondentes
            lstListaGestores.Items.Clear();
            foreach (var kvp in dictUtilizadoresGestores)
            {
                var tuple = kvp.Value;
                Utilizador user = tuple.Item1;
                Gestor gestorItem = tuple.Item2;
                // Adiciona o gestor à lista apenas se o Username não for null
                if (!string.IsNullOrEmpty(user.Username))
                {
                    lstListaGestores.Items.Add(user.Username);
                }
            }
            // Limpa a lista de programadores e adiciona os programadores com os utilizadores correspondentes
            lstListaProgramadores.Items.Clear();
            foreach (var kvp in dictUtilizadoresProgramadores)
            {
                var tuple = kvp.Value;
                Utilizador user = tuple.Item1;
                Programador programadorItem = tuple.Item2;
                // Adiciona o programador à lista apenas se o Username não for null
                if (!string.IsNullOrEmpty(user.Username))
                {
                    lstListaProgramadores.Items.Add(user.Username);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Abre o formulário de registro de utilizador// public frmRegistrarUtilizador()
            frmRegistrarUtilizador frmRegistrar = new frmRegistrarUtilizador();
            frmRegistrar.LoadTipos(); // Carrega os tipos de utilizador no formulário
            frmRegistrar.ShowDialog(); // Exibe o formulário como um diálogo modal

            // Recarrega a lista de utilizadores após o registro
            this.loadData();
        }

        private void lstListaGestores_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txtNomeGestor
            // txtUsernameGestor
            // txtPasswordGestor
            // cbDepartamento
            // chkGereUtilizadores

            if (lstListaGestores.SelectedItem != null)
            {
                string selectedGestor = lstListaGestores.SelectedItem.ToString();
                //Gestor gestor = gestores.FirstOrDefault(g => g.Username == selectedGestor); // Deve ir a busca no dicionário de gestores
                var gestorTuple = dictUtilizadoresGestores.Values.FirstOrDefault(t => t.Item1.Username == selectedGestor);
                if (gestorTuple != null)
                {
                    Utilizador utilizador = gestorTuple.Item1;
                    Gestor gestor = gestorTuple.Item2;
                    // Preenche os campos com os dados do gestor selecionado
                    txtNomeGestor.Text = utilizador.Nome;
                    txtUsernameGestor.Text = utilizador.Username;
                    txtPasswordGestor.Text = utilizador.Password;
                    cbDepartamento.SelectedItem = utilizador.Departamento.ToString();
                    chkGereUtilizadores.Checked = gestor.GereUtilizadores;
                    txtIdGestor.Text = utilizador.Id.ToString(); // Exibe o ID do gestor no campo de texto, se necessário
                }

                // Preenche o cbDepartamento com os valores do enum Departamento
                cbDepartamento.Items.Clear();
                foreach (var dep in Enum.GetValues(typeof(Departamento)))
                {
                    cbDepartamento.Items.Add(dep.ToString());
                }

                // Seleciona o departamento atual do gestor
                if (gestorTuple != null)
                {
                    Utilizador utilizador = gestorTuple.Item1;
                    if (utilizador.Departamento != 0) // Verifica se o departamento é válido
                    {
                        cbDepartamento.SelectedItem = ((Departamento)utilizador.Departamento).ToString();
                    }
                    else
                    {
                        cbDepartamento.SelectedIndex = -1; // Nenhum departamento selecionado
                    }
                }
            }
        }

        private void lstListaProgramadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txtNomeProg
            // txtUsernameProg
            // txtPasswordProg
            // cbDepartamentoProg
            // chkNivelExperiencia

            if (lstListaProgramadores.SelectedItem != null)
            {
                string selectedProgramador = lstListaProgramadores.SelectedItem.ToString();
                // Busca o programador selecionado no dicionário
                var programadorTuple = dictUtilizadoresProgramadores.Values.FirstOrDefault(t => t.Item1.Username == selectedProgramador);
                if (programadorTuple != null)
                {
                    Utilizador utilizador = programadorTuple.Item1;
                    Programador programador = programadorTuple.Item2;
                    // Preenche os campos com os dados do programador selecionado
                    txtNomeProg.Text = utilizador.Nome;
                    txtUsernameProg.Text = utilizador.Username;
                    txtPasswordProg.Text = utilizador.Password;
                    txtIdProg.Text = utilizador.Id.ToString(); // Exibe o ID do programador no campo de texto, se necessário
                }

                // cbNivelProg
                cbNivelProg.Items.Clear();
                foreach (var nivel in Enum.GetValues(typeof(NivelExperiencia)))
                {
                    cbNivelProg.Items.Add(nivel.ToString());
                }

                // Seleciona o nível de experiência atual do programador
                if (programadorTuple != null)
                {
                    Programador programador = programadorTuple.Item2;
                    if (programador.NivelExperiencia == NivelExperiencia.Junior) // Verifica se o nível é válido
                    {
                        cbNivelProg.SelectedItem = programador.NivelExperiencia.ToString();
                    }
                    else if (programador.NivelExperiencia == NivelExperiencia.Senior)
                    {
                        cbNivelProg.SelectedItem = programador.NivelExperiencia.ToString();
                    }
                    else
                    {
                        cbNivelProg.SelectedIndex = -1; // Nenhum nível selecionado
                    }
                }

                // Seleciona os gestores e adciona a cbGestorProg
                cbGestorProg.Items.Clear();
                foreach (var kvp in dictUtilizadoresGestores)
                {
                    var tuple = kvp.Value;
                    Utilizador user = tuple.Item1;
                    Gestor gestorItem = tuple.Item2;
                    // Adiciona o gestor à lista apenas se o Username não for null
                    if (!string.IsNullOrEmpty(user.Username))
                    {
                        cbGestorProg.Items.Add(user.Username);
                    }
                }

                // Seleciona o gestor atual do user.idGestor e faz match com os gestores 
                if (programadorTuple != null)
                {
                    Utilizador utilizador = programadorTuple.Item1;
                    if (utilizador.IdGestor.HasValue && dictUtilizadoresGestores.ContainsKey(utilizador.IdGestor.Value))
                    {
                        var gestorTuple = dictUtilizadoresGestores[utilizador.IdGestor.Value];
                        cbGestorProg.SelectedItem = gestorTuple.Item1.Username; // Seleciona o gestor pelo Username
                    }
                    else
                    {
                        cbGestorProg.SelectedIndex = -1; // Nenhum gestor selecionado
                    }
                }
            }
        }

        private void btGravarGestor_Click(object sender, EventArgs e)
        {
            if (lstListaGestores.SelectedItem != null)
            {
                string selectedGestor = lstListaGestores.SelectedItem.ToString();
                // Busca o gestor selecionado no dicionário
                var gestorTuple = dictUtilizadoresGestores.Values.FirstOrDefault(t => t.Item1.Username == selectedGestor);
                if (gestorTuple != null)
                {
                    Utilizador utilizador = gestorTuple.Item1;
                    Gestor gestor = gestorTuple.Item2;
                    // Atualiza os dados do gestor
                    utilizador.Nome = txtNomeGestor.Text;
                    utilizador.Username = txtUsernameGestor.Text;
                    utilizador.Password = txtPasswordGestor.Text;
                    if (cbDepartamento.SelectedItem != null)
                    {
                        utilizador.Departamento =
                            (int)Enum.Parse(typeof(Departamento), cbDepartamento.SelectedItem.ToString());
                    }
                    gestor.GereUtilizadores = chkGereUtilizadores.Checked;
                    // Atualiza o utilizador e o gestor no banco de dados
                    utilizador.UpdateUser(utilizador);
                    gestor.UpdateGestor(gestor);
                }
            }
            this.loadData();
        }

        private void btGravarProg_Click(object sender, EventArgs e)
        {
            if (lstListaProgramadores.SelectedItem != null)
            {
                string selectedProgramador = lstListaProgramadores.SelectedItem.ToString();
                // Busca o programador selecionado no dicionário
                var programadorTuple = dictUtilizadoresProgramadores.Values.FirstOrDefault(t => t.Item1.Username == selectedProgramador);
                if (programadorTuple != null)
                {
                    Utilizador utilizador = programadorTuple.Item1;
                    Programador programador = programadorTuple.Item2;
                    // Atualiza os dados do programador
                    utilizador.Nome = txtNomeProg.Text;
                    utilizador.Username = txtUsernameProg.Text;
                    utilizador.Password = txtPasswordProg.Text;
                    utilizador.IdGestor =
                        dictUtilizadoresGestores.FirstOrDefault(kvp => kvp.Value.Item1.Username == cbGestorProg.SelectedItem.ToString()).Key;

                    // Atualiza o utilizador e o programador no banco de dados
                    utilizador.UpdateUser(utilizador);
                    programador.UpdateProgramador(programador);
                }
            }
            this.loadData();
        }
    }
}
