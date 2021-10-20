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
            List<Automobile> Automobili = new List<Automobile>();
            List<Furgone> Furgoni = new List<Furgone>();

            //Creazione dati
            Cliente cli1 = new Cliente("BNCRCR63E03H294R", "Bianchi", "Riccardo");
            Clienti.Add(cli1);
            Cliente cli2 = new Cliente("VRDGNN78B10H277C", "Verdi", "Giovanni");
            Clienti.Add(cli2);
            Cliente cli3 = new Cliente("RSSCRL92G26H944K", "Rossi", "Carlo");
            Clienti.Add(cli3);

            Automobile a1 = new Automobile(5, "FG655BD", "XV", 25.00);
            Automobili.Add(a1);
            Automobile a2 = new Automobile(4, "GB621KA", "Twingo", 20.00);
            Automobili.Add(a2);
            
            Furgone f1 = new Furgone(150, "DB663OP", "Ducato", 18.00);
            Furgoni.Add(f1);
            Furgone f2 = new Furgone(280, "EA102FE", "Daily", 22.00);
            Furgoni.Add(f2);

            DateTime d1 = new DateTime(2021, 05, 03);
            DateTime d2 = new DateTime(2021, 06, 15);
            DateTime d3 = new DateTime(2021, 09, 23);
            
            Noleggio n1 = new Noleggio(d1, 3, cli1.CF, a1.Targa, a1.TariffaGiornaliera);
            Noleggi.Add(n1);
            Noleggio n2 = new Noleggio(d2, 5, cli2.CF, f1.Targa, f1.TariffaGiornaliera);
            Noleggi.Add(n2);
            Noleggio n3 = new Noleggio(d3, 2, cli3.CF, a1.Targa, a1.TariffaGiornaliera);
            Noleggi.Add(n3);
            Noleggio n4 = new Noleggio(d1, 8, cli1.CF, a2.Targa, a1.TariffaGiornaliera);
            Noleggi.Add(n4);
            Noleggio n5 = new Noleggio(d2, 4, cli1.CF, f2.Targa, f2.TariffaGiornaliera);
            Noleggi.Add(n5);

            Noleggio n = new Noleggio();

            //Domanda a
            n = CercaNoleggio(4, Noleggi);
            Console.WriteLine(n.ToString());
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
            return noleggios.Find(tmp => tmp.IdNoleggio == idNolo);
        }

        public static List<Noleggio> VisualizzaNoleggi(String ricerca, List<Noleggio> noleggios)
        {
            List<Noleggio> risultato = noleggios.FindAll(x => x.Targa.Contains(ricerca) || x.CfCliente.Contains(ricerca));
            return risultato;
        }

        public static double IncassoNoleggi(String t, List<Noleggio> noleggios)
        {
            double incasso = 0.0;
            var listaNoleggi = noleggios.FindAll(x => x.Targa.Contains(t));
            foreach (var item in listaNoleggi)
            {
                incasso = incasso + item.CostoNoleggio;
            }
            return incasso;
        }

        public static double SpesaPerNoleggi(String cf, List<Noleggio> noleggios)
        {
            double spesa = 0.0;
            var listaNoleggi = noleggios.FindAll(x => x.CfCliente.Contains(cf));
            foreach (var item in listaNoleggi)
            {
                spesa = spesa + item.CostoNoleggio;
            }
            return spesa;
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
