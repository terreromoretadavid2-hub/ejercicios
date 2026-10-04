using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        int start = logLine.IndexOf(':') + 1;
        return logLine.Substring(start).Trim();
    }

    public static string LogLevel(string logLine)
    {
        int end = logLine.IndexOf(']');
        return logLine.Substring(1, end - 1).ToLower();
    }

    public static string Reformat(string logLine)
    {
        return $"{Message(logLine)} ({LogLevel(logLine)})";
    }
}