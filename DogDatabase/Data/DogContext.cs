using Microsoft.EntityFrameworkCore;
using DogDatabase.Models;

namespace DogDatabase.Data
{
    public class DogContext : DbContext
    {
        public DogContext()
        {
        }

        public DogContext(DbContextOptions<DogContext> options)
            : base(options)
        {
        }

        public DbSet<Dog> Dog { get; set; }
    }
}