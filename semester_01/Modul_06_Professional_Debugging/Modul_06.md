Modul 06 – Debugging (Notizen)

3 Debugging-Fragen (immer):
1. Was ist das erwartete Verhalten?
2. Was passiert wirklich?
3. Ab wann unterscheidet sich Erwartung und Realität? (Kipp-Punkt finden)

Häufige Fehlerklassen:
- Input / Parsing (kommen die Werte wirklich so rein?)
- Logik / Condition (falsche Bedingung, falscher Operator)
- Off-by-one (Grenzen, < vs <=)
- Zustand (Variable überschrieben/nicht gesetzt/falscher Scope)
- Reihenfolge (zu früh/zu spät gerechnet, falsche Reihenfolge)

Debugging-Workflow:
1. Reproduzieren (Bug zuverlässig auslösen, Testfall festnageln)
2. Minimieren (kleinstes Beispiel finden, das noch kaputt ist)
3. Hypothese (konkret: "Variable X hat hier falschen Wert" / "läuft 1x zu viel")
4. Messen/Beobachten (Debugger oder gezielte Logs/Prints)
5. Fix + Gegenprobe (mind. 3 Tests: Normalfall, Randfall, fieser Fall)

Wichtig:
- Eingrenzen ist der Key, nicht wahllos testen
- Erst messen, dann ändern (sonst Placebo-Fix)

Breakpoints vs Print/Logs:
- Breakpoint: System einfrieren (Pause) und Zustand zu Zeitpunkt X prüfen
- Print/Logs: Verlauf über Zeit sehen (z.B. Schleifen, Ticks, seltene Bugs)

Breakpoint-Basics:
- Breakpoint = Pause an einer Zeile, um Variablen/Zustand zu inspecten
- Continue: weiter bis nächster Breakpoint/Ende
- Step Over: nächste Zeile ausführen (Methodenaufrufe nicht rein)
- Step Into: in aufgerufene Methode rein
- (Optional) Step Out: aktuelle Methode fertig und zurück

Breakpoint-Regel:
- Setze Breakpoints zuerst dort, wo der verdächtige Wert verändert wird (Write-Location),
  nicht nur bei der Ausgabe.

Off-by-one Checkliste (Start–Stop–Step):
- Start: wo beginnt i? (0 oder 1)
- Stop: < vs <= (0-basiert meist i < n)
- Step: wie verändert sich i? (i++, i += 2, ...)
Merksätze:
- 1x zu viel -> meistens Stop-Bedingung (<= statt <)
- Endlosschleife -> Step/Bedingungsvariable ändert sich nicht

3 Werkzeuge für große Systeme:
- Logging (gezielt: Events/State-Änderungen, nicht alles vollspammen)
- Invariants/Assertions (Zustände, die nie passieren dürfen -> früh stoppen)
- Reproduzierbarkeit/Determinismus (gleiche Inputs/Seed -> Bug wird messbar)

Merker:
- Erwartung -> Input prüfen -> Kipp-Punkt finden -> messen -> fixen -> Gegenprobe
