using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Libly.Core.Data;
using Libly.Core.Models;


namespace Libly.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly BooksContext _context;
        public DeleteModel(BooksContext context)
        {
            _context = context; 
        }
        [BindProperty]
        public Book? Book { get; set; }

        public IActionResult OnGet(int id)
        {
            // Retrieve the book to be deleted
            Book = _context.Books
                            .Include(b => b.Category)
                            .SingleOrDefault(b => b.Id == id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            // Delete the book from the static collection
            _context.Books.Remove(Book);
            _context.SaveChanges();

            // Redirect back to the Index page after deletion
            return RedirectToPage("./Index");
        }
    }
}
