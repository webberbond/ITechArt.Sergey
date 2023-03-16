namespace Rest.API.Advanced.Resources;

public static class Endpoints
{
    private const string BaseUrl = "https://restful-booker.herokuapp.com/";

    private const string UserEndpoint = "booking";

    private const string AuthEndpoint = "auth";

    public static string BaseBookingMethod => $"{BaseUrl}{UserEndpoint}";

    public static string GenerateToken => $"{BaseUrl}{AuthEndpoint}";

    public static string BookingById(int bookingId)
    {
        return $"{BaseUrl}{UserEndpoint}/{bookingId}";
    }
}