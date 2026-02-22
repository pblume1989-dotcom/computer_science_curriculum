- for = bekannte anzahl, while = bis Bedingung erfüllt
- off-by-one Fehler & Endlosschleifen
- Input wiederholen bis gültig
- Verschachtelte Schleifen

For-Schleifen erledigen eine Aufgabe x-mal
Bsp: for (in i=0; i<5; i++)
i=0 : start
i<5 : Bedingung
i++ : Schritt

While-Schleifen erledigen eine Aufgabe bis Bedingung erfüllt ist

Off-by-One: i<5 (läuft 0,1,2,3,4)    i<=5 (läuft 0,1,2,3,4,5)

Interpolierter String: $ (alles in {} ist echter Code)
Bsp: Console.WriteLine($"x={x + 1}; x=11, wenn x vorher 10)

Wichtig: continue = startet die Schleife neu
break = beendet die Schleife

Scope: Variablen die in der Schleife geboren werden, leben auch nur in dieser.
Will man eine Variable nach der Schleife benutzen, muss diese vor der Schleife deklariert werden.

