using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libly.Data;
using Libly.Models;
using Microsoft.EntityFrameworkCore;


namespace Libly.Pages.Books
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Book? Book { get; set; }

        public IActionResult OnGet(int id)
        {
            // Retrieve the book to be deleted
            //Book = BooksData.GetById(id);
            using (var context = new BooksContext())
            {
                Book = context.Books
                            .Include(b => b.Category)
                            .SingleOrDefault(b => b.Id == id);
            }

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            // Delete the book from the static collection
            //BooksData.Delete(Book.Id);

            if(Book != null)
            {
                using (var context = new BooksContext())
                {
                    context.Books.Remove(Book);
                    context.SaveChanges();
                }
            }           
            // Redirect back to the Index page after deletion
            return RedirectToPage("./Index");
        }
    }
}
