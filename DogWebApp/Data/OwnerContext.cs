using Microsoft.EntityFrameworkCore;
using DogWebApp.Models;
using System;

namespace DogWebApp.Data
{
    public class OwnerContext : DbContext
    {
        public OwnerContext()
        {
        }

        public OwnerContext(DbContextOptions<OwnerContext> options)
            : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasData(new Owner[] {
                new Owner { Id = 1,
                          FirstName = "Emily",
                          LastName =  "Skerl",
                          Address = "123 Strawberry Lane, Willow Valley, Ohio, 44321",
                          PhoneNumber = "1 (234) 567-8901"
                },
                new Owner { Id = 2,
                          FirstName = "Bob",
                          LastName =  "Smith",
                          Address = "456 East 350 Street, Oakland, CA, 94620",
                          PhoneNumber = "1 (510) 602-5563"
                }
            });
        }
    }
}