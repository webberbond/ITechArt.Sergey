using System.Net;
using FluentAssertions.Execution;
using Rest.API.Advanced.DataModels;
using Rest.API.Advanced.Helpers;
using Rest.API.Advanced.TestData;

namespace Rest.API.Advanced.Tests;


public class BookingTests : ApiBaseTest
{
    [Fact]
    public async Task CreateBooking()
    {
        var restResponse = await BookingHelper.AddNewBooking(RestClient);
        BookingDetails = restResponse.Data;
        Assert.Equal(HttpStatusCode.OK, restResponse.StatusCode);
        //Arrange
        var expectedData = GenerateBookingData.BookingDetails();
        
        //Act
        if (BookingDetails != null)
        {
            var createdBooking = await BookingHelper.GetBookingById(RestClient, BookingDetails.BookingId);

            //Assert
            using (new AssertionScope())
            {
                Assert.Equal(expectedData.Firstname, createdBooking.Data?.Firstname);
                Assert.Equal(expectedData.Lastname, createdBooking.Data?.Lastname);
            
                if (createdBooking.Data != null)
                {
                    Assert.Equal(expectedData.Totalprice, createdBooking.Data.Totalprice);
                    Assert.Equal(expectedData.Depositpaid, createdBooking.Data.Depositpaid);
                    if (expectedData.Bookingdates != null)
                    {
                        if (createdBooking.Data.Bookingdates != null)
                        {
                            Assert.Equal(expectedData.Bookingdates.Checkin, createdBooking.Data.Bookingdates.Checkin);
                            Assert.Equal(expectedData.Bookingdates.Checkout, createdBooking.Data.Bookingdates.Checkout);
                        }
                    }

                    Assert.Equal(expectedData.Additionalneeds, createdBooking.Data.Additionalneeds);
                }
            }
        }
    }
    
    [Fact]
    public async Task UpdateBooking()
    {
        var restResponse = await BookingHelper.AddNewBooking(RestClient);
        BookingDetails = restResponse.Data;
        Assert.Equal(HttpStatusCode.OK, restResponse.StatusCode);
        if (BookingDetails != null)
        {
            var getCreatedBooking = await BookingHelper.GetBookingById(RestClient, BookingDetails.BookingId);
        
            var updatedData = new BookingData()
            {
                Firstname = "Arslan",
                Lastname = "Munasipov",
                Totalprice = 200,
                Depositpaid = false,
                Bookingdates = getCreatedBooking.Data?.Bookingdates,
                Additionalneeds = "Lunch"
            };

            var updateBooking = await BookingHelper.UpdateBookingById(RestClient, updatedData, BookingDetails.BookingId);
        
            var getUpdatedBooking = await BookingHelper.GetBookingById(RestClient, BookingDetails.BookingId);

            using (new AssertionScope())
            {
                Assert.Equal(HttpStatusCode.OK, updateBooking.StatusCode);
                Assert.Equal(updatedData.Firstname, getUpdatedBooking.Data?.Firstname);
                Assert.Equal(updatedData.Lastname, getUpdatedBooking.Data?.Lastname);
                if (getUpdatedBooking.Data != null)
                {
                    Assert.Equal(updatedData.Totalprice, getUpdatedBooking.Data.Totalprice);
                    Assert.Equal(updatedData.Depositpaid, getUpdatedBooking.Data.Depositpaid);
                    if (updatedData.Bookingdates != null)
                    {
                        if (getUpdatedBooking.Data.Bookingdates != null)
                        {
                            Assert.Equal(updatedData.Bookingdates.Checkin, getUpdatedBooking.Data.Bookingdates.Checkin);
                            Assert.Equal(updatedData.Bookingdates.Checkout, getUpdatedBooking.Data.Bookingdates.Checkout);
                        }
                    }

                    Assert.Equal(updatedData.Additionalneeds, getUpdatedBooking.Data.Additionalneeds);
                }
            }
        }
    }

    [Fact]
    public async Task DeleteBooking()
    { 
        var restResponse = await BookingHelper.AddNewBooking(RestClient);
        BookingDetails = restResponse.Data;
        Assert.Equal(HttpStatusCode.OK, restResponse.StatusCode);
        if (BookingDetails != null)
        {
            var deleteBooking = await BookingHelper.DeleteBookingById(RestClient, BookingDetails.BookingId);
        
            Assert.Equal(HttpStatusCode.Created, deleteBooking.StatusCode);
        }
    }
}