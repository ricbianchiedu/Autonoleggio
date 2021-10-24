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
            /*
             * This serve solo se un attributo della classe ha lo stesso nome
             * del parametro del metodo, altrimenti, come in questo caso, è
             * inutile perché sottinteso.
             */

            this.NumPosti = np;
        }
    }
}
