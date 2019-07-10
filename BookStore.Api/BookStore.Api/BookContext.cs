using BookStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}