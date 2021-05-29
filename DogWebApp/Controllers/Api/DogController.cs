using DogWebApp.Data;
using DogWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        //the context for the database
        private readonly DogContext _context;

        /// <summary>
        ///     Constructs this controller for Dogs
        /// </summary>
        /// <param name="context">
        ///     the database context
        /// </param>
        public DogController(DogContext context)
        {
            _context = context;
        }

        // GET: Api/Dog
        [HttpGet]
        public IEnumerable<Dog> GetDogs()
        {
            return _context.Dog.ToList();
        }

        // GET: Api/Dog/{id}
        [HttpGet("{id}")]
        public Dog GetDog(int id)
        {
            var dog = _context.Dog.SingleOrDefault(d => d.Id == id);

            if (dog == null)
            {
                NotFound();
            }

            return dog;
        }

        // POST: Api/Dog
        [HttpPost]
        public Dog CreateDog(Dog dog)
        {
            _context.Dog.Add(dog);
            _context.SaveChanges();

            return dog;
        }

        // PUT: Api/Dog/{id}
        [HttpPut("{id}")]
        public void UpdateDog(int id, Dog dog)
        {
            var dogInDb = _context.Dog.SingleOrDefault(d => d.Id == id);

            if (dogInDb == null)
            {
                NotFound();
            }

            dogInDb.Name = dog.Name;
            dogInDb.Birthday = dog.Birthday;
            dogInDb.Breed = dog.Breed;
            dogInDb.Age = dog.Age;
            dogInDb.Weight = dog.Weight;

            _context.SaveChanges();
        }

        // DELETE: Api/Dog/{id}
        [HttpDelete("{id}")]
        public void DeleteDog(int id)
        {
            var dogInDb = _context.Dog.SingleOrDefault(d => d.Id == id);

            if (dogInDb == null)
            {
                NotFound();
            }

            _context.Dog.Remove(dogInDb);
            _context.SaveChanges();
        }
    }
}
