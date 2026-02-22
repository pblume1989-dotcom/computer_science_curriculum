


while (true)
{
    Console.WriteLine("Gib mir eine Zahl");

    string? zahl1 = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(zahl1))
    {
        Console.WriteLine("keine Eingabe!");
        continue;
    }
    
    bool success = double.TryParse(zahl1, out double number1);

    if(!success)
    {
        Console.WriteLine("Keine Zahl!");
        continue;
    }

    Console.WriteLine("Gib mir noch eine Zahl");

    string? zahl2 = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(zahl2))
    {
        Console.WriteLine("keine Eingabe!");
        continue;
    }

    bool success1 = double.TryParse(zahl2, out double number2);

    if(!success1)
    {
        Console.WriteLine("Keine Zahl!");
        continue;
    }

    Console.WriteLine($"Die Summe deiner Zahlen beträgt {number1 + number2}");
    Console.WriteLine($"Die Differenz deiner Zahlen beträgt {number1 - number2}");
    Console.WriteLine($"Das Produkt deiner Zahlen beträgt {number1 * number2}");
    
    if(number2 == 0)
    {
        Console.WriteLine("Division durch 0 nicht erlaubt!");
        return;
    }
        Console.WriteLine($"Der Quotient deiner Zahlen beträgt {number1 / number2}");
    break;


}

