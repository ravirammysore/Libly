
namespace Libly.Core.Dtos
{
    public class BookUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Dop { get; set; }
        public int CategoryId { get; set; }
    }
}
