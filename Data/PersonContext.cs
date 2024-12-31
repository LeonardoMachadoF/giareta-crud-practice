using Microsoft.EntityFrameworkCore;
using giareta_crud.Models;

namespace giareta_crud.Data
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }
        public DbSet<PersonModel> People { get; set; }
    }
}
