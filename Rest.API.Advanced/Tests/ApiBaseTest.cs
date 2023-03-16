using Rest.API.Advanced.DataModels;
using RestSharp;

namespace Rest.API.Advanced.Tests;

public class ApiBaseTest
{
    protected RestClient RestClient { get; private set; }

    protected BookingModel BookingDetails { get; set; }
}