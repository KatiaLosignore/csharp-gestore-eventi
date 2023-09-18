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

    }
}
