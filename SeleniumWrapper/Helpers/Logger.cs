using LogLevel = NLog.LogLevel;

namespace SeleniumWrapper.Helpers;

public sealed class Logger
{
    private static readonly Lazy<Logger> LazyInstance = new(() => new Logger());

    private readonly ILogger _log = LogManager.GetLogger(Thread.CurrentThread.ManagedThreadId.ToString());

    private Logger()
    {
        try
        {
            LogManager.LoadConfiguration("NLog.config");
        }
        catch (FileNotFoundException)
        {
            LogManager.Configuration = GetConfiguration();
        }
    }

    private LoggingConfiguration GetConfiguration()
    {
        var str = "${date:format=yyyy-MM-dd HH\\:mm\\:ss} ${level:uppercase=true} - ${message}";
        var configuration = new LoggingConfiguration();

        // for console
        var info = LogLevel.Info;
        var fatal1 = LogLevel.Fatal;
        var consoleTarget = new ConsoleTarget("logconsole");
        consoleTarget.Layout = str;
        configuration.AddRule(info, fatal1, consoleTarget);

        // for file
        var debug = LogLevel.Debug;
        var fatal2 = LogLevel.Fatal;
        var fileTarget = new FileTarget("logfile");
        fileTarget.DeleteOldFileOnStartup = true;
        fileTarget.FileName = "../../../Log/log.log";
        fileTarget.Layout = str;
        configuration.AddRule(debug, fatal2, fileTarget);
        return configuration;
    }

    public static Logger Instance => LazyInstance.Value;

    public void Debug(string message)
    {
        _log.Debug(message);
    }

    public void Info(string message)
    {
        _log.Info(message);
    }

    public void Warn(string message)
    {
        _log.Warn(message);
    }

    public void Error(string message)
    {
        _log.Error(message);
    }

    public void Fatal(string message)
    {
        _log.Fatal(message);
    }
}