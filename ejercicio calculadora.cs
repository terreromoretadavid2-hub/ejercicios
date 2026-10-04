using System;

public class ErrorOperacion : Exception
{
    public ErrorOperacion(string mensaje) : base(mensaje)
    {
    }

    public ErrorOperacion(string mensaje, Exception causa) : base(mensaje, causa)
    {
    }
}

public class Calculadora
{
    public string Resolver(int numero1, int numero2, string operacion)
    {
        if (operacion == null)
        {
            throw new ArgumentNullException(
                nameof(operacion),
                "La operación no puede ser nula"
            );
        }

        if (operacion == "")
        {
            throw new ArgumentException(
                "La operación no puede estar vacía"
            );
        }

        int resultado;

        switch (operacion)
        {
            case "+":
                resultado = numero1 + numero2;
                break;

            case "*":
                resultado = numero1 * numero2;
                break;

            case "/":
                try
                {
                    resultado = numero1 / numero2;
                }
                catch (DivideByZeroException error)
                {
                    throw new ErrorOperacion(
                        "No se puede dividir entre cero",
                        error
                    );
                }
                break;

            default:
                throw new ErrorOperacion(
                    $"La operación '{operacion}' no es válida"
                );
        }

        return $"{numero1} {operacion} {numero2} = {resultado}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Calculadora calculadora = new Calculadora();

        Console.WriteLine(calculadora.Resolver(16, 51, "+"));
        Console.WriteLine(calculadora.Resolver(32, 6, "*"));
        Console.WriteLine(calculadora.Resolver(512, 4, "/"));

        Console.WriteLine("\n--- Pruebas de errores ---");

        try
        {
            calculadora.Resolver(10, 1, null);
        }
        catch (ArgumentNullException error)
        {
            Console.WriteLine($"Error por valor nulo: {error.ParamName}");
        }

        try
        {
            calculadora.Resolver(10, 1, "");
        }
        catch (ArgumentException error)
        {
            Console.WriteLine($"Error por operación vacía: {error.Message}");
        }

        try
        {
            calculadora.Resolver(10, 1, "-");
        }
        catch (ErrorOperacion error)
        {
            Console.WriteLine($"Error por operación inválida: {error.Message}");
        }

        try
        {
            calculadora.Resolver(512, 0, "/");
        }
        catch (ErrorOperacion error)
        {
            Console.WriteLine($"Error al dividir entre cero: {error.Message}");
            Console.WriteLine($"Detalle: {error.InnerException?.Message}");
        }
    }
}