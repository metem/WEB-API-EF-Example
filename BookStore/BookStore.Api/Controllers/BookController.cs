using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext bookContext;

        public BookController(BookContext bookContext)
        {
            this.bookContext = bookContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return this.bookContext.Books;
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            return this.bookContext.Books.First(book => book.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Post([FromBody] Book book)
        {
            this.bookContext.Books.Add(book);
            await this.bookContext.SaveChangesAsync();

            return book;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Put(int id, [FromBody] Book book)
        {
            book.Id = id;
            this.bookContext.Books.Update(book);
            await this.bookContext.SaveChangesAsync();

            return book;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            this.bookContext.Books.Remove(Get(id).Value);
            await this.bookContext.SaveChangesAsync();

            return Ok();
        }
    }
}
