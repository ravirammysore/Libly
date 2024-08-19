using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libly.Data;
using Libly.Models;

namespace Libly.Pages.Books
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet(int id)
        {
            // Retrieve the book to be deleted
            Book = BooksData.GetById(id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            // Delete the book from the static collection
            BooksData.Delete(Book.Id);

            // Redirect back to the Index page after deletion
            return RedirectToPage("./Index");
        }
    }
}
