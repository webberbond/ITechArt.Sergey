using Rest.API.Basics.Entities.DataFaker;
using Rest.API.Basics.Models.View;

namespace Rest.API.Basics.Entities.DataFactory;

public static class PostsRequestModelFactory
{
    public static readonly PostsVm CorrectModel = PostsRequestModelFaker.CorrectModel();
}