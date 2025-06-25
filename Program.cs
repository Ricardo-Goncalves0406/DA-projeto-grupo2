using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTasks.models;

namespace iTasks
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configuração inicial do utilizador geral e gestor
            SetupGeneralUser();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }

        static void SetupGeneralUser()
        {
            Utilizador utilizador = new Utilizador
            {
                Nome = "Utilizador Geral",
                Username = "admin",
                Password = "@#123admin"
            };

            // Salva o utilizador geral no banco de dados se não existir
            utilizador.AddUser(utilizador);

            // Busca o utilizador no banco de dados
            Utilizador existingUser = utilizador.GetUserByUsername(utilizador.Username);

            if (existingUser == null)
            {
                // Se o utilizador não existir, cria um novo
                if (!utilizador.AddUser(utilizador))
                {
                    MessageBox.Show("Erro ao criar o utilizador geral. Verifique os dados e tente novamente.");
                }
            }
            else
            {
                Gestor gestor = new Gestor
                {
                    IdUtilizador = existingUser.Id,
                    GereUtilizadores = true // Define o gestor como capaz de gerir utilizadores
                };

                // Salva o gestor no banco de dados se não existir
                gestor.AddGestor(gestor);
            }
        }
    }
}
