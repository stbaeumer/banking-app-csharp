using BankingApp.Core.Models;
using BankingApp.Core.Services;

namespace BankingApp.ConsoleApp;

class Program
{
    private static readonly KundenService kundenService = new();

    
    // Die Main ist der Einstiegspunkt der Anwendung
    static void Main(string[] args)
    {
        Console.WriteLine("═══════════════════════════════════════");
        Console.WriteLine("      Banking App - Kundenverwaltung   ");
        Console.WriteLine("═══════════════════════════════════════");
        Console.WriteLine();

        // Ein bool ist ein true/false Wert
        bool beenden = false;

        // Hauptmenü Schleife. Wiederholt sich bis beenden = true ist
        while (!beenden)
        {
            Console.WriteLine("\n--- Hauptmenü ---");
            Console.WriteLine("1. Neuen Kunden hinzufügen");
            Console.WriteLine("2. Alle Kunden anzeigen");
            Console.WriteLine("3. Beenden");
            Console.Write("\nBitte wählen Sie eine Option: ");
          
            // Liest die Benutzereingabe von der Konsole            
            string? auswahl = Console.ReadLine();

            // Verarbeitet die Benutzereingabe
            switch (auswahl)
            {
                case "1":
                    // Wenn die Auswahl "1" ist, rufe die Methode NeuerKunde auf
                    NeuerKunde();
                    break;
                case "2":
                    AlleKundenAnzeigen();
                    break;
                case "3":
                    beenden = true;
                    Console.WriteLine("\nAuf Wiedersehen!");
                    break;
                default:
                    Console.WriteLine("\nUngültige Auswahl. Bitte versuchen Sie es erneut.");
                    break;
            }
        }
    }

    private static void NeuerKunde()
    {
        Console.WriteLine("\n--- Neuen Kunden hinzufügen ---");

        // Instanziierung eines neuen Kundenobjekts.
        var kunde = new Kunde();

        Console.Write("Vorname: ");
        kunde.Vorname = Console.ReadLine() ?? string.Empty;

        Console.Write("Nachname: ");
        kunde.Nachname = Console.ReadLine() ?? string.Empty;

        Console.Write("Email: ");
        kunde.Email = Console.ReadLine() ?? string.Empty;

        Console.Write("Telefon: ");
        kunde.Telefon = Console.ReadLine() ?? string.Empty;

        Console.Write("Geburtsdatum (dd.MM.yyyy): ");
        string? geburtsdatumStr = Console.ReadLine();
        if (DateTime.TryParseExact(geburtsdatumStr, "dd.MM.yyyy", 
            System.Globalization.CultureInfo.InvariantCulture, 
            System.Globalization.DateTimeStyles.None, 
            out DateTime geburtsdatum))
        {
            kunde.Geburtsdatum = geburtsdatum;
        }
        else
        {
            Console.WriteLine("Ungültiges Datum. Verwende heutiges Datum.");
            kunde.Geburtsdatum = DateTime.Now;
        }

        Console.Write("Adresse: ");
        kunde.Adresse = Console.ReadLine() ?? string.Empty;

        var hinzugefuegterKunde = kundenService.KundeHinzufuegen(kunde);

        Console.WriteLine($"\n✓ Kunde erfolgreich hinzugefügt!");
        Console.WriteLine(hinzugefuegterKunde.ToString());
    }

    private static void AlleKundenAnzeigen()
    {
        Console.WriteLine("\n--- Alle Kunden ---");

        var kunden = kundenService.AlleKundenAbrufen();

        if (kunden.Count == 0)
        {
            Console.WriteLine("Noch keine Kunden vorhanden.");
            return;
        }

        foreach (var kunde in kunden)
        {
            Console.WriteLine($"\n{kunde}");
            Console.WriteLine($"  Geburtsdatum: {kunde.Geburtsdatum:dd.MM.yyyy}");
            Console.WriteLine($"  Adresse: {kunde.Adresse}");
            Console.WriteLine($"  Erstellt am: {kunde.ErstelltAm:dd.MM.yyyy HH:mm:ss}");
        }

        Console.WriteLine($"\nGesamt: {kunden.Count} Kunde(n)");
    }
}
