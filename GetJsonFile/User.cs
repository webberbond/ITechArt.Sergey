namespace GetJsonFile;

public class User
{
    public string Name { get; set; }

    public object LastName { get; set; }

    public dynamic Age { get; set; }

    public ICollection<int> RecordAmount { get; set; }

    public bool IsMale { get; set; }

    public double WalletAmount { get; set; }

    public string[] FavouriteSongs { get; set; }
}