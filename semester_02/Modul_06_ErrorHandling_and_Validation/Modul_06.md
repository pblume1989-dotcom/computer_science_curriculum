Kernkonzept:
- Alles was außerhalb kommt ist verdächtig
	- User input (Console.ReadLine)
	- Datei-Inhalt
	- Netzwerk / KI-Output
	- Player-Commands

Exceptions vs Try-Pattern:
- Exceptions:
	- Immer dann wenn etwas nicht falsch seien darf (Design by Contract)
		- Invarianten
		- unmöglicher State
		- Systemfehler
- Try-Pattern
	- normale Fehler
		- Falsche Eingabe
		- Falsche Menge
		- Fehlendes Argument

Verbesserung durch Result-Pattern:
- bool gibt nur true oder false zurück
- out string error überall hardcoded, kann übersichtlich werden
- Durch eine Klasse ValidationResult haben wir eine einheitliche Ausgabe:
	- Status : Ok, Fehlercode : ErrorCode, Benutzer-Nachricht : Message

Static Factory Methods:
- Anstatt über den Konstruktor aufzurufen nutzen wir static methoden
- public static Success / public static Failure
- nutzen über ValidationResult.Succes() / ValidationResult.Failure(code, msg)

Error Propagation
- Fehler werden von tiefster Ebene (zb. TryTokenize) bis zur obersten (zb. TryBuildAction) weitergegeben

Wichtige Punkte:
- Null-Koaleszenz (??): Property = variable ?? "NONE";
	- Sicher stellen, dass Property niemals leer ist, auch wenn nicht übermittelt wurde
		- nimm variable, wenn null dann "NONE"
	- Seperation of Concerns: Tokenizer zerlegt, Parser versteht die Befehle, Main steuert Ablauf
- Namespace und using
	- Namespaces damit eine Kategorie weiß das sie zusammen gehört
		- Bsp.: namespace Semester2.Parsing / Semester2.LookUpSystem
		- nutzen von andere namespace Kategorie mit: using Semester2.Parsing etc.
- Shortcut-Circuit (fail fast)
	- erst Fehler abfangen dann Happy-Path