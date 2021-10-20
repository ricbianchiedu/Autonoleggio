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

        public Cliente(String codFisc, String c, String n)
        {
            this.CF = codFisc;
            this.Cognome = c;
            this.Nome = n;
        }
    }
}
