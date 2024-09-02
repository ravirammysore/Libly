using Microsoft.EntityFrameworkCore;
using Libly.Core.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext to the DI container
builder.Services.AddDbContext<BooksContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
