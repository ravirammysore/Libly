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
            try
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
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error loading the book. Please try again later.");
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdown();
                return Page();
            }

            try
            {
                _apiClient.UpdateBook(Book.Id, Book);
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error updating the book. Please try again later.");
                PopulateDropdown();
                return Page();
            }
        }

        private void PopulateDropdown()
        {
            try
            {
                var categories = _apiClient.GetCategories();
                CategoryOptions = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error loading categories. Please try again later.");
            }
        }

    }
}
