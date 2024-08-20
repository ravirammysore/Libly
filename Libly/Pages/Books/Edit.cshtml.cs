using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libly.Data;
using Libly.Models;
using Libly.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libly.Pages.Books
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public BookViewModel BookVM { get; set; }

        public List<SelectListItem> CategoryOptions { get; set; }

        public IActionResult OnGet(int id)
        {
            // Load the book from the in-memory collection
            using (var context = new BooksContext())
            {
                //var book = BooksData.GetById(id);
                var book = context.Books.Find(id);

                if (book == null)
                {
                    return NotFound();
                }

                // Populate the view model
                BookVM = new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Dop = book.Dop,
                    CategoryId = book.CategoryId
                }; 
            }

            // Populate the category options
            CategoryOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Fiction" },
                new SelectListItem { Value = "2", Text = "Science Fiction" }
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Reload the category options if validation fails
                CategoryOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "1", Text = "Fiction" },
                    new SelectListItem { Value = "2", Text = "Science Fiction" }
                };
                return Page();
            }
            
            //var bookToUpdate = BooksData.GetById(BookVM.Id);            
            using (BooksContext context = new BooksContext())
            {
                var bookToUpdate = context.Books.Find(BookVM.Id);

                if (bookToUpdate == null)
                {
                    return NotFound();
                }

                // Update the book with the new values
                bookToUpdate.Title = BookVM.Title;
                bookToUpdate.Dop = BookVM.Dop;
                bookToUpdate.CategoryId = BookVM.CategoryId;

                bookToUpdate.ModifiedOn = DateTime.Now;

                //BooksData.Update(bookToUpdate);
                context.SaveChanges();

                return RedirectToPage("./Index");
            }
        }
    }
}
