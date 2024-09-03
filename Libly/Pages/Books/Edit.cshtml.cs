using Microsoft.AspNetCore.Mvc;
using Libly.Core.Dtos;
using Libly.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libly.Pages.Books
{
    public class EditModel(ApiClient apiClient) : BasePageModel
    {
        [BindProperty]
        public required BookUpdateDto Book { get; set; }

        public List<SelectListItem> CategoryOptions { get; set; } = [];

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                var book = await apiClient.GetBookAsync(id);

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

                await PopulateDropdownAsync();
                return Page();
            }
            catch (Exception ex)
            {
                DisplayError($"Error loading the book: {ex.Message}");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdownAsync();
                return Page();
            }

            try
            {
                await apiClient.UpdateBookAsync(Book.Id, Book);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                DisplayError($"Error updating the book: {ex.Message}");
                await PopulateDropdownAsync();
                return Page();
            }
        }

        private async Task PopulateDropdownAsync()
        {
            try
            {
                var categories = await apiClient.GetCategoriesAsync();
                CategoryOptions = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            }
            catch (Exception ex)
            {
                DisplayError($"Error loading categories: {ex.Message}");
            }
        }
    }
}
