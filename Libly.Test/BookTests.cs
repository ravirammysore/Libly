using Libly.Core.Models;

namespace Libly.Test
{
    public class BookTests
    {
        [Fact]       
        public void GetFormattedTitle_ReturnsCorrectlyFormattedTitle()
        {
            // Arrange
            var book = new Book { Title = "the great gatsby" };

            // Act
            var result = book.GetFormattedTitle();

            // Assert
            Assert.Equal("The Great Gatsby", result);
        }
    }
}