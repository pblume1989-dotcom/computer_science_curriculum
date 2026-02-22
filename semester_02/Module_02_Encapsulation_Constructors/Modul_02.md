Das Objekt darf nie in falsche Zustände rutschen, egal wer darauf zugreift.
Dazu nutzen wir:

Kapselung:
- private set; (nicht frei schreibar, laufen über die Methoden)
- Regel geschützte Werte (Gold, Hp)
Invarianten:
- Regeln die immer gelten müssen
- Gold >= 0; Hp >= 0; Name nicht leer; Value >= 0
Konstruktoren:
- sorgen dafür dass Objekte gültig geboren werden
Methoden:
- sorgen dafür dass Objekte gültig bleiben


Unterschied Guard Clauses in Konstruktor & Methode:
- Konstruktor
	-  Verhindern, dass das entsprechende Objekt mit ungültigen Werten initialisiert wird / existiert
- Methode
	- Verhindern das Objekte durch Benutzung in einen ungültigen State geändert werden

Warum nutzen wir private set; statt public set;

Mit private set; erzwingt man Änderungen über Methoden, wo Regeln + Logging + Events zentral kontrolliert werden können.
Wir verhindern so, dass Änderungen von Außen (andere Code/andere Klassen) kommen können und zb. einen Gold Wert auf 9999999 gesetzt wird.

Exception vs Try-Methode
- Exception: Sind für unerlaubte Werte/Bugs und dienen zum debuggen. Stören den Spielfluss
- Try-Methode: Behandelt erwartbare States (zu wenig Gold) ohne den Loop zu unterbrechen

Atomar = prüfen + ändern in einer Methode, um "Check then Commit " Bugs zu vermeiden


Math.Max & Math.Min
- Math.Max (a, b) -> 2 Werte vergleichen und immer den größeren nehmen
- Math.Min (a, b) -> 2 Werte vergleichen und immer den kleineren nehmen 

Idempotent: Mehrfaches ausführen, ändert ab einem finalen State nichts mehr
- if (IsDead) return; als "Guard"