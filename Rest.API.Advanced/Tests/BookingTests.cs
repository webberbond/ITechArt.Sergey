using System.Net;
using FluentAssertions;
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
        //Arrange
        var expectedData = GenerateBookingData.BookingDetails();
        var restResponse = await BookingHelper.AddNewBooking(RestClient);
        const string jsonSchemaPath = "Schemas/JsonSchema.json";

        BookingDetails = restResponse.Data;

        //Act
        var createdBooking = await BookingHelper.GetBookingById(RestClient, BookingDetails.BookingId);
        var jsonResponse = createdBooking.Content;
        var jsonSchema = await File.ReadAllTextAsync(jsonSchemaPath);
        var isValid = SchemaValidator.ValidateResponse(jsonResponse, jsonSchema);

        //Assert
        using (new AssertionScope())
        {
            restResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            createdBooking.Data?.Firstname.Should().Be(expectedData.Firstname);
            createdBooking.Data?.Lastname.Should().Be(expectedData.Lastname);
            createdBooking.Data?.Totalprice.Should().Be(expectedData.Totalprice);
            createdBooking.Data?.Depositpaid.Should().Be(expectedData.Depositpaid);
            createdBooking.Data?.Bookingdates?.Checkin.Should().Be(expectedData.Bookingdates.Checkin);
            createdBooking.Data?.Bookingdates?.Checkout.Should().Be(expectedData.Bookingdates.Checkout);
            createdBooking.Data?.Additionalneeds.Should().Be(expectedData.Additionalneeds);
            Assert.True(isValid, "The response did not match the schema.");
        }
    }

    [Fact]
    public async Task UpdateBooking()
    {
        //Arrange
        var restResponse = await BookingHelper.AddNewBooking(RestClient);

        BookingDetails = restResponse.Data;

        const string jsonSchemaPath = "Schemas/JsonSchema.json";

        //Act
        var createdBooking = await BookingHelper.GetBookingById(RestClient, BookingDetails.BookingId);

        var updatedData = new BookingData
        {
            Firstname = "Arslan",
            Lastname = "Munasipov",
            Totalprice = 200,
            Depositpaid = false,
            Bookingdates = createdBooking.Data?.Bookingdates,
            Additionalneeds = "Lunch"
        };

        var updateBooking = await BookingHelper.UpdateBookingById(RestClient, updatedData, BookingDetails.BookingId);

        var updatedBooking = await BookingHelper.GetBookingById(RestClient, BookingDetails.BookingId);

        var jsonResponse = updatedBooking.Content;
        var jsonSchema = await File.ReadAllTextAsync(jsonSchemaPath);
        var isValid = SchemaValidator.ValidateResponse(jsonResponse, jsonSchema);

        //Assert
        using (new AssertionScope())
        {
            restResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            updateBooking.StatusCode.Should().Be(HttpStatusCode.OK);
            updatedBooking.Data?.Firstname.Should().Be(updatedData.Firstname);
            updatedBooking.Data?.Lastname.Should().Be(updatedData.Lastname);
            updatedBooking.Data?.Totalprice.Should().Be(updatedData.Totalprice);
            updatedBooking.Data?.Depositpaid.Should().Be(updatedData.Depositpaid);
            updatedBooking.Data?.Bookingdates?.Checkin.Should().Be(updatedData.Bookingdates.Checkin);
            updatedBooking.Data?.Bookingdates?.Checkout.Should().Be(updatedData.Bookingdates.Checkout);
            updatedBooking.Data?.Additionalneeds.Should().Be(updatedData.Additionalneeds);
            Assert.True(isValid, "The response did not match the schema.");
        }
    }

    [Fact]
    public async Task DeleteBooking()
    {
        //Arrange
        var restResponse = await BookingHelper.AddNewBooking(RestClient);

        BookingDetails = restResponse.Data;

        //Act
        await BookingHelper.DeleteBookingById(RestClient, BookingDetails.BookingId);

        var deletedBooking = await BookingHelper.GetBookingById(RestClient, BookingDetails.BookingId);

        //Assert
        using (new AssertionScope())
        {
            restResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            deletedBooking.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}