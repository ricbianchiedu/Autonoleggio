using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoli
{
    class Automobile : Veicolo
    {
        public int NumPosti { get; set; }

        public Automobile(int np, String t, String m, double tG)
            : base (t, m, tG)
        {
            this.NumPosti = np;
        }
    }
}
