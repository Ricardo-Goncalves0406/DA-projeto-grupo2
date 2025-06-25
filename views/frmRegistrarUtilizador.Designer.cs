namespace iTasks.views
{
    partial class frmRegistrarUtilizador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_Username = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_TipoUser = new System.Windows.Forms.ListBox();
            this.btn_CreateUser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Nome = new System.Windows.Forms.TextBox();
            this.lb_Departamento = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_Username
            // 
            this.tb_Username.Location = new System.Drawing.Point(12, 63);
            this.tb_Username.Name = "tb_Username";
            this.tb_Username.Size = new System.Drawing.Size(283, 20);
            this.tb_Username.TabIndex = 0;
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(12, 125);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(283, 20);
            this.tb_Password.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // lb_TipoUser
            // 
            this.lb_TipoUser.FormattingEnabled = true;
            this.lb_TipoUser.Location = new System.Drawing.Point(12, 221);
            this.lb_TipoUser.Name = "lb_TipoUser";
            this.lb_TipoUser.Size = new System.Drawing.Size(177, 43);
            this.lb_TipoUser.TabIndex = 4;
            // 
            // btn_CreateUser
            // 
            this.btn_CreateUser.Location = new System.Drawing.Point(12, 361);
            this.btn_CreateUser.Name = "btn_CreateUser";
            this.btn_CreateUser.Size = new System.Drawing.Size(75, 23);
            this.btn_CreateUser.TabIndex = 5;
            this.btn_CreateUser.Text = "Criar user";
            this.btn_CreateUser.UseVisualStyleBackColor = true;
            this.btn_CreateUser.Click += new System.EventHandler(this.btn_CreateUser_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nome";
            // 
            // tb_Nome
            // 
            this.tb_Nome.Location = new System.Drawing.Point(12, 172);
            this.tb_Nome.Name = "tb_Nome";
            this.tb_Nome.Size = new System.Drawing.Size(283, 20);
            this.tb_Nome.TabIndex = 6;
            // 
            // lb_Departamento
            // 
            this.lb_Departamento.FormattingEnabled = true;
            this.lb_Departamento.Location = new System.Drawing.Point(12, 287);
            this.lb_Departamento.Name = "lb_Departamento";
            this.lb_Departamento.Size = new System.Drawing.Size(177, 56);
            this.lb_Departamento.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tipo de usuario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Departamento";
            // 
            // frmRegistrarUtilizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 396);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_Departamento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_Nome);
            this.Controls.Add(this.btn_CreateUser);
            this.Controls.Add(this.lb_TipoUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_Username);
            this.Name = "frmRegistrarUtilizador";
            this.Text = "frmRegistrarUtilizador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lb_TipoUser;
        private System.Windows.Forms.Button btn_CreateUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Nome;
        private System.Windows.Forms.ListBox lb_Departamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}