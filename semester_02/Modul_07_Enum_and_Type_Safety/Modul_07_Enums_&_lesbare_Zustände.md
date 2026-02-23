Enums sind Zustände mit festen und begrenzten Wertebereichen

Vorteile gegenüber Strings:
- Compiler Fehler bei falscher Schreibweise
	- string "nrth" wird compiliert
	- Direction.Nrth wird nicht compiliert
- Ein zentraler Ort für einen Wertebereich
	- strings mit gleicher Bedeutung an 10 Stellen hardcoded
- Switch / if / else -> werden übersichtlicher durch die Schreibweise

Syntax: 
public enum Direction
{
North,	
South,
East,
West
}
Aufruf: Direction.North / .South

Ergebnis:
- Durch Enums wird der Code super Lesbar
  public enum GameState { Exploration, Combat, Dialogue}
  GameState state = GameState.Combat;
- Weitere Bsp.
	- switch (dir)
	  {
		  case Direction.North;
		  //....
		  break;
- ist im Vergleich zum alten switch ordentlicher
	- schnelleres finden
	- einfacheres erweitern / anpassen


enum Robuster als string:

- Compiler-/Typschutz
- Einheitliche "Systemsprache"/Domain-Werte
- Refactoring-Sicherheit

3 Parsing Steps
- Guard
- Normalise
- Bedeutung
	- Enum.TryParse(variable, ignoreCase: true, out variable)
		- ignoreCase: Macht vergleich String Enum-Wert case-insensitive
- Wichtig: initialisiern in Methoden mit variable = default;
	(Erste Stelle [0] kann auch angepasst werden um spezifischen Wert auszugeben)
Enums für:
- geschlossene Mengen (GameState, Direction, VerbType)
String für:
- Frei-Text -> Chat; Notizen; Descriptions
