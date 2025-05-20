using iTasks.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            Utilizador user = new Utilizador();
            user = user.GetUserByUsername(txtUsername.Text);

            // Validar se o utilizador existe e se a password está correta
            if (user != null && user.Password == txtPassword.Text)
            {
                // Se o utilizador existir e a password estiver correta, abrir o formulário principal
                Form secondForm = new frmKanban(user);
                secondForm.Show();
                this.Hide();
            }
            else
            {
                // Se o utilizador não existir ou a password estiver incorreta, mostrar mensagem de erro
                MessageBox.Show("As credenciais estão erradas ou o user não existe!");
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }

            //secondForm.Show();
            //if (txtUsername.Text=="username" && txtPassword.Text == "password")
            //{
            //    Form secondForm = new frmKanban();
            //    secondForm.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("As credenciais estão erradas");
            //    txtUsername.Clear();
            //    txtPassword.Clear();
            //    txtUsername.Focus();
            //}
            //    //Hide();
            //secondForm.ShowDialog();

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
