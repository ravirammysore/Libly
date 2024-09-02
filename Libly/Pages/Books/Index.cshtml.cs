using Libly.Core.Dtos;
using Libly.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libly.Pages.Books
{
    public class IndexModel : PageModel
    {        
        private readonly ApiClient _apiClient;

        public IndexModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public List<BookDto> Books { get; set; }

        public void OnGet()
        {
            Books = _apiClient.GetBooks();
        }
    }
}
