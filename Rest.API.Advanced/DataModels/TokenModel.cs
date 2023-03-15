using Newtonsoft.Json;

namespace Rest.API.Advanced.DataModels;

public class TokenModel
{
    [JsonProperty("token")]
    public string? Token { get; set; }
}