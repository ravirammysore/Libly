using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libly.Pages.Books
{    
    public class IndexModel : PageModel
    {        
        public List<Book> books;
        public void OnGet()
        {
            books = new List<Book>
            {
                new Book(1, "The Great Gatsby", "Fiction", new DateTime(1925, 4, 10)),
                new Book(2, "To Kill a Mockingbird", "Fiction", new DateTime(1960, 7, 11)),
                new Book(3, "1984", "Dystopian", new DateTime(1949, 6, 8)),
                new Book(4, "Pride and Prejudice", "Romance", new DateTime(1813, 1, 28))
            };
        }
    }
    public class Book
    {        
        private int id;
        private string title;
        private string category;
        private DateTime dop; 
        private DateTime createdOn;
        private DateTime? modifiedOn; 

        public Book(int id, string title, string category, DateTime dop)
        {
            this.id = id;
            this.title = title;
            this.category = category;
            this.dop = dop;
            this.createdOn = DateTime.Now;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        public string GetTitle()
        {
            return title;
        }

        public void SetTitle(string value)
        {
            title = value;
        }

        public string GetCategory()
        {
            return category;
        }

        public void SetCategory(string value)
        {
            category = value;
        }

        public DateTime GetDop()
        {
            return dop;
        }

        public void SetDop(DateTime value)
        {
            dop = value;
        }

        public DateTime GetCreatedOn()
        {
            return createdOn;
        }

        public DateTime? GetModifiedOn()
        {
            return modifiedOn;
        }

        public void SetModifiedOn(DateTime? value)
        {
            modifiedOn = value;
        }
    }
}
