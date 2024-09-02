var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapControllers();

app.Run();

class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Dop { get; set; }
}