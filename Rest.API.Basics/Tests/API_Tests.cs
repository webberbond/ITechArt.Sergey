using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using Rest.API.Basics.Entities.DataFactory;
using Rest.API.Basics.Models.View;
using RestSharp;
using RestSharp.Serializers;

namespace Rest.API.Basics.Tests;

public class API_Tests
{
    [Fact]
    public void GetAllPosts() {
        //Arrange
        var baseUrl = "https://jsonplaceholder.typicode.com";
        var resource = "/posts";
        
        var postsRequestModel = PostsRequestModelFactory.CorrectModel;

        var request = new RestRequest(resource);
        request.AddParameter(ContentType.Json, postsRequestModel, ParameterType.RequestBody);
        var restClient = new RestClient(baseUrl);

        //Act
        var response = restClient.Execute<PostsVm>(request);
        
        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public void GetDefinitePostId()
    {
        const string baseUrl = "https://jsonplaceholder.typicode.com";
        const string resource = "/posts/99";
        
        var expectedPostVm = new PostsVm {
            UserId = 10,
            Id = 99,
            Title = @"temporibus sit alias delectus eligendi possimus magni",
            Body = "quo deleniti praesentium dicta non quod\naut est molestias\nmolestias et officia quis nihil\nitaque dolorem quia"
        };
        
        var request = new RestRequest(resource);
        var restClient = new RestClient(baseUrl);

        //Act
        var response = restClient.Execute<PostsVm>(request);
        var postsVm = response.Data;

        //Assert
        using (new AssertionScope()) {
            postsVm.Should().BeEquivalentTo(expectedPostVm); 
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }

    [Fact]
    public void GetPostBodyEmpty() {
        //Arrange
        const string baseUrl = "https://jsonplaceholder.typicode.com";
        const string resource = "/posts/150";
        
        var request = new RestRequest(resource);

        var restClient = new RestClient(baseUrl);
        
        //Act
        var response = restClient.Execute<PostsVm>(request);

        //Assert
        using (new AssertionScope()) {
            response.Content.Should().Be("{}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
    
    [Fact]
    public void PostRequest() {
        //Arrange
        const string baseUrl = "https://jsonplaceholder.typicode.com";
        const string resource = "/posts";

        var postsRequestModel = PostsRequestModelFactory.CorrectModel;
        
        var request = new RestRequest(resource, Method.Post);
        request.AddParameter(ContentType.Json, postsRequestModel, ParameterType.RequestBody);
        var restClient = new RestClient(baseUrl);

        //Act
        var response = restClient.Execute(request);

        //Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public void GetAllUsers() {
        //Arrange
        const string baseUrl = "https://jsonplaceholder.typicode.com";
        const string resource = "/users";
        
        var request = new RestRequest(resource);
        var restClient = new RestClient(baseUrl);

        //Act
        var response = restClient.Execute<UsersVm>(request);

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
    }

    [Fact]
    public void GetUserWithDefiniteId()
    {
        //Arrange
        const string baseUrl = "https://jsonplaceholder.typicode.com";
        const string resource = "/users/5";

        var expectedUser = new UsersVm {
            Id = 5,
            Name = "Chelsey Dietrich",
            Username = "Kamren",
            Email = "Lucio_Hettinger@annie.ca",
            Address = new Address {
                Street = "Skiles Walks",
                Suite = "Suite 351",
                City = "Roscoeview",
                ZipCode = "33263",
                Geo = new Geo {
                    Lat = "-31.8129",
                    Lng = "62.5342"
                }
            },
            Phone = "(254)954-1289",
            Website = "demarco.info",
            Company = new Company {
                Name = "Keebler LLC",
                CatchPhrase = "User-centric fault-tolerant solution",
                Bs = "revolutionize end-to-end systems"
            }
        };
        
        var request = new RestRequest(resource);
        var restClient = new RestClient(baseUrl);
        
        //Act
        var response = restClient.Execute<UsersVm>(request);
        var usersVm = response.Data;
        
        //Assert
        using (new AssertionScope()) {
            usersVm.Should().BeEquivalentTo(expectedUser);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}