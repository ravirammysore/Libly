using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libly.Data;
using Libly.Models;
using System.Collections.Generic;
using Libly.ViewModels;

namespace Libly.Pages.Books
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public BookViewModel BookVM { get; set; }

        public List<SelectListItem> CategoryOptions { get; set; }

        public void OnGet()
        {
            //later we will remove this hardcoding
            CategoryOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Fiction" },
                new SelectListItem { Value = "2", Text = "Science Fiction" }
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                OnGet(); // Reload dropdown options
                return Page();
            }

            // Map the view model to the actual Book model
            var book = new Book
            {
                Title = BookVM.Title,
                Dop = BookVM.Dop,
                CategoryId = BookVM.CategoryId            
            };

            //BooksData.Create(book);
            using(BooksContext context = new BooksContext())
            {
                context.Books.Add(book);
                context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
