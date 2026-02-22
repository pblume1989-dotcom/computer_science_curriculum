namespace Semester2.Fundamentals;

public class Monster
{
    public string Name {get; private set;}
    public int Hp {get; private set;}
    public bool IsDead {get; private set;}

    public Monster(string name, int startHp)
    {
        if (string.IsNullOrWhiteSpace(name))
        throw new ArgumentException("Name darf nicht leer sein.", nameof(name));

        if (startHp <= 0)
        throw new ArgumentOutOfRangeException(nameof(startHp), "HP muss > 0 sein.");

        Name = name;
        Hp = startHp;
        IsDead = (Hp == 0);
    }

    public void TakeDamage(int dmg)
    {
        if (IsDead)
            return;

        if (dmg < 0)
            throw new ArgumentOutOfRangeException(nameof(dmg), "Schaden darf nicht negativ sein.");

        Hp = Math.Max(0, Hp -dmg);

        if (Hp == 0)
        IsDead = true;
    }
}