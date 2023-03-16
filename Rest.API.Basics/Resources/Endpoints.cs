namespace Rest.API.Basics.Resources;

public static class Endpoints
{
    private const string BaseUrl = "https://jsonplaceholder.typicode.com";

    private const string AllPosts = "/posts";

    private const string DefinitePost = "/posts/99";

    private const string PostWithEmptyBody = "/posts/150";

    private const string AllUsers = "/users";

    private const string DefiniteUser = "/users/5";

    public static string GetAllPosts => $"{BaseUrl}{AllPosts}";

    public static string GetDefinitePost => $"{BaseUrl}{DefinitePost}";

    public static string GetPostWithEmptyBody => $"{BaseUrl}{PostWithEmptyBody}";

    public static string GetAllUsers => $"{BaseUrl}{AllUsers}";

    public static string GetDefiniteUser => $"{BaseUrl}{DefiniteUser}";
}