using BookClubApi.Context;
using BookClubApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private BookClubContext _bookClubContext;
        public AuthorController(BookClubContext bookClubContext)
        {
            _bookClubContext = bookClubContext;
        }
        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _bookClubContext.Authors;
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return _bookClubContext.Authors.FirstOrDefault(s => s.author_id == id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public void Post([FromBody] Author value)
        {
            _bookClubContext.Authors.Add(value);
            _bookClubContext.SaveChanges(); 
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Author value)
        {
            var author = _bookClubContext.Authors.FirstOrDefault(s => s.author_id == id);
            if (author != null)
            {
                _bookClubContext.Entry<Author>(author).CurrentValues.SetValues(value);
                _bookClubContext.SaveChanges();
            }
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var author = _bookClubContext.Authors.FirstOrDefault(s => s.author_id == id);
            if (author != null)
            {
                _bookClubContext.Authors.Remove(author);
                _bookClubContext.SaveChanges();
            }
        }
    }
}
