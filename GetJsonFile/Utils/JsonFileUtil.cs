using System.Text.Json;
using System.Text.Json.Serialization;

namespace GetJsonFile.Utils;

public static class JsonFileUtil
{
    private static readonly JsonSerializerOptions Options =
        new() {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull};

    public static void SimpleWrite(object obj, string fileName)
    {
        var jsonString = JsonSerializer.Serialize(obj, Options);
        File.WriteAllText(fileName, jsonString);
    }
}