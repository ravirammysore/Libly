using Libly.Core.APIClients;
using Libly.Core.Models;
using Moq;
using FluentAssertions;

namespace Libly.Test;

public class BookTests
{
    [Theory]
    [InlineData("the great gatsby", "The Great Gatsby")]
    [InlineData("TO KILL A MOCKINGBIRD", "To Kill a Mockingbird")]
    [InlineData("the catcher in the rye", "The Catcher in the Rye")]
    [InlineData("a tale of two cities", "A Tale of Two Cities")]
    [InlineData("", "")]
    [InlineData("the", "The")]
    public void GetFormattedTitle_ReturnsCorrectlyFormattedTitle(string input, string expected)
    {
        // Arrange
        var book = new Book { Title = input };

        // Act
        var result = book.GetFormattedTitle();

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("2001-10-01", 2.5, 3.0)]
    [InlineData("1987-05-25", 5.0, 4.0)]
    [InlineData("2024-07-15", 1.0, 3.6)]
    [InlineData("2024-05-21", 4.0, 5.4)]
    public void CalculateRent_ReturnsCorrectRent(string dopString, double mockRating, double expectedRent)
    {
        //Arrange           
        var cut = new Book 
        { 
            Title = It.IsAny<string>(), 
            Dop = DateTime.Parse(dopString) 
        };

        var mockApiClient = new Mock<IGoodreadsApiClient>();
        mockApiClient.Setup(client => client.GetBookRating(cut.Title))
                        .Returns(mockRating);

        //Assert            
        cut.CalculateRent(mockApiClient.Object)
            .Should()
            .BeApproximately(expectedRent, 0.1);
    }
}