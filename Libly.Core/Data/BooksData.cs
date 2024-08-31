using System;
using System.Collections.Generic;
using System.Linq;
using Libly.Core.Models;

namespace Libly.Core.Data
{
    public static class BooksData
    {
        // Predefined Category objects
        private static readonly Category fictionCategory = new Category(1, "Fiction");
        private static readonly Category scienceFictionCategory = new Category(2, "Science Fiction");

        // In-memory book collection
        private static List<Book> books = new List<Book>();

        // Initialize the books
        static BooksData()
        {
            // Sample books with assigned categories
            books = new List<Book>
            {
                new Book(1, "The Great Gatsby", new DateTime(1925, 4, 10), fictionCategory.Id)
                {
                    Category = fictionCategory
                },
                new Book(2, "To Kill a Mockingbird", new DateTime(1960, 7, 11), fictionCategory.Id)
                {
                    Category = fictionCategory
                },
                new Book(3, "1984", new DateTime(1949, 6, 8), scienceFictionCategory.Id)
                {
                    Category = scienceFictionCategory
                },
                new Book(4, "Pride and Prejudice", new DateTime(1813, 1, 28), fictionCategory.Id)
                {
                    Category = fictionCategory
                }
            };
        }

        // CRUD operations for books
        public static void Create(Book book)
        {
            book.Id = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;

            // Assign the correct Category reference
            if (book.CategoryId == fictionCategory.Id)
            {
                book.Category = fictionCategory;
            }
            else if (book.CategoryId == scienceFictionCategory.Id)
            {
                book.Category = scienceFictionCategory;
            }

            books.Add(book);
        }

        public static List<Book> GetAll()
        {
            return books;
        }

        public static Book GetById(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        public static void Update(Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Dop = updatedBook.Dop;
                book.CategoryId = updatedBook.CategoryId;

                // Assign the correct Category reference
                if (updatedBook.CategoryId == fictionCategory.Id)
                {
                    book.Category = fictionCategory;
                }
                else if (updatedBook.CategoryId == scienceFictionCategory.Id)
                {
                    book.Category = scienceFictionCategory;
                }

                book.ModifiedOn = DateTime.Now;
            }
        }

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
