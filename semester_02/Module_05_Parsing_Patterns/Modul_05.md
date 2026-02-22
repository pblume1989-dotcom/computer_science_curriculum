Ziel: Einen solide Parser Methode + Tokenizer bauen

Zusätzlich: die Eingabe nach Bedeutung filtern

Methoden: TryParse: TryTokenize; TryBuild

Das Try-Pattern:
- Aufbau:
	- Nutzung von bool Rückgabewert (false or true)
	- Nutzung von Rückgabewerten über "out"
	- Fehlermeldungen über false
	- Erfolg über true
- Ziel:
	- Fehlermeldungen führen nicht zum Absturz
	- Auf Fehlermeldungen kann kontrolliert reagiert werden
- Vorgehen:
	- Fehler werden durch false abgefange
	- Fehlermeldung wird in einer Variable gespeichert (error) und mit ausgegeben
	- Fehlermeldung + false wird weitergeleitet und kann z.B. in der UI ausgegeben werden, oder im Log

Trennung: (single responsibility)
- Grammatik (Tokenizer)
	- Zerlegt den String nach Regeln in Tokens
- Semantik (Command-Parser)
	- Prüft Tokens und gibt aus verb + rest
- Nutzung (BuildAction)
	- verb + rest neu zusammen fügen
	- Einheitliche Ausgabe für das System

StringBuilder:
- Technisches Konzept:
	- Stringbuilder ist mutable
	- reserviert eine größere Menge RAM
	- nimmt die Zeichen und hängt sie immer hinten an das letzte Zeichen dran
	- erst am Ende eines Tokens wird über .ToString die Zeichenkette zu einem imutable String
- Vorteil:
	- Da mutable (veränderlich) muss nicht für jeden neuen char neuer RAM reserviert werden

Single Source of truth:
- Nutzung einer List für valide Befehle
- private Property-Field