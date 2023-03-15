using Rest.API.Advanced.DataModels;
using RestSharp;

namespace Rest.API.Advanced.Tests;

public class ApiBaseTest : IDisposable
{
    protected RestClient RestClient { get; set; }

    protected BookingModel BookingDetails { get; set; }


    public async void Dispose()
    {
        RestClient = null;
    }
}