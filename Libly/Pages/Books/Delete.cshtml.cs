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
            try
            {
                Book = _apiClient.GetBook(id);

                if (Book == null)
                {
                    return NotFound();
                }

                return Page();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error loading the book. Please try again later.");
                return Page();
            }
        }

        public IActionResult OnPost(int id)
        {
            try
            {
                _apiClient.DeleteBook(id);
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error deleting the book. Please try again later.");
                return Page();
            }
        }
    }
}
