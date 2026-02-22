- if/else if/else, switch
- &&, ||, !
- Randfälle: null / leer / whitespace, negative Werte, Grenzen
- Guard Clauses (early return)

&& = und (beide Bedingungen müssen erfüllt sein)
| | = oder (eine Bedingung muss erfüllt sein)
! = nicht (umdrehen)

Guard Clauses:
- return um bei einer Abfrage früh abzubrechen
- Bsp:
	if (!valid)
	{
	Console.WriteLine("Fehler");
	return;
	}
	// ab hier Happy-Path

Leere Eingabe prüfen .IsNullorWhitSpace

? : Prüft ob etwas vorhanden ist, ansonsten wird es nicht ausgeführt
