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
        public String CfCliente { get; set; }
        public Veicolo Veicolo {get;set;}
        public static int iD = 0;

        public Noleggio(DateTime InizioNoleggio, int nG, String cfc, Veicolo veicolo )
        {
            iD++;
            IdNoleggio = iD;
            this.InizioNoleggio = InizioNoleggio;
            NumGiorni = nG;
            CfCliente = cfc;
            Veicolo = veicolo;

            //this.Targa = t;
            //this.CostoNoleggio = nG * costoGiornaliero;
            
        }

        public Noleggio(){}

        public override string ToString() 
        {
            return "Dati Noleggio:\n" + "ID: " + IdNoleggio +"\n"
                + "Data inizio: " + InizioNoleggio + "\n"
                + "Durata in giorni: " + NumGiorni + "\n"
                + "Intestatario: " + CfCliente + "\n"
                + "Veicolo: " + Veicolo.Targa + "\n"
                + "Costo Noleggio: " + Veicolo.TariffaGiornaliera*NumGiorni  + ",00 Euro";
        }
    }
}
