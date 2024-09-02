using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libly.Core.Dtos;
using Libly.Services;

namespace Libly.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly ApiClient _apiClient;

        public CreateModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [BindProperty]
        public BookCreateDto Book { get; set; }

        public List<SelectListItem> CategoryOptions { get; set; }

        public void OnGet()
        {
            PopulateDropdown();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdown();
                return Page();
            }

            _apiClient.CreateBook(Book);
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
