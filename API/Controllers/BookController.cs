using BookClubApi.Context;
using BookClubApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookClubContext _bookClubContext;
        public BookController(BookClubContext bookClubContext)
        {
            _bookClubContext = bookClubContext;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookClubContext.Books;
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _bookClubContext.Books.FirstOrDefault(s => s.book_id == id);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            _bookClubContext.Books.Add(value);
            _bookClubContext.SaveChanges();
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            var book = _bookClubContext.Books.FirstOrDefault(s => s.book_id == id);
            if (book != null)
            {
                _bookClubContext.Entry<Book>(book).CurrentValues.SetValues(value);
                _bookClubContext.SaveChanges();
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var book = _bookClubContext.Books.FirstOrDefault(s => s.book_id == id);
            if (book != null)
            {
                _bookClubContext.Books.Remove(book);
                _bookClubContext.SaveChanges();
            }
        }
    }
}
