using System;


public enum TravelMethod
{
    Walking,
    Horseback
}

public class Character
{
    public string Class { get; set; } = string.Empty;
    public int Level { get; set; }
    public int HitPoints { get; set; }
}

public class Destination
{
    public string Name { get; set; } = string.Empty;
    public int Inhabitants { get; set; }
}


public static class GameMaster
{
    public static string Describe(Character character)
    {
        return $"Eres un {character.Class} de nivel {character.Level} con {character.HitPoints} puntos de vida.";
    }

    public static string Describe(Destination destination)
    {
        return $"Has llegado a {destination.Name}, que tiene {destination.Inhabitants} habitantes.";
    }

    public static string Describe(TravelMethod travelMethod)
    {
        return travelMethod switch
        {
            TravelMethod.Walking => "y estas viajando a tu destino caminando.",
            TravelMethod.Horseback => "y estas viajando montando tu caballo .",
            _ => throw new ArgumentOutOfRangeException(nameof(travelMethod))
        };
    }

    public static string Describe(Character character, Destination destination, TravelMethod travelMethod = TravelMethod.Walking)
    {
        return $"{Describe(character)} {Describe(travelMethod)} {Describe(destination)}";
    }
}


class Program
{
    static void Main()
    {
        var character = new Character
        {
            Class = "Hechizero",
            Level = 20,
            HitPoints = 28
        };

        var destination = new Destination
        {
            Name = "Marvillia",
            Inhabitants = 7000
        };

        Console.WriteLine("--- test 1: Describe Personaje ---");
        Console.WriteLine(GameMaster.Describe(character));

        Console.WriteLine("\n--- test 2: Describe tu Destino ---");
        Console.WriteLine(GameMaster.Describe(destination));

        Console.WriteLine("\n--- test 3: Describe tu Método de Viaje ---");
        Console.WriteLine(GameMaster.Describe(TravelMethod.Horseback));

        Console.WriteLine("\n--- test 4: Personaje viajando a caballo ---");
        Console.WriteLine(GameMaster.Describe(character, destination, TravelMethod.Horseback));

        Console.WriteLine("\n--- test 5: Personaje viajando (método omitido -> Caminando) ---");
        Console.WriteLine(GameMaster.Describe(character, destination));
    }
}