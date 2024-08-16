using Libly.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libly.Pages.Books
{    
    public class IndexModel : PageModel
    {
        public List<Book> Books { get; set; }
        public void OnGet()
        {
            Books = new List<Book>
            {
                new Book(1, "The Great Gatsby", "Fiction", new DateTime(1925, 4, 10)),
                new Book(2, "To Kill a Mockingbird", "Fiction", new DateTime(1960, 7, 11)),
                new Book(3, "1984", "Dystopian", new DateTime(1949, 6, 8)),
                new Book(4, "Pride and Prejudice", "Romance", new DateTime(1813, 1, 28))
            };
        }
    }   
}
