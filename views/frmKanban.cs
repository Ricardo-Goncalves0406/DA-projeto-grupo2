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

namespace iTasks
{
    public partial class frmKanban : Form
    {
        Utilizador user = new Utilizador();

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
    }
}
