var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapGet("/books", () =>
{
    var books = new List<Book>
    {
        new Book { Id = 1, Title = "The Great Gatsby", Dop = new DateTime(1925, 4, 10) },
        new Book { Id = 2, Title = "To Kill a Mockingbird", Dop = new DateTime(1960, 7, 11) },
        new Book { Id = 3, Title = "1984", Dop = new DateTime(1949, 6, 8) }
    };
    return books;
});

app.Run();

class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Dop { get; set; }
}