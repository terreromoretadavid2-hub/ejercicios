using System;


public enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}


public static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        string levelCode = logLine.Substring(1, 3);

        return levelCode switch
        {
            "TRC" => LogLevel.Trace,
            "DBG" => LogLevel.Debug,
            "INF" => LogLevel.Info,
            "WRN" => LogLevel.Warning,
            "ERR" => LogLevel.Error,
            "FTL" => LogLevel.Fatal,
            _ => LogLevel.Unknown
        };
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return $"{(int)logLevel}:{message}";
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("--- Prueba Tarea 1 y 2: Analizar Nivel de Log ---");
        
        string log1 = "[INF]: File deleted";
        string log2 = "[XYZ]: Overly specific, out of context message";

        LogLevel level1 = LogLine.ParseLogLevel(log1);
        LogLevel level2 = LogLine.ParseLogLevel(log2);

        Console.WriteLine($"{log1}  =>  {level1}"); 
        Console.WriteLine($"{log2}  =>  {level2}");

        Console.WriteLine("\n--- Prueba Tarea 3: Formato Corto de Log ---");

        string shortLog1 = LogLine.OutputForShortLog(LogLevel.Error, "Stack overflow");
        string shortLog2 = LogLine.OutputForShortLog(LogLevel.Fatal, "System crash");
        string shortLog3 = LogLine.OutputForShortLog(LogLevel.Unknown, "Unrecognized payload");

        Console.WriteLine(shortLog1); 
        Console.WriteLine(shortLog2); 
        Console.WriteLine(shortLog3); 
    }
}