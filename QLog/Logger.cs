using System.Text;

namespace QLog;

public static class Logger
{
    private static FileStream logStream = null!;
    private static LoggerSettings settings = null!;
    
    public static void Init(LoggerSettings _settings)
    {
        settings = _settings;

        if (File.Exists(settings.filePath))
        {
            File.Delete(settings.filePath);
        }
        logStream = File.Create(settings.filePath);
        Info("Started logging", typeof(Logger));
    }
    public static void Info<T>(string message) => Info(message, typeof(T));
    public static void Warn<T>(string message) => Warn(message, typeof(T));
    public static void Error<T>(Exception message) => Error(message, typeof(T));
    
    public static void Info(string message, Type? sender = null)
    {
        var write = Log.Build(message, sender);
        if(settings.logToConsole) {Console.Write(Log.BuildANSI(message, sender));}
        var bytes = Encoding.UTF8.GetBytes(write);
        logStream.Write(bytes, 0, bytes.Length);
    }
    
    public static void Error(Exception message, Type? sender = null)
    {
        var write = Log.Build(message, sender);
        if(settings.logToConsole) {Console.Write(Log.BuildANSI(message, sender));}
        var bytes = Encoding.UTF8.GetBytes(write);
        logStream.Write(bytes, 0, bytes.Length);
    }
    
    public static void Warn(string message, Type? sender = null)
    {
        var write = Log.BuildWarn(message, sender);
        if(settings.logToConsole) {Console.Write(Log.BuildWarnANSI(message, sender));}
        var bytes = Encoding.UTF8.GetBytes(write);
        logStream.Write(bytes, 0, bytes.Length);
    }

    public static void Stop() => logStream.Close();
}

public class LoggerSettings
{
    public string filePath = "null.log";
    public bool logToConsole = false;
}

file static class Log
{
    public static string BuildANSI(string message, Type? @object = null)
    {
        return $"[\x1b[38;5;48m{DateTime.Now:HH:mm:ss}\x1b[0m | QLog/\x1b[38;5;99mINF\x1b[0m | \x1b[1;38;5;111m{@object ?? typeof(Nullable)}\x1b[0m ] \x1b[1;38;5;99m{message}\x1b[0m\n";
    }
    
    public static string BuildANSI(Exception message, Type? @object = null)
    {
        return $"[\x1b[38;5;48m{DateTime.Now:HH:mm:ss}\x1b[0m | QLog/\x1b[38;5;196mERR\x1b[0m | \x1b[1;38;5;111m{@object ?? typeof(Nullable)}\x1b[0m ] \x1b[1;38;5;196m{message}\x1b[0m\n";
    }
    
    public static string BuildWarnANSI(string message, Type? @object = null)
    {
        return $"[\x1b[38;5;48m{DateTime.Now:HH:mm:ss}\x1b[0m | QLog/\x1b[38;5;202mWRN\x1b[0m | \x1b[1;38;5;111m{@object ?? typeof(Nullable)}\x1b[0m ] \x1b[1;38;5;202m{message}\x1b[0m\n";
    }
    
    public static string Build(string message, Type? @object = null)
    {
        return $"[{DateTime.Now:HH:mm:ss} | QLog/INF |  {@object ?? typeof(Nullable)}] {message}\n";
    }
    
    public static string Build(Exception message, Type? @object = null)
    {
        return $"[{DateTime.Now:HH:mm:ss} | QLog/ERR |  {@object ?? typeof(Nullable)}] {message}\n";
    }
    
    public static string BuildWarn(string message, Type? @object = null)
    {
        return $"[{DateTime.Now:HH:mm:ss} | QLog/WRN |  {@object ?? typeof(Nullable)}] {message}\n";
    }
}