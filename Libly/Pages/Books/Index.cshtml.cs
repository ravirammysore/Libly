using Libly.Data;
using Libly.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Libly.Pages.Books
{
    public class IndexModel : PageModel
    {        
        private readonly BooksContext _context;

        public IndexModel(BooksContext context)
        {
            _context = context;
        }

        public List<Book> Books { get; set; }
        public void OnGet()
        {
            Books = _context.Books.Include(i => i.Category).ToList();
        }
    }
}
