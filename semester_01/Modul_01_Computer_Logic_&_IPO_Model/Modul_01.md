- Input -> Verarbeitung -> Output (IPO)
- Ausführungskette: Source -> CIL -> JIT -> CPU
- Tracing (Code in Gedanken durchgehen)

Was ist ein Programm?
Ein Programm ist eine Folge von Anweisungen, die Eingaben (Input) nehmen, sie nach Regeln verarbeiteten (Process) und Ergebnisse ausgeben (Output)

Dieses Model nennt sich Input-Process-Output (IPO)

Was passiert beim programmieren?
- Code wird umgewandelt in CIL (Zwischen-Code)
- CIL wird in CPU-Sprache per JIT (Just-in-Time) Compiler umgewandelt
- Code läuft zwischen CPU und RAM

Beispiel für IPO:
- Eingabe: 7 + 1
- a=7, b=1, Operator=+
- Rechnung: a+b=8
- Output: 8

Programme laufen immer von oben nach unten.

Wichtig:
DivideByZeroException:
- durch 0 teilen ist Mathematisch nicht möglich
- über "double" wird automatisch ein Ausgabewert nach IEEE-754 Standard ausgegeben (PositiveInfinity)
- Dies dient dazu einen Crash vom System zu vermeiden