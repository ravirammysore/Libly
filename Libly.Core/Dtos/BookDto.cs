namespace Libly.Core.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Dop { get; set; }
        public string FormattedTitle { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}