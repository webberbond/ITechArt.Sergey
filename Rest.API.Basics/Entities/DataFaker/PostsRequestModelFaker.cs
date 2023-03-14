using Bogus;
using Rest.API.Basics.Models.View;

namespace Rest.API.Basics.Entities.DataFaker;

public static class PostsRequestModelFaker
{
    public static Faker<PostsVm> CorrectModel()
    {
        return new Faker<PostsVm>()
            .RuleFor(u => u.UserId, f => f.Random.Int(0))
            .RuleFor(u => u.Title, f => f.Lorem.Sentence(15))
            .RuleFor(u => u.Body, f => f.Lorem.Sentence(40));
    }
}