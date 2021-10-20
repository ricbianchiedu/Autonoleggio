using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoli
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creazione Liste
            List<Cliente> Clienti = new List<Cliente>();
            List<Noleggio> Noleggi = new List<Noleggio>();
            List<Veicolo> Veicoli = new List<Veicolo>();

            //Creazione dati
            Clienti.Add(new Cliente("BNCRCR63E03H294R", "Bianchi", "Riccardo"));
            Clienti.Add(new Cliente("VRDGNN78B10H277C", "Verdi", "Giovanni"));
            Clienti.Add(new Cliente("RSSCRL92G26H944K", "Rossi", "Carlo"));

            Veicoli.Add(new Automobile(5, "FG655BD", "XV", 25.00));
            Veicoli.Add(new Automobile(4, "GB621KA", "Twingo", 20.00));
            
            Veicoli.Add(new Furgone(150, "DB663OP", "Ducato", 18.00));
            Veicoli.Add(new Furgone(280, "EA102FE", "Daily", 22.00));

            DateTime d1 = new DateTime(2021, 05, 03);
            DateTime d2 = new DateTime(2021, 06, 15);
            DateTime d3 = new DateTime(2021, 09, 23);
            
            Noleggi.Add(new Noleggio(d1, 3, Clienti[0].CF, Veicoli[0] ));
            Noleggi.Add(new Noleggio(d2, 5, Clienti[1].CF, Veicoli[0] ));
            Noleggi.Add(new Noleggio(d3, 2, Clienti[2].CF, Veicoli[1] ));
            Noleggi.Add(new Noleggio(d1, 8, Clienti[0].CF, Veicoli[2] ));
            Noleggi.Add(new Noleggio(d2, 4, Clienti[0].CF, Veicoli[3] ));


            //Domanda a
            Noleggio n = CercaNoleggio(4, Noleggi);
            Console.WriteLine( n );
            Console.WriteLine();

            //Domanda b
            String stringaRicerca = "BNCRCR63E03H294R";

            foreach (var item in VisualizzaNoleggi(stringaRicerca, Noleggi))
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine("----------");
            }


            //Domanda c
            if (VerificaDisponibilitaMezzo("FG655BD", 2021, 5, 1, 1, Noleggi))
            {
                Console.WriteLine("Auto disponibile");
                Console.WriteLine("----------");
            }
            else
            {
                Console.WriteLine("Auto non disponibile");
                Console.WriteLine("----------");
            }

            //Domanda d
            stringaRicerca = "FG655BD";

            Console.WriteLine("Il costo totale dei noleggi per l'auto " + stringaRicerca + " vale: " + IncassoNoleggi(stringaRicerca, Noleggi) + " Euro.");


            //Domanda e
            stringaRicerca = "BNCRCR63E03H294R";

            Console.WriteLine("La spesa totale per i noleggi del cliente " + stringaRicerca + " vale: " + SpesaPerNoleggi(stringaRicerca, Noleggi) + " Euro.");


            Console.ReadKey(); 

        }

        public static Noleggio CercaNoleggio(int idNolo, List<Noleggio> noleggios)
        {
            // foreach( var n in noleggios )
            // {
            //     if(n.IdNoleggio == idNolo)
            //         return n;
            // }

            return noleggios.Find( n => n.IdNoleggio == idNolo );
        }

        public static List<Noleggio> VisualizzaNoleggi(String ricerca, List<Noleggio> noleggios)
        {
            List<Noleggio> risultato = noleggios.FindAll( x => 
                x.Veicolo.Targa.Contains(ricerca) || 
                x.CfCliente.Contains(ricerca)
            );

            return risultato;
        }

        public static double IncassoNoleggi(String t, List<Noleggio> noleggios)
        {
            // return noleggios
            //        .FindAll(x => x.Veicolo.Targa.Contains(t))
            //        .Sum( x => x.NumGiorni*x.Veicolo.TariffaGiornaliera);

            return  (from x in noleggios
                          where(x.Veicolo.Targa==t)
                          select x)
                         .Sum( x => x.NumGiorni*x.Veicolo.TariffaGiornaliera);
        }

        public static double SpesaPerNoleggi(String cf, List<Noleggio> noleggios)
        {
            // double spesa = 0.0;
            // var listaNoleggi = noleggios.FindAll(x => x.CfCliente.Contains(cf));
            // foreach (var item in listaNoleggi)
            // {
            //     spesa = spesa + item.CostoNoleggio;
            // }
            // return spesa;

            var retVal = from x in noleggios
                where x.CfCliente==cf
                select x;

            double d = retVal.Sum( s => s.NumGiorni*s.Veicolo.TariffaGiornaliera);

            return d;
        }

        public static bool VerificaDisponibilitaMezzo(String t, int a, int m, int g, int gg, List<Noleggio> noleggios)
        {
            bool disponibile = false;
            DateTime dataInizioNoleggio = new DateTime(a, m, g);
            DateTime dataFineNoleggio = dataInizioNoleggio.AddDays(gg);

            var v = VisualizzaNoleggi(t, noleggios);
            foreach (var item in v)
            {
                //La data di inizio o fine noleggio è compresa nell'intervallo di un noleggio precedente
                if ((dataInizioNoleggio >= item.InizioNoleggio && dataFineNoleggio <= item.InizioNoleggio.AddDays(item.NumGiorni)) ||
                    (dataFineNoleggio >= item.InizioNoleggio && dataFineNoleggio <= item.InizioNoleggio.AddDays(item.NumGiorni)))
                {
                    disponibile = false;
                    break;
                }
                else
                    disponibile = true;
            }

            return disponibile;
        }
    }
}
