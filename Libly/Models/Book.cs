using System;
using System.ComponentModel.DataAnnotations;

namespace Libly.Models
{
    public class Book
    {
        //Auto-implemented properties in C#
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }        
        public DateTime Dop { get; set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? ModifiedOn { get; set; }
        
        public Book(int id, string title, string category, DateTime dop)
        {
            Id = id;
            Title = title;
            Category = category;
            Dop = dop;
            CreatedOn = DateTime.Now;
        }
    }
}
