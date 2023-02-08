using Newtonsoft.Json.Linq;

namespace SeleniumWrapper.Helpers;

public static class JsonReader
{
    public static string? GetValueByKey(string path,string key)
    {
        return (string)JObject.Parse(ReadJsonFile(path))[key]!;
    }

    public static TimeSpan GetTimeSpanValue(string path)
    {
        return new(Convert.ToInt32(GetValueByKey(path,"hours")),Convert.ToInt32(GetValueByKey(path,"minutes")),Convert.ToInt32(GetValueByKey(path,"seconds")));
    }
        
    private static string ReadJsonFile(string path)
    {
        using var sr = new StreamReader(path);
        return sr.ReadToEnd();
    }
}