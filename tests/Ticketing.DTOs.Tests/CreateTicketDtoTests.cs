using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Ticketing.DTOs.Tests;

public class CreateTicketDtoTests
{

    [Theory]
    [InlineData("+989000000000", "armin@gmail.com")]
    [InlineData(null, null)]
    public void No_Exception_Thrown_When_PhoneNumber_And_Email_Has_Value_Or_Null(string phoneNumber, string email)
    {
        // Arrange
        CreateTicketDto createTicketDto = new()
        {
            PhoneNumber = phoneNumber,
            Email = email,
        };
        // Act
        Exception recordedException = Record.Exception(() => Validator.ValidateObject(createTicketDto, new(createTicketDto)));

        // Assert
        Assert.Null(recordedException);
    }

    [Theory]
    [InlineData("+989000000000", null)]
    [InlineData(null, "armin@gmail.com")]
    public void Exception_Thrown_When_PhoneNumber_Or_Email_Is_Null(string phoneNumber, string email)
    {
        // Arrange
        CreateTicketDto createTicketDto = new()
        {
            PhoneNumber = phoneNumber,
            Email = email,
        };
        // Act & Assert
        Assert.Throws<ValidationException>(() => Validator.ValidateObject(createTicketDto, new(createTicketDto)));
    }


}
