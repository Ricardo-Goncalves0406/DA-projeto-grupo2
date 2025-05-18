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
            
            
            //secondForm.Show();
            if (txtUsername.Text=="username" && txtPassword.Text == "password")
            {
                Form secondForm = new frmKanban();
                secondForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("As credenciais estão erradas");
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
                //Hide();
                //secondForm.ShowDialog();

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
