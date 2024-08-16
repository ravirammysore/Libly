using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libly.Pages.Books
{
    public class IndexModel : PageModel
    {
        public string[] bookNames;
        public void OnGet()
        {
            bookNames = [
                "The Great Gatsby",
                "To Kill a Mockingbird",
                "The God Father",
                "Pride and Prejudice"
            ];
        }
    }
}
