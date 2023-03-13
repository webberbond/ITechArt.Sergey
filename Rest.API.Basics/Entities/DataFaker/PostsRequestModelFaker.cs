using Bogus;
using Rest.API.Basics.Models.Request;

namespace Rest.API.Basics.Entities.DataFaker;

public static class PostsRequestModelFaker
{
    public static Faker<PostsRm> CorrectModel()
    {
        return new Faker<PostsRm>()
            .RuleFor(u => u.Id, f => f.Random.Int(0))
            .RuleFor(u => u.UserId, f => f.Random.Int(0))
            .RuleFor(u => u.Title, f => f.Random.String(15))
            .RuleFor(u => u.Body, f => f.Random.String(40));
    }
}