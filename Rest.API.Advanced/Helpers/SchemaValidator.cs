using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace Rest.API.Advanced.Helpers;

public class SchemaValidator
{
    public static bool ValidateResponse(string jsonResponse, string jsonSchema)
    {
        // Parse JSON schema
        var schema = JSchema.Parse(jsonSchema);

        // Parse JSON response
        var response = JsonConvert.DeserializeObject<JObject>(jsonResponse);

        // Validate JSON response against JSON schema
        var isValid = response.IsValid(schema);

        return isValid;
    }
}