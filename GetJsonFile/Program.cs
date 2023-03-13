using Newtonsoft.Json;

namespace GetJsonFile;

internal static class Program
{
    public static void Main()
    {
        User[] users = {
            new()
            {
                Name = "Sergey",
                LastName = "Zarochentsev",
                Age = "20",
                RecordAmount = new List<int> {1, 3, 7, 9},
                IsMale = true,
                WalletAmount = 100.15,
                FavouriteSongs = new[]
                {
                    "Buddy Holly - Weezer",
                    "Josie - Blink-182",
                    "Helena - My Chemical Romance"
                }
            }
        };
        
        string json =  JsonConvert.SerializeObject(users, Formatting.Indented);
        
        File.WriteAllText(@"..\..\..\Data\users.json", json);
    }
}