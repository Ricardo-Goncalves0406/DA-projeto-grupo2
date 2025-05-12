using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.models
{
    class Gestor : Utilizador
    {
        public Gestor()
        {
        }

        public string Departamento { get; set; }

        public bool GereUtilizadores { get; set; }

        public Gestor(bool GereUtilizadores, string nome, string username, string Password, 
            string departamento)
        {
            this.GereUtilizadores = GereUtilizadores;
            this.nome = nome;
            this.Username = Username;
            this.Password = Password;
            this.Departamento = departamento;
        }
    }

  
