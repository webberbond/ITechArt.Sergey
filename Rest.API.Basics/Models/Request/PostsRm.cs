namespace Rest.API.Basics.Models.Request;

public class PostsRm
{
    public string Title {get; set; }
    
    public string Body {get; set; }
    
    public int UserId {get; set; }
    
    public int Id {get; set; }
}