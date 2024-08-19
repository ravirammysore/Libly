using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libly.Data;
using Libly.Models;

namespace Libly.Pages.Books
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            BooksData.Create(Book);

            return RedirectToPage("./Index");
        }
    }
}
