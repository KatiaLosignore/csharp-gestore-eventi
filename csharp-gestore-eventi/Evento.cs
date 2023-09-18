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

        private int postiPrenotati;
        public int PostiPrenotati
        {
            get { return this.postiPrenotati; }
        }

        // COSTRUTTORE

        public Evento(string titolo, DateTime data, int capienzaMax)
        {
            this.Titolo = titolo;
            this.Data = data;

            if (capienzaMax <= 0) 
                throw new ArgumentException("La capienza massima deve essere un numero positivo.");
            this.capienzaMax = capienzaMax;

            this.postiPrenotati = 0;

        }

        // METODO

        public void PrenotaPosti (int postiDaPrenotare)
        {
            if (Data < DateTime.Now)
                throw new InvalidOperationException("Non è possibile prenotare posti per un evento passato.");

            if (postiDaPrenotare <= 0)
               throw new ArgumentException("Il numero dei posti da prenotare ddeve essere al positivo");
            
            if(postiPrenotati + postiDaPrenotare > capienzaMax)
                throw new InvalidOperationException("Non ci sono abbastanza posti diponibili per effettuare la prenotazione!");

            postiPrenotati += postiDaPrenotare;
        }
    }
}
