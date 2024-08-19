using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libly.Data;
using Libly.Models;

namespace Libly.Pages.Books
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet(int id)
        {
            // Retrieve the book to be edited
            Book = BooksData.GetById(id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Return the same page with validation errors if the model state is invalid
                return Page();
            }

            // Update the book in the static collection
            BooksData.Update(Book);

            // Redirect back to the Index page after successful update
            return RedirectToPage("./Index");
        }
    }
}
