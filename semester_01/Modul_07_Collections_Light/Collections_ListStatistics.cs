using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

class Programm
{
    static void Main()
    {
        List <int> zahlen = new List<int>();
        int sum = 0;

        while (true)
        {
            Console.WriteLine("Bitte gib deine Zahlen ein. Wenn du keine mehr eingeben willst gib ein: stopp");

            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Keine Eingabe...");
                continue;
            }

            if (input.Trim().ToLower() == "stopp")
            {
            break;
            }

            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine("Keine Zahl...");
                continue;
            }
                zahlen.Add(value);
        }
        foreach (int zahl in zahlen)
        {
            sum += zahl;
        }

        if (sum <= 0)
        {
            Console.WriteLine("Keine Zahlen, keine Berechnung...");
            return;
        }
            double durschnitt = (double)sum / zahlen.Count;

            zahlen.Sort();
            int min = zahlen[0];
            int max = zahlen[zahlen.Count -1];

            Console.WriteLine($"Summe: {sum}");
            Console.WriteLine($"Durschnitt: {durschnitt}");
            Console.WriteLine($"Kleinste Zahl: {min}");
            Console.WriteLine($"Größte Zahl: {max}");
            
    }




private static double ReadDouble()
{
    while (true)
        {
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Keine Eingabe...");
                continue;
            }

            if (double.TryParse(input, out double value))
            return value;

            Console.WriteLine("Keine Zahl...");
        }        
}

private static double ReadDouble(double min, double max)
    {
        while (true)
        {
            double value = ReadDouble();
            
            if (value >= min && value <= max)
            return value;

            Console.WriteLine($"Bitte Zahl zwischen {min} und {max}");
        }
    }
}