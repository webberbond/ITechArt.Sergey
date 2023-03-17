using Rest.API.Advanced.DataModels;

namespace Rest.API.Advanced.TestData;

public static class Authentication
{
    public static UserTokenModel UserTokenDetails()
    {
        return new UserTokenModel
        {
            Username = "admin",
            Password = "password123"
        };
    }
}