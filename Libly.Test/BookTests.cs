using Libly.Core.Models;

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
    }
}