using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoli
{
    class Furgone : Veicolo
    {
        public int CapacitaCarico { get; set; }

        /*
         * Reuse of base class constructor
         */

        public Furgone(int capacitaDiCarico, String t, String m, double tG)
            : base(t, m, tG)
        {
            CapacitaCarico = capacitaDiCarico;
        }
    }
}
