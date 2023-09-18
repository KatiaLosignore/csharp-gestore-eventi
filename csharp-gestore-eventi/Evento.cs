using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Evento
    {
        // ATTRIBUTI

        private string titolo;
        public string Titolo 
        { 
            get
            {
                return this.titolo;
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"Il campo {titolo} non può essere vuoto");
                } else
                {
                    this.titolo = value;
                }
            }           
                
        }
        private DateTime data;
        public DateTime Data
        {
            get
            {
                return this.data;
            }
            set
            {
                if (value < DateTime.Now)

                    throw new ArgumentException("La data dell'evento non può essere nel passato.");
                this.data = value;

            }
        }

        private int capienzaMax;

        public int CapienzaMax
        {
            get { return this.capienzaMax; }
        }

        public int PostiPrenotati { get; private set; }


        // COSTRUTTORE

        public Evento(string titolo, DateTime data, int capienzaMax)
        {
            this.Titolo = titolo;
            this.Data = data;

            if (capienzaMax <= 0) 
                throw new ArgumentException("La capienza massima deve essere un numero positivo.");
            this.capienzaMax = capienzaMax;

            this.PostiPrenotati = 0;

        }

        public Evento(int index)
        {
            Console.Write($"\r\nInserisci il nome del {index}° evento: ");
            string titoloEvento = Console.ReadLine();

            this.Titolo = titoloEvento;
            index++;

            Console.Write("Inserisci la data dell'evento (gg/mm/yyy): ");

            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime data))
            {
                Console.WriteLine("Data non valida. Il programma verrà chiuso.");
                return;
            }
           
            this.Data = data;

            Console.Write("Inserisci il numero di posti totali: ");

            int numeroPosti;

            while (!int.TryParse(Console.ReadLine(), out numeroPosti))
                Console.WriteLine("Inserisci un numero!");

            if (numeroPosti <= 0)
                throw new ArgumentException("Il numero posti deve essere un numero positivo.");
            this.capienzaMax = numeroPosti;


            this.PostiPrenotati = 0;
        }

        // METODI

        public void PrenotaPosti (int postiDaPrenotare)
        {
            if (Data < DateTime.Now)
                throw new InvalidOperationException("Non è possibile prenotare posti per un evento passato.");

            if (postiDaPrenotare <= 0)
               throw new ArgumentException("Il numero dei posti da prenotare deve essere al positivo");
            
            if(PostiPrenotati + postiDaPrenotare > capienzaMax)
                throw new InvalidOperationException("Non ci sono abbastanza posti diponibili per effettuare la prenotazione!");

            PostiPrenotati += postiDaPrenotare;
        }

        public void DisdiciPosti (int postiDaDisdire)
        {
            if (Data < DateTime.Now)
                throw new InvalidOperationException("Non è possibile disdire posti per un evento passato.");

            if (postiDaDisdire <= 0)
                throw new ArgumentException("Il numero dei posti da disdire deve essere al positivo");

            if (postiDaDisdire > PostiPrenotati)
                throw new InvalidOperationException("Non ci sono abbastanza posti prenotati da disdire!");

            PostiPrenotati -= postiDaDisdire;
        }


        public override string ToString()
        {
            return  $"{this.Data.ToString("dd/MM/yyyy")} - {this.Titolo}";
        }


    }
}
