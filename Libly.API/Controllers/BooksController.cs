using Libly.Core.Data;
using Libly.Core.Dtos;
using Libly.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BooksContext _context;

    public BooksController(BooksContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksAsync()
    {
        var books = await _context.Books
            .Include(b => b.Category)
            .Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Dop = b.Dop,
                FormattedTitle = b.FormattedTitle,
                CategoryId = b.CategoryId,
                CategoryName = b.Category.Name
            })
            .ToListAsync();

        return books;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetBookAsync(int id)
    {
        var book = await _context.Books
            .Include(b => b.Category)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        var bookDto = new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Dop = book.Dop,
            FormattedTitle = book.FormattedTitle,
            CategoryId = book.CategoryId,
            CategoryName = book.Category.Name
        };

        return bookDto;
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> CreateBookAsync(BookCreateDto bookDto)
    {
        var book = new Book
        {
            Title = bookDto.Title,
            Dop = bookDto.Dop,
            CategoryId = bookDto.CategoryId
        };

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        var createdBook = await _context.Books
            .Include(b => b.Category)
            .FirstAsync(b => b.Id == book.Id);

        var createdBookDto = new BookDto
        {
            Id = createdBook.Id,
            Title = createdBook.Title,
            Dop = createdBook.Dop,
            FormattedTitle = createdBook.FormattedTitle,
            CategoryId = createdBook.CategoryId,
            CategoryName = createdBook.Category.Name
        };

        return Ok(createdBookDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBookAsync(int id, BookUpdateDto bookDto)
    {
        if (id != bookDto.Id)
        {
            return BadRequest();
        }

        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        book.Title = bookDto.Title;
        book.Dop = bookDto.Dop;
        book.CategoryId = bookDto.CategoryId;
        book.ModifiedOn = DateTime.Now;

        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("categories")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesAsync()
    {
        var categories = await _context.Categories
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();

        return categories;
    }
}