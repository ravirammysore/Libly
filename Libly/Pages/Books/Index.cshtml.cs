using Libly.Data;
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
            Books = BooksData.GetAll();
        }
    }   
}
