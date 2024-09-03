using Microsoft.AspNetCore.Mvc;
using Libly.Core.Dtos;
using Libly.Services;

namespace Libly.Pages.Books
{
    public class DeleteModel(ApiClient apiClient) : BasePageModel
    {
        [BindProperty]
        public BookDto? Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                Book = await apiClient.GetBookAsync(id);

                return Book == null ? NotFound() : Page();
            }
            catch (Exception ex)
            {
                DisplayError($"Error loading the book: {ex.Message}");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                await apiClient.DeleteBookAsync(id);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                DisplayError($"Error deleting the book: {ex.Message}");
                return Page();
            }
        }
    }
}
