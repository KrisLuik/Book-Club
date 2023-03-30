using BookClubApi.Context;
using BookClubApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private BookClubContext _bookClubContext;
        public RatingController(BookClubContext bookClubContext)
        {
            _bookClubContext = bookClubContext;
        }

        // GET: api/<RatingController>
        [HttpGet]
        public IEnumerable<Rating> Get()
        {
            return _bookClubContext.Ratings;
        }
        // GET api/<RatingController>/5
        [HttpGet("{id}")]
        public Rating Get(int id)
        {
            return _bookClubContext.Ratings.FirstOrDefault(s => s.rating_id == id);
        }

        // POST api/<RatingController>
        [HttpPost]
        public void Post([FromBody] Rating value)
        {
            _bookClubContext.Ratings.Add(value);
            _bookClubContext.SaveChanges();
        }

        // PUT api/<RatingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Rating value)
        {
            var rating = _bookClubContext.Ratings.FirstOrDefault(s => s.rating_id == id);
            if (rating != null)
            {
                _bookClubContext.Entry<Rating>(rating).CurrentValues.SetValues(value);
                _bookClubContext.SaveChanges();
            }
        }

        // DELETE api/<RatingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var rating = _bookClubContext.Ratings.FirstOrDefault(s => s.rating_id == id);
            if (rating != null)
            {
                _bookClubContext.Ratings.Remove(rating);
                _bookClubContext.SaveChanges();
            }
        }
    }
}
