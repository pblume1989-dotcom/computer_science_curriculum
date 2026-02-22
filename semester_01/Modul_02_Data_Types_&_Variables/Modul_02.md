- int , double , bool , char , string
- + , - , * ,  / , % , Vergleiche, Logik
- TryParse vs. Parse
- Typfallen: int-Division, double Division, % als Rest

Datentypen:
- int = ganze Zahl
- double = Kommazahl
- bool = Wahrheitswert (true / false)
- char = einzelnes Zeichen
- string = Text

Variable:
- Name für einen Speicherplatz im RAM
- Hat Typ (bestimmt Größe +  Interpretation der Bits)
- Hat Wert (was aktuell drin steht)
- Kann sich ändern

Operatoren:
- Arithmetik: + , - , * , / , %
- Verlgeich: == , != , < , > , <= , >=
- Logik: && , || , !

TryParse vs. Parse:
- TryParse ist der Standard Weg um Crashs zu vermeiden
- Parse führt zum Crash, wenn die Eingabe nicht geparsed werden kann
  Anstatt Zahl zb A
- int.TryParse(variable, out int variable)
  über out wird das Ergebnis in die 2te Variable gepackt.
  Außerdem wir bool (true/false) ausgegeben, damit man mit einer If-Abfrage arbeiten kann
  
Wichtig: = weist einen Wert zu, == vergleicht einen Wert

Mdolu(%): gibt als Wert den Rest von 2 Zahlen aus.
- Bsp: 7 % 2
- Rechnung: 2*3 = 6 -> 7 - 6 = 1
- Ergebnis: 1

Merksatz: Der Typ der Operanden bestimmt die Rechnung

Int vs double Division:
- int Division gibt immer nur Ganzzahl aus
  schneidet also Nachkomma ab (existieren nicht mehr)
- double Division gibt Nachkomma mit an
  Wichtig: es muss immer ein Wert double sein, damit double greift