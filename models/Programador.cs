using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.models
{
    class Programador: Utilizador
    {
        public Programador()
        {
            
        }

        public int NivelExperiencia { get; set; }
        public int IdGestor { get; set; }

        public Programador(int NivelExperiencia, int idGestor)
        {
            NivelExperiencia = NivelExperiencia;
            IdGestor = idGestor;
        }
    }

   

}
