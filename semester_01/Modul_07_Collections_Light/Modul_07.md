# Collections

In einer Liste oder einem Array kann man Variablen verstauen, ohne jede einzelne Variable deklarieren zu müssen.

## List vs Array

### Arrays
- Haben eine feste Größe.
- Der Computer reserviert einen zusammenhängenden Block im Speicher, was den Zugriff extrem schnell macht.
- **Syntax:** `int[] arr = new int[3];`
- Zugriff auf die Plätze durch den Index: `arr[index]`
- Die Anzahl der Elemente wird mit `.Length` abgefragt.

### List
- Dynamische Größe.
- Nutzt im Hintergrund ein Array, das bei Bedarf automatisch vergrößert wird (Dynamic Resizing).
- **Syntax:** `List<string> inventory = new List<string>();`
- **Standard Befehle:** `Add`, `Remove`, `RemoveAt`, `Count`, `Clear`, `Contains`.
- Die Anzahl der Elemente wird mit `.Count` abgefragt.

## Wichtige Details zum Index und zur Manipulation

- Der Index startet immer bei 0.
- In einer `for`-Schleife läuft die Bedingung bis `i < Count` (oder `i <= Count - 1`).
- `RemoveAt(index)` löscht an einer genauen Position. Alle nachfolgenden Elemente rutschen einen Index nach vorne.
- `Contains("ItemName")` prüft schnell mit einem `bool`, ob ein Element in der Liste existiert.

## Wichtige Manipulation von Strings

- **.Split:** Trennt einen String bei einem Trennzeichen in ein Array auf.
- **Beispiel:** `string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);`
- Der Zusatz `RemoveEmptyEntries` verhindert leere Einträge im Array, wenn z.B. zwei Leerzeichen getippt wurden.
- **.ToLower:** Wandelt den gesamten Text in Kleinbuchstaben um (erstellt eine Kopie).
- **.ToUpper:** Wandelt den gesamten Text in Großbuchstaben um.
- **.Trim:** Entfernt alle Leerzeichen am Anfang und am Ende des Strings.
- **Stringvergleich:** `input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase)` ist die sauberste Methode, da sie Gross- und Kleinschreibung ignoriert, ohne eine Kopie des Strings erstellen zu müssen (spart Arbeitsspeicher).

## Durchlaufen von Collections

- **for-Schleife:** Gut, wenn man den Index (die Position) braucht.
- **foreach-Schleife:** Einfacherer Weg, um jedes Element nacheinander anzusprechen.
- **Syntax:**
```csharp
foreach (string item in inventory) 
{ 
    Console.WriteLine(item); 
}