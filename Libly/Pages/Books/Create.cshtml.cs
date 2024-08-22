using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libly.Data;
using Libly.Models;
using System.Collections.Generic;
using Libly.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Libly.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly BooksContext _context;
        public CreateModel(BooksContext context)
        {
            _context = context;   
        }

        [BindProperty]
        public BookViewModel BookVM { get; set; }

        public List<SelectListItem> CategoryOptions { get; set; }

        public void OnGet()
        {
            // Fetch categories from the database
            PopulateDropdown();
        }        

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                /* Calling OnGet() will also work in the case, but this is a generic approach */
                PopulateDropdown();
                return Page();
            }

            // Map the view model to the actual Book model
            var book = new Book
            {
                Title = BookVM.Title,
                Dop = BookVM.Dop,
                CategoryId = BookVM.CategoryId            
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }

        private void PopulateDropdown()
        {
            //In edit page a better approach is shown
            var selectListItems = new List<SelectListItem>();

            foreach (var item in _context.Categories)
            {
                var selectListItem = new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                };
                selectListItems.Add(selectListItem);
            }
            CategoryOptions = selectListItems;
        }
    }
}
