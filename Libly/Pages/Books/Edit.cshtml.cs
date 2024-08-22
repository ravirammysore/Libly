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
        private readonly BooksContext _context;
        public EditModel(BooksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookViewModel BookVM { get; set; }

        public List<SelectListItem> CategoryOptions { get; set; }

        public IActionResult OnGet(int id)
        {
            var book = _context.Books.Find(id);

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

            PopulateDropdown();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Reload the category options if validation fails
                PopulateDropdown();
                return Page();
            }

            var bookToUpdate = _context.Books.Find(BookVM.Id);

            if (bookToUpdate == null)
            {
                return NotFound();
            }

            // Update the book with the new values
            bookToUpdate.Title = BookVM.Title;
            bookToUpdate.Dop = BookVM.Dop;
            bookToUpdate.CategoryId = BookVM.CategoryId;
            bookToUpdate.ModifiedOn = DateTime.Now;

            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
        private void PopulateDropdown()
        {
            //This is more readable than the approach in the create page
            var items = _context.Categories
                                .Select(c => new SelectListItem
                                {
                                    Value = c.Id.ToString(),
                                    Text = c.Name
                                });

            CategoryOptions = items.ToList();
        }
    }
}
