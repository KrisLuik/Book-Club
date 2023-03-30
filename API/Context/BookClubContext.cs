using BookClubApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookClubApi.Context
{
    public class BookClubContext : DbContext
    {
        public BookClubContext(DbContextOptions options): base(options) 
        {
        
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Rating> Ratings { get; set; }  
    }
    
}
