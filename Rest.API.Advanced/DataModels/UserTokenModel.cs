using Newtonsoft.Json;

namespace Rest.API.Advanced.DataModels;

public class UserTokenModel
{
    [JsonProperty("username")]
    public string? Username { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }
}