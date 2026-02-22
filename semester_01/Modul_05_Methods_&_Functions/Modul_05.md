- Parameter, Rückgabewerte, void
- Zerlegen von Problemen in Funktionen
- Wiederverwendbare Helfer: ReadInt() oder ReadChoice()
- Scope: Wo lebt die Variable?

Was ist eine Methode:
- Ein benannter Code-Block, der ausgeführt werden kann
- Kann Parameter (Eingaben) haben, muss aber nicht
- Gibt entweder einen Wert zurück oder void
- Kann pure sein oder Side Effects haben

Signatur (wichtiges Wort):
- Name + Parameterliste + Rückgabetyp (und ggf. static)
- Beispiel:
  int ReadInt(string prompt)
  void PrintMenu()

Was kann man mit einer Methode verbessern:
- Probleme in kleine Teile zerlegen
- Duplikate vermeiden
- Code lesbarer machen
- besser testen und debuggen

Parameter:
- Werte, die man der Methode mitgibt (Eingaben)
Return:
- Werte, die von der Methode zurückgegeben werden (Ausgabe als Wert)
Void:
- gibt keinen Wert zurück (macht stattdessen etwas: Ausgabe/Zustand ändern)

Scope:
- Variablen leben nur in dem Block, in dem sie definiert werden (zwischen { })
Bsp:
void Foo()
{
    int x = 5; // x lebt nur hier drin
}
// hier existiert x nicht mehr

return:
- beendet eine Methode sofort
- bei nicht-void muss return zusätzlich einen Wert liefern
- bei void kann man auch früh abbrechen: return;

Bsp:
int Add(int a, int b)
{
    return a + b;
}

void PrintIfValid(bool valid)
{
    if (!valid) return; // früher Abbruch möglich
    Console.WriteLine("OK");
}

void:
- nutzt man, wenn eine Methode keinen Wert zurückgeben soll
- typisch für Ausgabe oder Zustandsänderungen

Pure Function:
- Eine Methode ist pure, wenn sie außerhalb von sich selbst nichts verändert
- Sie nutzt nur ihre Parameter und gibt ein Ergebnis per return zurück
- Vorteile:
  - leicht zu testen
  - leicht zu debuggen
  - zuverlässig

Side Effect:
- Eine Methode hat Side Effects, wenn sie außerhalb der Methode etwas verändert, z.B.:
  - Ausgabe in der Konsole
  - Datei schreiben
  - Datenbank ändern
  - Netzwerkrequest senden
  - Zustand eines Objekts ändern

Best Practice:
- erst compute, dann apply (erst pure, dann Side Effect)

Compute:
- berechnet und gibt den Wert per return zurück

Apply:
- nimmt den Wert aus Compute und arbeitet damit weiter (z.B. Ausgabe)

Beispiel-Idee:
- Compute: Durchschnitt berechnen (return double)
- Apply: Ergebnis ausgeben (Console.WriteLine)

Overloading (Überladung):
- gleicher Methodenname, aber andere Parameterliste (Anzahl/Typ/Reihenfolge)
- Beispiel:
  int ReadInt(string prompt)
  int ReadInt(string prompt, int min, int max)

Ergebnis-/Fehlerbehandlungs-Patterns (3 Varianten)

1) Try-Pattern
- Wann:
  - wenn "kein Ergebnis" ein normaler Fall ist (kein Ausnahmefall)
  - wenn man success + result braucht
- Vorteil:
  - kein Exception-Control-Flow
  - Erfolg wird explizit geprüft
- Typische Form:
  bool TryXxx(..., out TResult result)

Beispiel:
bool ok = int.TryParse(input, out int value);
if (ok)
{
    // value ist gültig
}
else
{
    // Eingabe war ungültig
}

2) Nullable-Return (T?)
- Wann:
  - genau 1 Ergebnis oder kein Ergebnis
  - "kein Ergebnis" passt semantisch (null bedeutet wirklich "nicht gefunden")
- Vorteil:
  - kompakt, kein out, lesbar
- Hinweis:
  - Bei Value Types nutzt man T? (z.B. int?, double?)
  - Bei reference types kann string? etc. genutzt werden

Beispiel:
int? FindIndex(...)
{
    // return index; oder return null;
}

3) Exception-Pattern
- Wann:
  - bei echten Ausnahmefällen / unerwarteten Situationen
  - bei Fehlern, die nicht ignoriert werden sollen
  - oft bei Infrastruktur (Datei/Netzwerk/DB), aber nicht nur dort
- Vorteil:
  - trennt Happy-Path und Fehlerpfad klar
- Wichtig:
  - nicht für normale Eingabe-Fehler (z.B. Nutzer tippt Buchstaben statt Zahl) -> dafür Try/Validierung

Beispiel-Idee:
int Divide(int a, int b)
{
    if (b == 0) throw new ArgumentException("b darf nicht 0 sein");
    return a / b;
}
