﻿namespace Rest.API.Basics.Models.View;

public class PostsVm
{
    public int? UserId { get; set; }

    public int? Id { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }
}