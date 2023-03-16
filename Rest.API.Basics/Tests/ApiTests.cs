using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json;
using Rest.API.Basics.Models.View;
using Rest.API.Basics.Resources;
using Rest.API.Basics.Utils;
using RestSharp;

namespace Rest.API.Basics.Tests;

public class ApiTests
{
    private readonly RestClient _restClient;

    public ApiTests()
    {
        _restClient = new RestClient();
    }

    [Fact]
    public void GetAllPosts()
    {
        //Arrange
        var request = new RestRequest(Endpoints.GetAllPosts);

        //Act
        var response = _restClient.Execute(request);

        var allPosts = JsonConvert.DeserializeObject<List<PostsVm>>(response.Content);

        var sortedPosts = allPosts.OrderBy(p => p.Id).ToList();

        //Assert
        using (new AssertionScope())
        {
            Assert.Equal(allPosts, sortedPosts);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }

    [Fact]
    public void GetDefinitePostId()
    {
        var request = new RestRequest(Endpoints.GetDefinitePost);

        //Act
        var response = _restClient.Execute<PostsVm>(request);
        var post = JsonConvert.DeserializeObject<PostsVm>(response.Content);

        //Assert
        using (new AssertionScope())
        {
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            Assert.Equal(10, post.UserId);
            Assert.Equal(99, post.Id);
            if (post.Body != null)
                Assert.NotEmpty(post.Body);
        }
    }

    [Fact]
    public void GetPostBodyEmpty()
    {
        //Arrange
        var request = new RestRequest(Endpoints.GetPostWithEmptyBody);

        //Act
        var response = _restClient.Execute(request);

        //Assert
        using (new AssertionScope())
        {
            response.Content.Should().Be("{}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }

    [Fact]
    public void PostRequest()
    {
        //Arrange
        var request = new RestRequest(Endpoints.GetAllPosts, Method.Post);
        AddPostRequestModel.AddModel(request);

        //Act
        var response = _restClient.Execute(request);
        var createdPost = JsonConvert.DeserializeObject<PostsVm>(response.Content);

        //Assert
        using (new AssertionScope())
        {
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(AddPostRequestModel.PostsRequestModel.UserId, createdPost.UserId);
            Assert.Equal(AddPostRequestModel.PostsRequestModel.Title, createdPost.Title);
            Assert.Equal(AddPostRequestModel.PostsRequestModel.Body, createdPost.Body);
        }
    }

    [Fact]
    public void GetAllUsers()
    {
        //Arrange
        var expectedUser = JsonConvert.DeserializeObject<UsersVm>(WorkWithText.User);
        var serializedUser = JsonConvert.SerializeObject(expectedUser);

        var request = new RestRequest(Endpoints.GetAllUsers);

        //Act
        var response = _restClient.Execute(request);

        var users = JsonConvert.DeserializeObject<List<UsersVm>>(response.Content);

        var actualUser = JsonConvert.SerializeObject(users[4]);

        //Assert
        using (new AssertionScope())
        {
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            Assert.Equal(serializedUser, actualUser);
        }
    }

    [Fact]
    public void GetUserWithDefiniteId()
    {
        //Arrange
        var expectedUser = JsonConvert.DeserializeObject<UsersVm>(WorkWithText.User);
        var serializedUser = JsonConvert.SerializeObject(expectedUser);

        var request = new RestRequest(Endpoints.GetDefiniteUser);

        //Act
        var response = _restClient.Execute(request);

        var user = JsonConvert.DeserializeObject<UsersVm>(response.Content);

        var actualUser = JsonConvert.SerializeObject(user);

        //Assert
        using (new AssertionScope())
        {
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            Assert.Equal(serializedUser, actualUser);
        }
    }
}