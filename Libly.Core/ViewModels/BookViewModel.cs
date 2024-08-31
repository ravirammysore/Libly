using System.ComponentModel.DataAnnotations;

namespace Libly.Core.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "We need a title for the book!")]
        public string Title { get; set; }
        public DateTime Dop { get; set; }
        public int CategoryId { get; set; }
    }

}
