using Newtonsoft.Json;

namespace Rest.API.Advanced.DataModels;

public class BookingModel
{
    [JsonProperty("bookingid")]
    public int BookingId { get; set; }

    [JsonProperty("booking")]
    public BookingData? Booking { get; set; }
}