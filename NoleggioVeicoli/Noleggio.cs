using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoli
{
    class Noleggio
    {
        public int IdNoleggio { get; set; }
        public DateTime InizioNoleggio { get; set; }
        public int NumGiorni { get; set; }
        public double CostoNoleggio { get; set; }
        public String CfCliente { get; set; }
        public String Targa { get; set; }

        public static int iD = 0;

        public Noleggio(DateTime d, int nG, String cfc, String t, double costoGiornaliero)
        {
            iD++;
            this.IdNoleggio = iD;
            this.InizioNoleggio = d;
            this.NumGiorni = nG;
            this.CfCliente = cfc;
            this.Targa = t;
            this.CostoNoleggio = nG * costoGiornaliero;
            
        }

        public Noleggio()
        {

        }

        public override string ToString() 
        {
            return "Dati Noleggio:\n" + "ID: " + this.IdNoleggio +"\n"
                + "Data inizio: " + this.InizioNoleggio + "\n"
                + "Durata in giorni: " + this.NumGiorni + "\n"
                + "Intestatario: " + this.CfCliente + "\n"
                + "Veicolo: " + this.Targa + "\n"
                + "Costo Noleggio: " + this.CostoNoleggio + ",00 Euro";
        }
    }
}
