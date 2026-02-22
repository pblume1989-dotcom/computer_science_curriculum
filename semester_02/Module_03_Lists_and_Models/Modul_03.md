
Models:
- Models sind Datentypen, die aus einer Klasse und dem daraus erstellten Objekt bestehen
- So können wir statt eines festen Datentyps (string, int, float, double) eine Liste aus z.B. Items erstellen.

List:
- Standard Container für viele Objekte
- Bsp. Items / Quests (Zählpunkte / Zähler)
- Typische Befehle Aktionen:
	- Add; Remove; RemoveAt; Count; Indexing; Copy

Loops:
- foreach:
	- gut für Liste durchgehen, ohne den Index zu verändern
	- Eigenschaften sind veränderbar
	- geht von fester Liste aus, bei Änderung Fehler
	- Nutzbar bei Summierungen
- for:
	- nutzen wenn man Liste durchgeht und dabei Items entfernt
	- beim entfernen nutzt man typisch eine Rückwärtsschleife um Fehler in der Reihenfolge zu vermeiden

Copy:
- kopiert nur die Liste -> die Referenzen bleiben gleich:
	- original und kopie greifen auf die gleiche Objekte zurück

Null return:
- Null Werte müssen immer vom Empfänger behandelt werden
- Ein null Wert der in einer Methode entsteht ist kein Poblem, wenn folgendes erfüllt ist: ? als Hinweis für den Compiler, dass ein Null Wert da seien kann

Guard Clauses:
- Null Referenz muss immer abgedeckt sein, wenn Werte die empfangen werden null seien könnten
- So verhindern wir Abstürze

Kapselung:
Verhindert, dass jemand "an der Logik vorbei" Daten manipulieren kann.
die public Methoden sind sozusagen Guardians

- private schützt vor Zugriff von Außerhalb
	- Das was geschützt werden muss sollte immer private sein
- public lässt Methoden / Code von außen zugreifen
	- Die Methoden die Dinge verändern sollen von außen erreichbar sein

Properties vs Methoden:
- Properties:
	- Eigenschaften: Zustandsabfragen, die sich wie eine Variable anfühlen
	- Wann: Wert zurückgeben, der das Objekt beschreibt
	- Property darf keine unerwarteten Nebenwirkungen haben
	- Bsp: siehe TotalValue
- Methoden:
	- Verändern das Objekt
	- Aufwendige Berechnungen für die Rückgabe der Objektbeschreibung (bei get wird erwartet, dass das Ergebnis sofort da ist)
  