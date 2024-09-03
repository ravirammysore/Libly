using Libly.Core.Dtos;
using Libly.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libly.Pages.Books
{
    public class IndexModel(ApiClient apiClient) : BasePageModel
    {
        public List<BookDto> Books { get; set; } = [];

        public async Task OnGetAsync()
        {
            try
            {
                Books = await apiClient.GetBooksAsync();
            }
            catch (Exception ex)
            {
                DisplayError($"Error loading books: {ex.Message}");
            }
        }
    }
}
