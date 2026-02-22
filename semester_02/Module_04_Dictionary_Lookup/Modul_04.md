Dictionary
- hat immer Key und Value
	- Key zum suchen
	- der Key ist immer Einzigartig -> kann nicht mehrfach existieren
	- Value zum ausgeben
- Schneller als eine Liste im Lookup -> 0(1)
- 3 wichtige Operanden
	- dict[key] -> gibt Value zurück
	- Contains(key) -> prüft Exsistens des Keys
	- TryGetValue(key, out value) -> macht beides in einem Schritt | Gibt false zurück wenn key nicht existiert -> kein Absturz
		- ist immer der beste Weg, wenn man auf jeden fall Value ausgegeben haben will -> spart einmal aufrufen des Dic

List vs Dictionary
- List
	- Reihenfolge wichtig, iterieren, Duplikate, kleine Mengen
	- Bsp: Quest-Aufgaben, Nachrichten-Log
- Dictionary
	- schnelles Nachschlagen, eindeutige Keys, Registry (id)
	- Bsp: Items, Räume, Städte

IEnumerable<> All => .Values;
- gibt Leseberechtigung für Methoden / Code außerhalb der Klasse
- ermöglicht iterieren über Dictionary
- Wichtig: Encapsulation (Kapselung)

Datentyp var
- Platzhalter
	- schaut was nachher in die variable soll und passt sich entsprechend an -> bei Dic dann KeyValuePair
	- Statitsch -> zuweisung Datentyp kann sich nicht mehr ändern
- ermöglicht den zugriff auf Dictionary -> Kombination aus Key und Value
	- variable zuweisen für Dic 1 ( var variable in dictionary) (bei foreach)
	- variable.Key, out var variableValue
	- Zugriff auf Value variable.PropertyName
Nochmal wichtig als Ergänzung: out var variableValue existiert nur im Loop (Scope)

Die Methode TotalValue ![[Pasted image 20260220110711.png]]
führt die Informationen aus ItemRegistry und Inventory zusammen
(Dependency)

out var variable -> diese variable wird erst in der If-Abfrage geboren und liegt direkt für uns bereit
Ist der Keyname nicht vorhanden -> kein absturz false wird zurück gegeben

Nochmal Ergänzung zu Methoden-Modul -> eine Methode die etwas zurück gibt, braucht immer einen Rückgabewert (Datentyp der Rückgabe)

Stammdaten und Bewegungsdaten
- Stammdaten (ItemRegistry im Bsp) -> State der für das gesamte System gilt
- Bewegungsdaten (Inventory im Bsp) -> Sate der nur für eine Klasse im System gilt