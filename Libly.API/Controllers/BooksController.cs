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
    public ActionResult<IEnumerable<BookDto>> GetBooks()
    {
        var books = _context.Books
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
            .ToList();

        return books;
    }

    [HttpGet("{id}")]
    public ActionResult<BookDto> GetBook(int id)
    {
        var book = _context.Books
            .Include(b => b.Category)
            .FirstOrDefault(b => b.Id == id);

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
    public ActionResult<BookDto> CreateBook(BookCreateDto bookDto)
    {
        var book = new Book
        {
            Title = bookDto.Title,
            Dop = bookDto.Dop,
            CategoryId = bookDto.CategoryId
        };

        _context.Books.Add(book);
        _context.SaveChanges();

        var createdBook = _context.Books
            .Include(b => b.Category)
            .First(b => b.Id == book.Id);

        var createdBookDto = new BookDto
        {
            Id = createdBook.Id,
            Title = createdBook.Title,
            Dop = createdBook.Dop,
            FormattedTitle = createdBook.FormattedTitle,
            CategoryId = createdBook.CategoryId,
            CategoryName = createdBook.Category.Name
        };

        return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBookDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, BookUpdateDto bookDto)
    {
        if (id != bookDto.Id)
        {
            return BadRequest();
        }

        var book = _context.Books.Find(id);
        if (book == null)
        {
            return NotFound();
        }

        book.Title = bookDto.Title;
        book.Dop = bookDto.Dop;
        book.CategoryId = bookDto.CategoryId;
        //lets stamp this to know when it was modified
        book.ModifiedOn = DateTime.Now;

        _context.Entry(book).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        _context.SaveChanges();

        return NoContent();
    }
}