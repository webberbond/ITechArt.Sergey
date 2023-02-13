namespace SeleniumWrapper.Utils;

public record BrowserProfile
{
    public BrowserEnum BrowserName { get; init; }

    public string[]? BrowserSettings { get; init; }

    public int ConditionTimeWait { get; init; }
};