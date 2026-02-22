## Klasse:

- Bauplan / Typ
    
- **Die Klassendefinition selbst ist „nur“ Code/Metadaten** (existiert im Programm), aber **kein Instanz-Speicher**
    
- **RAM/Objektzustand („pro Ding“) entsteht erst bei Instanzen**
    

## Objekt:

- verwirklichter Bauplan, der über `new Klasse(...)` erstellt wird (**eine Instanz der Klasse**)
    
- **das Objekt belegt Speicher im RAM** (konzeptionell „Heap“)
    
- eine Variable wie `Player p` hält dabei meistens nur eine **Referenz** auf das Objekt (nicht das Objekt selbst)
    

Durch eine Klasse kann man bestimmte Variablen, die zusammen gehören sollen, zusammen packen und dem Objekt ein Verhalten mitgeben.

## Vokabular:

- **Field**: Variable in der Klasse (normalerweise `private`) → interner Zustand
    
- **Property**: kontrollierter Zugriff auf den Zustand
    
    - `get; set;` (frei)
        
    - `get; private set;` (von außen lesen, nur intern ändern)
        
    - `get;` (nur lesen, „immutable-ish“)
        
- **Methode**: Funktion/Verhalten, das dem Objekt mitgegeben wird (ändert oft den State kontrolliert)
    

## Merksatz:

Field = Tresor, Property = Bankschalter.  
Geld abheben (`get`) und Geld einzahlen (`set`) über den Bankschalter ist OK.  
**Direkt in den Tresor greifen (Field von außen) = nicht OK.**  
(**`private set`** heißt: „Einzahlen“ darf nur die Bank selbst = die Klasse.)

## Wichtig:

### Instanzbezug:

- Eine Methode bezieht sich immer auf die **Instanz**, die sie aufruft.
    
- Wenn man 2 Objekte hat (`player1` und `player2`) und `player1.AddGold(10)` aufruft, kann das Programm direkt zuordnen, auf wessen Konto es geht (**player1**).
    

### Referenzen (wichtig für später):

- `Player a = b;` bedeutet meistens: **beide Variablen zeigen auf dasselbe Objekt** (kein Copy).  
    Änderungen über `a` sieht man dann auch über `b`.
    

## Konstruktoren:

- **`new` reserviert das Objekt, der Konstruktor initialisiert es**
    
- Wichtig: Durch **Guard Clauses** verhindern wir, dass das Objekt kaputt „geboren“ wird (Invarianten gelten direkt).
    
- Dazu nutzen wir `throw` Exceptions (z.B. `ArgumentException`, `ArgumentOutOfRangeException`).
    

## Kapselung:

- `private set` nutzen, um von außen **nur Leseberechtigung** zu geben.
    
- **Änderungsberechtigung** haben nur Methoden **innerhalb der Klasse** (Polizei-Regeln).
    
- Das gilt für anderen Code/andere Klassen – **nicht** „Datei“-abhängig.