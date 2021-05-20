using Microsoft.EntityFrameworkCore;
using DogWebApp.Models;
using System;

namespace DogWebApp.Data
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(new Dog[] {
                new Dog { Id = 1,
                          Name = "Treasure",
                          Breed =  "Havanese",
                          Birthday = new DateTime(2010, 4, 22),
                          Age = 11,
                          Weight = 10
                },
                new Dog { Id = 2,
                          Name = "Teegan",
                          Breed =  "Shih Tzu",
                          Birthday = new DateTime(2015, 1, 1),
                          Age = 6,
                          Weight = 16
                },
                new Dog { Id = 3,
                          Name = "Declan",
                          Breed =  "Golden Retriever",
                          Birthday = new DateTime(2008, 3, 25),
                          Age = 13,
                          Weight = 80
                },
                new Dog { Id = 4,
                          Name = "Cloe",
                          Breed =  "Chihuahua-Toy Poodle Mix",
                          Birthday = new DateTime(2009, 6, 29),
                          Age = 11,
                          Weight = 7
                },
            });
        }
    }
}