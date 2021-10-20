using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoli
{
    class Cliente
    {
        public String CF { get; set; }
        public String Cognome { get; set; }
        public String Nome { get; set; }

        public Cliente(String cf, String cognome, String nome)
        {
            CF = cf;
            Cognome = cognome;
            Nome = nome;
        }
    }
}
