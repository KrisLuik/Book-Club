using BookClubApi.Context;
using BookClubApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private BookClubContext _bookClubContext;
        public PersonController(BookClubContext bookClubContext)
        {
            _bookClubContext = bookClubContext;
        }

        // GET: api/<PersonController>
        [HttpGet("display all members")]
        public IEnumerable<Person> Get()
        {
            return _bookClubContext.People;
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _bookClubContext.People.FirstOrDefault(s => s.person_id == id);
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Post([FromBody] Person value)
        {
            _bookClubContext.People.Add(value);
            _bookClubContext.SaveChanges();
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Person value)
        {
            var person = _bookClubContext.People.FirstOrDefault(s => s.person_id == id);
            if (person != null)
            {
                _bookClubContext.Entry<Person>(person).CurrentValues.SetValues(value);
                _bookClubContext.SaveChanges();
            }
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var person = _bookClubContext.People.FirstOrDefault(s => s.person_id == id);
            if (person != null)
            {
                _bookClubContext.People.Remove(person);
                _bookClubContext.SaveChanges();
            }
        }
    }
}
