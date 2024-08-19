using System;
using System.Collections.Generic;
using System.Linq;
using Libly.Models;

namespace Libly.Data
{
    public static class BooksData
    {
        // In-memory book collection initialized with some sample data
        private static List<Book> books = new List<Book>
        {
          /*  new Book(1, "The Great Gatsby", "Fiction", new DateTime(1925, 4, 10)),
            new Book(2, "To Kill a Mockingbird", "Fiction", new DateTime(1960, 7, 11)),
            new Book(3, "1984", "Dystopian", new DateTime(1949, 6, 8)),
            new Book(4, "Pride and Prejudice", "Romance", new DateTime(1813, 1, 28))*/
        };

        // Create a new book
        public static void Create(Book book)
        {
            // Set the ID and CreatedOn fields
            book.Id = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;            
            books.Add(book);
        }

        // Read all books
        public static List<Book> GetAll()
        {
            return books;
        }

        // Read a single book by ID
        public static Book GetById(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        // Update an existing book
        public static void Update(Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Category = updatedBook.Category;
                book.Dop = updatedBook.Dop;
                book.ModifiedOn = DateTime.Now;
            }
        }

        // Delete a book by ID
        public static void Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
            }
        }
    }
}
