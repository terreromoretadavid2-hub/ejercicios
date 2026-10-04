using System;

public static class AnalizadorLogs
{
    public static string ObtenerDespues(this string registro, string separador)
    {
        int posicion = registro.IndexOf(separador);

        if (posicion < 0)
        {
            return registro;
        }

        return registro.Substring(posicion + separador.Length);
    }

    public static string ObtenerEntre(this string registro, string inicio, string final)
    {
        int posicionInicio = registro.IndexOf(inicio);

        if (posicionInicio < 0)
        {
            return "";
        }

        int posicionFinal = registro.IndexOf(
            final,
            posicionInicio + inicio.Length
        );

        if (posicionFinal < 0)
        {
            return "";
        }

        int cantidadCaracteres =
            posicionFinal - posicionInicio - inicio.Length;

        return registro.Substring(
            posicionInicio + inicio.Length,
            cantidadCaracteres
        );
    }

    public static string ObtenerMensaje(this string registro)
    {
        return registro.ObtenerDespues(": ");
    }

    public static string ObtenerNivel(this string registro)
    {
        return registro.ObtenerEntre("[", "]");
    }

    public static void Main()
    {
        string registro = "[ERROR]: Missing ; on line 20.";

        string nivel = registro.ObtenerNivel();
        string mensaje = registro.ObtenerMensaje();

        Console.WriteLine("Nivel del registro: " + nivel);
        Console.WriteLine("Mensaje: " + mensaje);
    }
}