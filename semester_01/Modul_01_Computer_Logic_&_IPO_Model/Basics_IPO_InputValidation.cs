using System;

Console.WriteLine("Gib deinen Namen ein:");
string? Name = Console.ReadLine();
if (string.IsNullOrWhiteSpace(Name))
{
    Console.WriteLine("Keine Eingabe");
    return;
}

Console.WriteLine("Wie alt bit du?");
string? Age = Console.ReadLine();
if (string.IsNullOrWhiteSpace(Age))
{
    Console.WriteLine("Keine Eingabe.");
    return;
}

bool Ageval = int.TryParse(Age, out int age);

if(!Ageval)
{
    Console.WriteLine("Keine gültige Zahl.");
    return;
}

int AgeInFive = age + 5;

//BESSERE VARIANTE UNTEN Console.WriteLine("Hallo " + Name + ", in 5 Jahren bist du " + AgeInFive + " Jahre alt.");
Console.WriteLine($"Hallo {Name}, in 5 Jahren bist du {AgeInFive} Jahre alt.");