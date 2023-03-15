using Rest.API.Advanced.DataModels;

namespace Rest.API.Advanced.TestData;

public static class Authentication
{
    public static UserTokenModel userTokenDetails()
    {
        return new UserTokenModel
        {
            Username = "admin",
            Password = "password123"
        };
    }
}