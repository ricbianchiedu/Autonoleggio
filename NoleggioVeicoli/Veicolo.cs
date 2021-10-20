using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoli
{
    class Veicolo
    {
        public String Targa { get; set; }
        public String Modello { get; set; }
        public double TariffaGiornaliera { get; set; }
        public Veicolo()
        {

        }

        public Veicolo(String t, String m, double tG)
        {
            this.Targa = t;
            this.Modello = m;
            this.TariffaGiornaliera = tG;
        }
    }
}
