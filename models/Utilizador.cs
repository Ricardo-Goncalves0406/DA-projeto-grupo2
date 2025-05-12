using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.models
{
    public class Utilizador
    {
        public Utilizador()
        {
                
        }

        public int id { get; set; }
        public string nome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Utilizador(string nome, string username, string password)
        {
            this.id = id;
            this.nome = nome;
            this.Username = username;
            this.Password = password;
        }
    }
}
