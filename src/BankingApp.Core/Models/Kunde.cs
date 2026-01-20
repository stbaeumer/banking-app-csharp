namespace BankingApp.Core.Models;

/// <summary>
/// Repräsentiert einen Kunden der Bank
/// </summary>
public class Kunde
{
    public int Id { get; set; }
    public string Vorname { get; set; } = string.Empty;
    public string Nachname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefon { get; set; } = string.Empty;
    public DateTime Geburtsdatum { get; set; }
    public string Adresse { get; set; } = string.Empty;
    public DateTime ErstelltAm { get; set; }

    public Kunde()
    {
        ErstelltAm = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Kunde #{Id}: {Vorname} {Nachname}, Email: {Email}, Telefon: {Telefon}";
    }
}
