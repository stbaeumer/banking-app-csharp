using BankingApp.Core.Models;

namespace BankingApp.Core.Services;

/// <summary>
/// Service für Kundenverwaltung
/// </summary>
public class KundenService
{
    private readonly List<Kunde> _kunden = new();
    private int _naechsteId = 1;

    /// <summary>
    /// Fügt einen neuen Kunden hinzu
    /// </summary>
    public Kunde KundeHinzufuegen(Kunde kunde)
    {
        kunde.Id = _naechsteId++;
        kunde.ErstelltAm = DateTime.Now;
        _kunden.Add(kunde);
        return kunde;
    }

    /// <summary>
    /// Gibt alle Kunden zurück
    /// </summary>
    public IReadOnlyList<Kunde> AlleKundenAbrufen()
    {
        return _kunden.AsReadOnly();
    }

    /// <summary>
    /// Sucht einen Kunden nach ID
    /// </summary>
    public Kunde? KundeFinden(int id)
    {
        return _kunden.FirstOrDefault(k => k.Id == id);
    }
}
