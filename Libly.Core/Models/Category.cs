using System.Collections.Generic;

namespace Libly.Core.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }

        // Navigation property to the related Books
        public ICollection<Book> Books { get; set; }

        // Parameterless constructor
        public Category() : base()
        {
            Books = new List<Book>();
        }

        // Parameterized constructor
        public Category(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
