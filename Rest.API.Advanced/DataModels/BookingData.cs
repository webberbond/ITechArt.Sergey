﻿using Newtonsoft.Json;

namespace Rest.API.Advanced.DataModels;

public class BookingData
{
    [JsonProperty("firstname")] public string? Firstname { get; set; }

    [JsonProperty("lastname")] public string? Lastname { get; set; }

    [JsonProperty("totalprice")] public long Totalprice { get; set; }

    [JsonProperty("depositpaid")] public bool Depositpaid { get; set; }

    [JsonProperty("bookingdates")] public Bookingdates? Bookingdates { get; set; }

    [JsonProperty("additionalneeds")] public string? Additionalneeds { get; set; }
}

public class Bookingdates
{
    [JsonProperty("checkin")] public DateTime Checkin { get; set; }

    [JsonProperty("checkout")] public DateTime Checkout { get; set; }
}