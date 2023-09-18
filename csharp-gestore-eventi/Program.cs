﻿// See https://aka.ms/new-console-template for more information
using csharp_gestore_eventi;

Console.WriteLine("Hello, World!");

Console.WriteLine("Benvuto nel gestore di eventi!");

// Chiedo all'utente di inserire i dettagli dell'evento
Console.Write("Inserisci il titolo dell'evento: ");
string titolo = Console.ReadLine();

Console.Write("Inserisci la data dell'evento nel seguente formato (dd/MM/yyyy): ");
if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime data))
{
    Console.WriteLine("Data non valida. Il programma verrà chiuso.");
    return;
}


Console.Write("Inserisci il numero dei posti totali: ");

int numeroPosti;

while (!int.TryParse(Console.ReadLine(), out numeroPosti))
    Console.WriteLine("Inserisci un numero");


// Istanzio la classe Evento

Evento evento = new Evento(titolo, data, numeroPosti);

Console.WriteLine($"Hai creato un evento: {evento}");


// chiedo all’utente se e quante prenotazioni vuole fare e provare ad effettuarle.

Console.Write("Quanti posti vuoi prenotare?: ");

int postiDaPrenotare;

while (!int.TryParse(Console.ReadLine(), out postiDaPrenotare))
    Console.WriteLine("Inserisci un numero");

evento.PrenotaPosti(postiDaPrenotare);

Console.WriteLine($"Numero di posti prenotati: {evento.PostiPrenotati}");

int differenzaPosti = (  evento.CapienzaMax  - evento.PostiPrenotati );

Console.WriteLine($"Numero di posti disponibili: {differenzaPosti}");





