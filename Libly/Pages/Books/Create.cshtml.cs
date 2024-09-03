using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Libly.Core.Dtos;
using Libly.Services;

namespace Libly.Pages.Books
{
    public class CreateModel(ApiClient apiClient) : BasePageModel
    {
        [BindProperty]
        public required BookCreateDto Book { get; init; }

        public List<SelectListItem> CategoryOptions { get; set; } = [];

        public async Task OnGetAsync() => await PopulateDropdownAsync();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdownAsync();
                return Page();
            }

            try
            {
                await apiClient.CreateBookAsync(Book);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                DisplayError($"Error creating the book: {ex.Message}");
                await PopulateDropdownAsync();
                return Page();
            }
        }

        private async Task PopulateDropdownAsync()
        {
            try
            {
                var categories = await apiClient.GetCategoriesAsync();
                CategoryOptions = categories
                    .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                    .ToList();
            }
            catch (Exception ex)
            {
                DisplayError($"Error loading categories: {ex.Message}");
            }
        }
    }
}
