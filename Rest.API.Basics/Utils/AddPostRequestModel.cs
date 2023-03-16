using Rest.API.Basics.Entities.DataFactory;
using Rest.API.Basics.Models.View;
using RestSharp;
using RestSharp.Serializers;

namespace Rest.API.Basics.Utils;

public static class AddPostRequestModel
{
    public static readonly PostsVm PostsRequestModel = PostsRequestModelFactory.CorrectModel;


    public static void AddModel(RestRequest request)
    {
        request.AddParameter(ContentType.Json, PostsRequestModel, ParameterType.RequestBody);
    }
}