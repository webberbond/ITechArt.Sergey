using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using XUnitCalculator.Calculator;
using Xunit.DependencyInjection.Logging;
using ITestOutputHelperAccessor = Xunit.DependencyInjection.ITestOutputHelperAccessor;

namespace XUnitCalculator;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ICalculator, Calculator.Calculator>();
    }

    public void Configure(ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor)
    {
        loggerFactory.AddProvider(new XunitTestOutputLoggerProvider(accessor, (s, level) => level >=
            LogLevel.Debug && level < LogLevel.None));
    }
}