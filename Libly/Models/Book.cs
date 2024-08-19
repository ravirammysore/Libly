using System;
using System.ComponentModel.DataAnnotations;

namespace Libly.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Dop { get; set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? ModifiedOn { get; set; }

        // Parameterless constructor
        public Book()
        {
            CreatedOn = DateTime.Now;
        }

        // Parameterized constructor
        public Book(int id, string title, string category, DateTime dop) : this()
        {
            Id = id;
            Title = title;
            Category = category;
            Dop = dop;
        }
    }

}
