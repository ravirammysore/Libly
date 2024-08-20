using Microsoft.EntityFrameworkCore;
using Libly.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Libly.Data
{
    public class BooksContext : DbContext
    {
        private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=LibraryDB;Trusted_Connection=True;MultipleActiveResultSets=true";
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        // Declare the DbSet properties for Books and Categories
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Additional configuration can be done here if needed, such as seeding data
            // Example: Configure relationships, indexes, etc.
        }
    }
}
