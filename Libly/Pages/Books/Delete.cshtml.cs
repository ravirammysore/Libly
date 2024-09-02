using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libly.Core.Dtos;
using Libly.Services;

namespace Libly.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly ApiClient _apiClient;

        public DeleteModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [BindProperty]
        public BookDto Book { get; set; }

        public IActionResult OnGet(int id)
        {
            Book = _apiClient.GetBook(id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            _apiClient.DeleteBook(id);
            return RedirectToPage("./Index");
        }
    }
}
