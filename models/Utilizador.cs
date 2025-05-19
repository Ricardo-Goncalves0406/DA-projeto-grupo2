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
        // Construtor vazio com o nome da classe
        public Utilizador()
        {

        }


        // Construtor com parâmetros
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        //O programador tem um gestor associado e um idGestor
        public int? IdGestor { get; set; }
        public int Gestor { get; set; }


        public Utilizador(int id, string nome, string username, string password)
        {
            this.Id = id;
            this.Nome = nome;
            this.Username = username;
            this.Password = password;
        }

    }   
     
}
