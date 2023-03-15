using Rest.API.Advanced.DataModels;

namespace Rest.API.Advanced.TestData;

public static class GenerateBookingData
{
    public static BookingData BookingDetails()
    {
        var dateTime = DateTime.UtcNow.Date;

        var bookingDates = new Bookingdates
        {
            Checkin = dateTime.AddDays(2),
            Checkout = dateTime.AddDays(5)
        };
        
        return new BookingData()
        {
            Firstname = "Sergey",
            Lastname = "Zarochentsev",
            Totalprice = 600,
            Depositpaid = true,
            Bookingdates = bookingDates,
            Additionalneeds = "Breakfast"
        };
    }
}