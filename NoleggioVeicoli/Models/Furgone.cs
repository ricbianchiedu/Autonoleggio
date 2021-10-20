﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoli
{
    class Furgone : Veicolo
    {
        public int CapacitaCarico { get; set; }

        public Furgone(int cC, String t, String m, double tG)
            :base(t, m, tG)
        {
            this.Modello = m;
            this.Targa = t;
            this.TariffaGiornaliera = tG;
            this.CapacitaCarico = cC;
        }
    }
}