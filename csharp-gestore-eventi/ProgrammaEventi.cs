using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class ProgrammaEventi
    {
        // ATTRIBUTI
        public string titolo;
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
                    throw new ArgumentNullException($"Il campo {titolo} non può essere vuoto!");
                }
                else
                {
                    this.titolo = value;
                }
            }
        }

        // COSTRUTTORE
        public List<Evento> Eventi { get; set; }

        public ProgrammaEventi(string titolo)
        {
            this.Titolo = titolo;
            this.Eventi = new List<Evento>();
        }


    }


}


    
