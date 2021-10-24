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

        /*
         *In c#, Compile Time Polymorphism means defining multiple methods with
         *the same name but with different parameters.
         *Using compile-time polymorphism, we can perform different tasks with
         *the same method name by passing different parameters (overloading).
         */


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

        /*
         * In c#, Run Time Polymorphism means overriding a base class method in the 
         * derived class by creating a similar function. This can be achieved by using 
         * override & virtual keywords and the inheritance principle.
         * Using run-time polymorphism, we can override a base class method in the
         * derived class by creating a method with the same name and parameters to          
         * perform a different task.
         */

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
