// See https://aka.ms/new-console-template for more information
using csharp_gestore_eventi;



Console.WriteLine("Benvenuto nel gestore di eventi!");
Console.WriteLine();

// Chiedo all'utente di inserire i dettagli dell'evento
Console.Write("Inserisci il nome dell'evento: ");
string titolo = Console.ReadLine();

Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime data))
{
    Console.WriteLine("Data non valida. Il programma verrà chiuso.");
    return;
}


Console.Write("Inserisci il numero di posti totali: ");

int numeroPosti;

while (!int.TryParse(Console.ReadLine(), out numeroPosti))
    Console.WriteLine("Inserisci un numero");


// Istanzio la classe Evento

Evento evento = new Evento(titolo, data, numeroPosti);

Console.WriteLine($"\r\nHai creato un evento: {evento}");


// chiedo all’utente se e quante prenotazioni vuole fare e provare ad effettuarle.

Console.Write("\r\nQuanti posti desideri prenotare?: ");

int postiDaPrenotare;

while (!int.TryParse(Console.ReadLine(), out postiDaPrenotare))
    Console.WriteLine("Inserisci un numero");

evento.PrenotaPosti(postiDaPrenotare);

Console.WriteLine($"\r\nNumero di posti prenotati: {evento.PostiPrenotati}");

int differenzaPosti = (  evento.CapienzaMax  - evento.PostiPrenotati );

Console.WriteLine($"Numero di posti disponibili: {differenzaPosti}");


// chiedo all'utente se e quanti posti vuole disdire. Ogni volta che disdice dei posti, stampo i posti residui e quelli prenotati.

string scelta;

do
{
    Console.WriteLine("\r\nVuoi disdire dei posti (si/no)? ");
    scelta = Console.ReadLine();

    while ((scelta != "si" && scelta != "no") || string.IsNullOrEmpty(scelta))
    {
        Console.WriteLine("Inserisci una scelta valida!");
        scelta = Console.ReadLine();
    }

    if (scelta == "si")
    {
        Console.WriteLine("Indica il numero di posti da disdire: ");

        int numeroPostiDaDisdire;

        while (!int.TryParse(Console.ReadLine(), out numeroPostiDaDisdire))
            Console.WriteLine("Inserisci un numero");

        evento.DisdiciPosti(numeroPostiDaDisdire);
    }
    else
    {
        Console.WriteLine("\r\nOk va bene!");
    }

     Console.WriteLine($"Numero di posti prenotati: {evento.PostiPrenotati}");

    int differenzaPostiDisdetti = (evento.CapienzaMax - evento.PostiPrenotati);

    Console.WriteLine($"Numero di posti disponibili : {differenzaPostiDisdetti}");

} while (scelta == "si");

Console.WriteLine("------------------------------");

// Programma Eventi

// istanzio la classe ProgrammaEventi

ProgrammaEventi programma = new ProgrammaEventi();

Console.Write("Indica il numero di eventi da inserire: ");

int numeroEventi;

while(!int.TryParse(Console.ReadLine(),out numeroEventi))
{
    Console.WriteLine("Inserisci un numero!");
}

for (int i = 0; i < numeroEventi; i++)
{
    try
    {
        Evento eventoUtente = new Evento(i + 1);

        programma.AggiungiEvento(eventoUtente);

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Riprova nuovamente!");
        i--;
    }
}



// Informazioni Programma Eventi

    Console.WriteLine($"Il numero di eventi nel programma è: {programma.NumeroEventi()}");

    Console.WriteLine($"Ecco il tuo programma eventi: {programma.ToString()}");


   // chiedo all'utente una data per sapere quali eventi ci saranno

    Console.Write("\r\nInserisci una data per sapere che eventi ci saranno il (gg/mm/yyyy): ");


if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataDaCercare))
{
    Console.WriteLine("Data non valida. Inserisci Formato Valido! (gg/mm/yyyy): ");
}

Console.WriteLine(ProgrammaEventi.StampaEventi(programma.CercaData(dataDaCercare)));


programma.SvuotaEventi();
