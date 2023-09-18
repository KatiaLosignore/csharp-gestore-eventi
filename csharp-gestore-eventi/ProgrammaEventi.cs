using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

        public ProgrammaEventi()
        {
            Console.Write("Inserisci il nome del tuo programma Eventi: ");

            while (true)
            {
                try
                {
                    this.Titolo = Console.ReadLine();
                    this.Eventi = new List<Evento>();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Riprova ad inserire il dato: ");
                }
            }
        }


        // METODI

        // metodo che aggiunge alla lista del programma eventi un Evento, passato come parametro al metodo.
        public void AggiungiEvento(Evento evento)
        {
            this.Eventi.Add(evento);
        }

        //  metodo che restituisce una lista di eventi con tutti gli eventi presenti in una certa data.

        public List<Evento> CercaData(DateTime data)
        {
           return this.Eventi.FindAll(e => e.Data == data);
            
        }

        // metodo statico che si occupa, presa una lista di eventi, di stamparla in Console, o ancora meglio vi restituisca la rappresentazione in stringa della vostra lista di eventi.

        public static string StampaEventi(List<Evento> eventi)
        {
            string risultato = "";

            int index = 1;
            
            foreach(Evento evento in eventi)
            {
                risultato += $"\r\n\t{index}. {evento.Titolo} - {evento.Data}";
                index++;

            }

            return risultato;
        }

        //  metodo che restituisce quanti eventi sono presenti nel programma eventi attualmente.

        public int NumeroEventi()
        {
            return this.Eventi.Count;
        }

        //  metodo che svuota la lista di eventi
        public void SvuotaEventi()
        {
            this.Eventi.Clear();
        }

        // metodo che restituisce una stringa che mostra il titolo del programma e tutti gli eventi aggiunti alla lista

        public override string ToString()
        {
            string res = $"Nome programma evento: {this.Titolo} : \n";
            res += StampaEventi(Eventi);

            return res;
        }
    }


}


    
