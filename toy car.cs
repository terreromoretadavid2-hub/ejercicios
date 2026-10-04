using System;

class RemoteControlCar
{
    private int _distanceDriven = 5;
    private int _batteryPercentage = 100;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Manejado {_distanceDriven} metros";
    }

    public string BatteryDisplay()
    {
        if (_batteryPercentage == 0)
        {
            return "Bateria vacia";
        }

        return $"Bateria al {_batteryPercentage}%";
    }

    public void Drive()
    {
        if (_batteryPercentage > 0)
        {
            _distanceDriven += 20;
            _batteryPercentage -= 1;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {        RemoteControlCar car = RemoteControlCar.Buy();

        Console.WriteLine(car.DistanceDisplay()); 
        Console.WriteLine(car.BatteryDisplay());  

        car.Drive();
        car.Drive();

        Console.WriteLine(car.DistanceDisplay()); 
        Console.WriteLine(car.BatteryDisplay());  

        for (int i = 0; i < 100; i++)
        {
            car.Drive();
        }

        Console.WriteLine(car.DistanceDisplay()); 
        Console.WriteLine(car.BatteryDisplay());  

        car.Drive();
        Console.WriteLine(car.DistanceDisplay()); 
    }
}