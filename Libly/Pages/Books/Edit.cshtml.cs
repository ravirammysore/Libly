using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libly.Core.Dtos;
using Libly.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libly.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly ApiClient _apiClient;

        public EditModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [BindProperty]
        public BookUpdateDto Book { get; set; }

        public List<SelectListItem> CategoryOptions { get; set; }

        public IActionResult OnGet(int id)
        {
            var book = _apiClient.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            Book = new BookUpdateDto
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
                PopulateDropdown();
                return Page();
            }

            _apiClient.UpdateBook(Book.Id, Book);
            return RedirectToPage("./Index");
        }

        private void PopulateDropdown()
        {
            // Fetch categories from the API or database
            // This is a placeholder. Replace with actual category fetching logic.
            CategoryOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Fiction" },
                new SelectListItem { Value = "2", Text = "Science Fiction" }
            };
        }
    }
}
