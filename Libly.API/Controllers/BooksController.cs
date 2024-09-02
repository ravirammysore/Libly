using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Libly.Core.Data;
using Libly.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Libly.API.Controllers
{
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
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return _context.Books.ToList();
        }
    }
}