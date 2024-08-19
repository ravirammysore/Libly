using System;
using System.Collections.Generic;

namespace Libly.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? ModifiedOn { get; set; }

        // Navigation property to the related Books
        public ICollection<Book> Books { get; set; }

        // Parameterless constructor
        public Category()
        {
            CreatedOn = DateTime.Now;
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
