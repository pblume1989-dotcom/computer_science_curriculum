
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        int n = ReadInt("Wie viele Zahlen willst Du eingeben? ", 1, int.MaxValue);

        long sum = 0;

        for (int i = 0; i < n; i++)
            sum += ReadInt($"Gib mir Zahl {i + 1}: ");

        Console.WriteLine($"Die Summe deiner Zahlen ist: {sum}");

        double durchschnitt = (double)sum / n;
        Console.WriteLine($"Der Durchschnitt deiner Zahlen ist: {durchschnitt}");
    }

    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Fehler: Bitte etwas eingeben.");
                continue;
            }

            if (int.TryParse(input, out int value))
                return value;

            Console.WriteLine("Fehler: Bitte eine ganze Zahl eingeben.");
        }
    }

    private static int ReadInt(string prompt, int min, int max)
    {
        if (min > max) (min, max) = (max, min);

        while (true)
        {
            int value = ReadInt(prompt);

            if (value >= min && value <= max)
                return value;

            Console.WriteLine($"Bitte eine Zahl zwischen {min} und {max} eingeben.");
        }
    }
}