using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Conferenza : Evento
    {
        // ATTRIBUTI
        private string relatore;

        public string Relatore
        {
            get
            {
                return this.relatore;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(null, "Il campo \"Relatore\" non può essere vuoto!");
                }
                else
                {
                    this.relatore = value;
                }
            }
        }

        private double prezzo;
        public double Prezzo
        {
            get
            {
                return this.prezzo;
            }
            set
            {
                if (prezzo < 0)
                {
                    throw new ArgumentNullException(null, "Il Prezzo non puo essere inferiore a 0!");
                }
                else
                {
                    this.prezzo = value;
                }
            }
        }

        // COSTRUTTORE

        public Conferenza(string titolo, DateTime data, int capienzaMax, string relatore, double prezzo) : base(titolo, data, capienzaMax)
        {
            this.Relatore = relatore;
            this.Prezzo = prezzo;
        }

        // METODI

        public string DataOraFormattata()
        {
            return Data.ToString("dd/MM/yyyy HH:mm");
        }

        public string PrezzoFormattato()
        {
            return Prezzo.ToString("0.00") + " Euro";
        }

        public override string ToString()
        {
            return $"{DataOraFormattata()} - {Titolo} - {Relatore} - {PrezzoFormattato()}";
        }
    }

}