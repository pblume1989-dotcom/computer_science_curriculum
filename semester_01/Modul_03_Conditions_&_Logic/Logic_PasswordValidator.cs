while (true)
{
    Console.WriteLine("Gib ein Passwort ein\nmindestens 8 Zeichen inklusive einer Zahl.");
    string? password = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(password))
    {
        Console.WriteLine("Keine Eingabe!");
        continue;
    }

    bool isNumber = false;

    for (int i = 0; i < password.Length; i++)
    {
        char c = password[i];

        if (char.IsDigit(c))
        {
            isNumber = true;
            break;
        }
    }

    if (password.Length >= 8 && isNumber)
    {
        Console.WriteLine("Erfolg");
    }
    else
    {
        Console.WriteLine("Anforderung nicht erfüllt");
        continue;
    }
    break;
}