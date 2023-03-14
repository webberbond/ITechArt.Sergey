using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json;
using Rest.API.Basics.Entities.DataFactory;
using Rest.API.Basics.Models.View;
using RestSharp;
using RestSharp.Serializers;

namespace Rest.API.Basics.Tests;

public class ApiTests
{
    [Fact]
    public void GetAllPosts()
    {
        //Arrange
        const string baseUrl = "https://jsonplaceholder.typicode.com";
        const string resource = "/posts";

        var postsRequestModel = PostsRequestModelFactory.CorrectModel;

        var request = new RestRequest(resource);
        request.AddParameter(ContentType.Json, postsRequestModel, ParameterType.RequestBody);
        var restClient = new RestClient(baseUrl);

        //Act
        var response = restClient.Execute(request);

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
        const string baseUrl = "https://jsonplaceholder.typicode.com";
        const string resource = "/posts/99";

        var request = new RestRequest(resource);
        var restClient = new RestClient(baseUrl);

        //Act
        var response = restClient.Execute<PostsVm>(request);
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
        const string baseUrl = "https://jsonplaceholder.typicode.com";
        const string resource = "/posts/150";

        var request = new RestRequest(resource);

        var restClient = new RestClient(baseUrl);

        //Act
        var response = restClient.Execute(request);

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
        const string baseUrl = "https://jsonplaceholder.typicode.com";
        const string resource = "/posts";

        var postsRequestModel = PostsRequestModelFactory.CorrectModel;

        var request = new RestRequest(resource, Method.Post);
        request.AddParameter(ContentType.Json, postsRequestModel, ParameterType.RequestBody);
        var restClient = new RestClient(baseUrl);

        //Act
        var response = restClient.Execute(request);
        var createdPost = JsonConvert.DeserializeObject<PostsVm>(response.Content);

        //Assert
        using (new AssertionScope())
        {
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(postsRequestModel.UserId, createdPost.UserId);
            Assert.Equal(postsRequestModel.Title, createdPost.Title);
            Assert.Equal(postsRequestModel.Body, createdPost.Body);
        }
    }

    [Fact]
    public void GetAllUsers()
    {
        //Arrange
        const string baseUrl = "https://jsonplaceholder.typicode.com";
        const string resource = "/users";

        var user = File.ReadAllText("Entities/Data/User.json");
        var expectedUser = JsonConvert.DeserializeObject<UsersVm>(user);
        var serializedUser = JsonConvert.SerializeObject(expectedUser);

        var request = new RestRequest(resource);
        var restClient = new RestClient(baseUrl);

        //Act
        var response = restClient.Execute(request);

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
        const string baseUrl = "https://jsonplaceholder.typicode.com";
        const string resource = "/users/5";

        var userJson = File.ReadAllText("Entities/Data/User.json");
        var expectedUser = JsonConvert.DeserializeObject<UsersVm>(userJson);
        var serializedUser = JsonConvert.SerializeObject(expectedUser);

        var request = new RestRequest(resource);
        var restClient = new RestClient(baseUrl);

        //Act
        var response = restClient.Execute(request);

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