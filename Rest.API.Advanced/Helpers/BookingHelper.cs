using Rest.API.Advanced.DataModels;
using Rest.API.Advanced.Resources;
using Rest.API.Advanced.TestData;
using RestSharp;

namespace Rest.API.Advanced.Helpers;

public static class BookingHelper
{
    public static async Task<RestResponse<BookingModel>> AddNewBooking(RestClient restClient)
    {
        restClient = new RestClient();
        restClient.AddDefaultHeader("Accept", "application/json");

        var postRequest =
            new RestRequest(Endpoints.BaseBookingMethod, Method.Post).AddJsonBody(GenerateBookingData.BookingDetails());

        return await restClient.ExecuteAsync<BookingModel>(postRequest);
    }

    public static async Task<RestResponse<BookingData>> GetBookingById(RestClient restClient, int bookingId)
    {
        var token = await GetAuthToken(restClient);
        restClient = new RestClient();
        restClient.AddDefaultHeader("Accept", "application/json");
        restClient.AddDefaultHeader("Cookie", "token=" + token);

        var getRequest = new RestRequest(Endpoints.BookingById(bookingId));

        return await restClient.ExecuteAsync<BookingData>(getRequest);
    }

    public static async Task<RestResponse> DeleteBookingById(RestClient restClient, int bookingId)
    {
        var token = await GetAuthToken(restClient);
        restClient = new RestClient();
        restClient.AddDefaultHeader("Accept", "application/json");
        restClient.AddDefaultHeader("Cookie", "token=" + token);

        var getRequest = new RestRequest(Endpoints.BookingById(bookingId), Method.Delete);

        return await restClient.ExecuteAsync(getRequest);
    }

    public static async Task<RestResponse<BookingData>> UpdateBookingById(RestClient restClient, BookingData booking,
        int bookingId)
    {
        var token = await GetAuthToken(restClient);
        restClient = new RestClient();
        restClient.AddDefaultHeader("Accept", "application/json");
        restClient.AddDefaultHeader("Cookie", "token=" + token);

        var putRequest = new RestRequest(Endpoints.BookingById(bookingId), Method.Put).AddJsonBody(booking);

        return await restClient.ExecuteAsync<BookingData>(putRequest);
    }

    private static async Task<string?> GetAuthToken(RestClient restClient)
    {
        restClient = new RestClient();
        restClient.AddDefaultHeader("Accept", "application/json");

        var postRequest = new RestRequest(Endpoints.GenerateToken).AddJsonBody(Authentication.UserTokenDetails());

        var generateToken = await restClient.ExecutePostAsync<TokenModel>(postRequest);

        return generateToken.Data?.Token;
    }
}