using GetJsonFile.Utils;

namespace GetJsonFile;

internal static class Program
{
    public static void Main()
    {
        var user = new User
        {
            Name = "Arslan",
            LastName = "Berkut",
            Age = 21,
            RecordAmount = new List<int> {100, 350, 680, 1000},
            IsMale = true,
            WalletAmount = 321.128,
            FavouriteSongs = new[]
            {
                "NF - Hope",
                "Drake and 21 Savage - Spin Bout U",
                "SZA - Low",
                "Finesse2Tymes - Back End"
            }
        };


        var filepath = "../../../JsonFile";
        if (!Directory.Exists(filepath)) Directory.CreateDirectory(filepath);

        var filename = "../../../JsonFile/User.json";
        JsonFileUtil.SimpleWrite(user, filename);
    }
}