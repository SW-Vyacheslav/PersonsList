using Microsoft.EntityFrameworkCore;
using PersonsList.Models;

namespace PersonsList.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) {}

        public DbSet<Person> People { get; set; }
    }
}
