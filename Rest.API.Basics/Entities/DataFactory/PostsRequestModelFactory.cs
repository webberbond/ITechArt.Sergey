using Rest.API.Basics.Entities.DataFaker;
using Rest.API.Basics.Models.Request;

namespace Rest.API.Basics.Entities.DataFactory;

public static class PostsRequestModelFactory
{
    public static readonly PostsRm CorrectModel = PostsRequestModelFaker.CorrectModel();
}