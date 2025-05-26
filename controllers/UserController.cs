using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTasks.models;

namespace iTasks.controllers
{
    internal class UserController
    {
        Utilizador user = new Utilizador();
        public void TestUser()
        {
            // Cria um novo utilizador para teste
            user = new Utilizador
            {
                Nome = "test",
                Username = "test",
                Password = "test",
                IdGestor = 1,
                Gestores = 1,
            };
            user.AddUser(user);
        }
    }
}
