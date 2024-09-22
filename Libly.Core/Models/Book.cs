using Libly.Core.APIClients;
using System;
using System.ComponentModel.DataAnnotations;

namespace Libly.Core.Models
{
    public class Book : BaseModel
    {
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dop { get; set; }

        // Navigation property to Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Parameterless constructor
        public Book() : base()
        {
        }

        // Parameterized constructor
        public Book(int id, string title, DateTime dop, int categoryId) : this()
        {
            Id = id;
            Title = title;
            Dop = dop;
            CategoryId = categoryId;
        }

        // New method for formatting the title
        public string GetFormattedTitle()
        {
            if (string.IsNullOrWhiteSpace(Title))
                return string.Empty;

            var words = Title.Split(' ');
            var formattedWords = words.Select((word, index) =>
                ShouldCapitalize(word, index == 0, index == words.Length - 1)
                    ? CapitalizeWord(word)
                    : word.ToLower()
            );

            return string.Join(" ", formattedWords);
        }

        private bool ShouldCapitalize(string word, bool isFirst, bool isLast)
        {
            var lowercaseWords = new[] { "a", "an", "the", "in", "of", "and", "but", "or" };
            return isFirst || isLast || !lowercaseWords.Contains(word.ToLower());
        }

        private string CapitalizeWord(string word)
        {
            if (string.IsNullOrEmpty(word))
                return word;

            return char.ToUpper(word[0]) + word.Substring(1).ToLower();
        }

        public double CalculateRent(IGoodreadsApiClient goodreadsApiClient)
        {
            double rating = goodreadsApiClient.GetBookRating(Title);
            
            // Base rent
            double baseRent = 2.0; 

            // Calculate rent based on DOP and rating:
            
            // Newer books cost more
            double ageFactor = (DateTime.Now - Dop).TotalDays < 180 ? 1.5 : 1.0;
            
            // Normalize rating to a factor between 0 and 1
            double ratingFactor = rating / 5.0; 

            return baseRent * ageFactor * (1 + ratingFactor);
        }
    }
}
