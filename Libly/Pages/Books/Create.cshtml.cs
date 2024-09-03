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

            try
            {
                _apiClient.CreateBook(Book);
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error creating the book. Please try again later.");
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
