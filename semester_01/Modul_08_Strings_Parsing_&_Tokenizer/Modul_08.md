Command Console gebaut:

Ziel: Aus User-Input strukturierte Daten generieren

Einfacher Parser:
- Trim, und Split zur Normalisierung nutzen
- robuste Commands (help/echo/repeat/...)

Tokenizer:
- Robuster
- Sätze in Quotes werden als ein Token erkannt

Warum Parsing?
- User kann sich vertippen
- Groß und Klein-Schreibung ist egal
- mehrere Spaces können behandelt werden
- Item-Namen / Sätze über ("Health Potion") können vernünftig genutzt werden

String-Basics:

Trim:
- Trim() entfernt whitespace außen (hinten und vorne)
- Da Strings immutable sind -> neu abschpeichern
  input = input.Trim();

Case Normalisierung:
- cmd = cmd.ToLowerInvariant() 
- oder Equals(...., StringComparison.OrdinalIgnoreCase) -> gut für Vergleiche

Split:
- Split(' ') -> zerschneidet immer bei Space
- Split(' ', 2) -> trennt nur beim ersten Space
- Robustheit:
	- StringSplitOptions.RemoveEmptyEntries -> löscht Mehrfach-Space

Command Parser ohne Quotes

- Ziel: command + Rest
- Pattern:
	- parts = input.Trim().Split(' ', 2, RemoveEmptyEntries)
	- cmd = parts [0]
	- arg = parts.Length > 1 ? parts[1].Trim() : ""

Tokenizer:

Was ist ein Token?
- Ein Argument das zusammengehört
- Quotes sorgen dafür das Wörter mit Spaces ein Token bleiben
	- give Bob "Health Potion"
	- Tokens: give; Bob; Health Potion

Tokenizer Regel:
- Spaces trennen Tokens nur außerhalb von Quotes
- Quotes werden nicht Teil des Tokens
- Leere Tokens ignorieren
- Unclosed Quotes -> Fehlermeldung + Token verwerfen

Tokenizer State Machine
- bool inQuotes
- StringBuilder -> currentToken
- List string tokens
- Lauf über jeden Char
	- " toogle inQuotes
	- space & !inQuotes -> Token abschließen
	- sonst Zeichen anhängen
- Ende:
	- letzte Token pushen
	- wenn inQuotes == true -> Fehlermeldung + Token verwerfen

Multi-Args & Validierung

Zahlen Argumente
- Pattern:
	- int.TryParse(tokens[i], out int n)
	- Range-Check n < 1 ist Fehler

Konzept:
"Ein Algorithmus kann ein Gedächtnis haben."
- Der Tokenizer ist keine Kette von linearen Befehlen sondern reagiert unterschiedlich durch den bool inQuotes

Switch:
der switch kann anstatt einer langen Kette von if-else genutzt werden
- Jeder switch brauch einen case (im Bsp. "command")
- Außerdem muss immer ein break; gesetzt werden, damit es nicht in den nächsten case weiter rutscht

Guard Clauses:
- Fail Fast & User Feedback
- Fehler wie keine Eingabe oder | repeat - 5 Hallo | werden früh abgefangen und als Fehlermeldung zurückgegeben, damit zb: die Schleife gar nicht erst loslegen muss 

StringBuilder:

Der StringBuilder ist "Notizblock" und spart ressourcen, da er nicht jedes mal einen neuen String generiert sondern erst am ende alles übergibt