using System;

public class CarroControlRemoto
{
    private int velocidad;
    private int consumoBateria;
    private int distancia;
    private int nivelBateria;

    public CarroControlRemoto(int velocidad, int consumoBateria)
    {
        this.velocidad = velocidad;
        this.consumoBateria = consumoBateria;
        distancia = 0;
        nivelBateria = 100;
    }

    public void Conducir()
    {
        if (nivelBateria >= consumoBateria)
        {
            distancia += velocidad;
            nivelBateria -= consumoBateria;
        }
    }

    public int ObtenerDistancia()
    {
        return distancia;
    }

    public bool SinBateria()
    {
        return nivelBateria < consumoBateria;
    }

    public static CarroControlRemoto CrearNitro()
    {
        return new CarroControlRemoto(50, 4);
    }
}

public class Circuito
{
    private int longitud;

    public Circuito(int longitud)
    {
        this.longitud = longitud;
    }

    public bool CompletoCircuito(CarroControlRemoto carro)
    {
        while (!carro.SinBateria())
        {
            carro.Conducir();
        }

        return carro.ObtenerDistancia() >= longitud;
    }
}

class Programa
{
    static void Main()
    {
        Console.WriteLine("===== PRUEBA DEL CARRO RC =====");

        int velocidadInicial = 5;
        int consumoInicial = 2;

        CarroControlRemoto carro =
            new CarroControlRemoto(velocidadInicial, consumoInicial);

        Console.WriteLine("\n--- Constructor del carro ---");
        Console.WriteLine("Velocidad: " + velocidadInicial);
        Console.WriteLine("Consumo de batería: " + consumoInicial);

        int largoCircuito = 800;
        Circuito circuito = new Circuito(largoCircuito);

        Console.WriteLine("\n--- Constructor del circuito ---");
        Console.WriteLine("Longitud del circuito: " + largoCircuito + " metros");

        carro = new CarroControlRemoto(5, 2);

        Console.WriteLine("\n--- Prueba de conducción ---");
        Console.WriteLine("Distancia inicial: " + carro.ObtenerDistancia());

        carro.Conducir();
        Console.WriteLine("Después de conducir: " + carro.ObtenerDistancia());

        carro.Conducir();
        Console.WriteLine("Después de otra conducción: " + carro.ObtenerDistancia());

        carro = new CarroControlRemoto(5, 2);

        Console.WriteLine("\n--- Prueba de batería ---");
        Console.WriteLine("¿Sin batería al comenzar?: " + carro.SinBateria());

        for (int contador = 0; contador < 50; contador++)
        {
            carro.Conducir();
        }

        Console.WriteLine("¿Sin batería después de 50 recorridos?: " +
                          carro.SinBateria());

        Console.WriteLine("Distancia total: " +
                          carro.ObtenerDistancia() + " metros");

        carro = new CarroControlRemoto(100, 68);

        Console.WriteLine("\n--- Prueba de alto consumo ---");
        Console.WriteLine("¿Sin batería?: " + carro.SinBateria());

        carro.Conducir();

        Console.WriteLine("Distancia: " + carro.ObtenerDistancia());
        Console.WriteLine("¿Sin batería?: " + carro.SinBateria());

        Console.WriteLine("\n--- Prueba Nitro ---");

        CarroControlRemoto nitro = CarroControlRemoto.CrearNitro();

        nitro.Conducir();

        Console.WriteLine("Distancia del Nitro después de conducir: " +
                          nitro.ObtenerDistancia() + " metros");

        Console.WriteLine("\n--- Prueba del circuito ---");

        carro = new CarroControlRemoto(5, 2);
        circuito = new Circuito(100);

        bool termino = circuito.CompletoCircuito(carro);

        Console.WriteLine("Circuito de 100 metros: " + termino);
        Console.WriteLine("Distancia alcanzada: " +
                          carro.ObtenerDistancia() + " metros");

        carro = new CarroControlRemoto(5, 2);
        circuito = new Circuito(500);

        termino = circuito.CompletoCircuito(carro);

        Console.WriteLine("\nCircuito de 500 metros: " + termino);
        Console.WriteLine("Distancia alcanzada: " +
                          carro.ObtenerDistancia() + " metros");

        nitro = CarroControlRemoto.CrearNitro();
        circuito = new Circuito(1000);

        termino = circuito.CompletoCircuito(nitro);

        Console.WriteLine("\nNitro en circuito de 1000 metros: " + termino);
        Console.WriteLine("Distancia alcanzada: " +
                          nitro.ObtenerDistancia() + " metros");
    }
}
