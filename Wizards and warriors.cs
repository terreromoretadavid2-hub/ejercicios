using System;

abstract class Character
{
    protected Character(string characterType)
    {
        this.characterType = characterType;
    }

    private string characterType;

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return "Character is a " + characterType;
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    private bool spellPrepared = false;

    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        return spellPrepared ? 12 : 3;
    }

    public void PrepareSpell()
    {
        spellPrepared = true;
    }

    public override bool Vulnerable()
    {
        return !spellPrepared;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Warrior warrior = new Warrior();
        Wizard wizard = new Wizard();

        Console.WriteLine(warrior);
        Console.WriteLine(wizard);

        Console.WriteLine();
        Console.WriteLine("Daño del Warrior al Wizard: " +
                          warrior.DamagePoints(wizard));

        Console.WriteLine("Daño del Wizard al Warrior: " +
                          wizard.DamagePoints(warrior));

        Console.WriteLine();
        Console.WriteLine("El Wizard prepara su hechizo...");
        wizard.PrepareSpell();

        Console.WriteLine("Daño del Warrior al Wizard: " +
                          warrior.DamagePoints(wizard));

        Console.WriteLine("Daño del Wizard al Warrior: " +
                          wizard.DamagePoints(warrior));

        Console.ReadKey();
    }
}