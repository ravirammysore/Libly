using Libly.Core.APIClients;
using Libly.Core.Models;
using Moq;

namespace Libly.Test
{
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
        [InlineData("Book A", "2001-10-01", 2.5, 3.0)]
        [InlineData("Book B", "1987-05-25", 5.0, 4.0)]
        [InlineData("Book C", "2024-07-15", 1.0, 3.6)]
        [InlineData("Book D", "2024-05-21", 4.0, 5.4)]
        public void CalculateRent_ReturnsCorrectRent(string title, string dopString, double mockRating, double expectedRent)
        {
            // Arrange
            var mockApiClient = new Mock<IGoodreadsApiClient>();
            mockApiClient.Setup(client => client.GetBookRating(title))
                            .Returns(mockRating);

            var book = new Book 
            { 
                Title = title, 
                Dop = DateTime.Parse(dopString) 
            };

            // Act
            var result = book.CalculateRent(mockApiClient.Object);

            // Assert
            Assert.Equal(expectedRent, result, 1); // Allowing a precision of 1 decimal place
        }
    }
}